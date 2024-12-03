using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.Data;
using ServerLibrary.Helper;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Constants = ServerLibrary.Helper.Constants;

namespace ServerLibrary.Repositories.Implementations
{
	public class UserAccountRepository(IOptions<JwtSection> config, AppDbContext context) : IUserAccount
	{
		public async Task<GeneralResponse> CreateAsync(Register user)
		{
			if (user is null) 
				return new GeneralResponse(false, "Model is empty");

			var checkUser = await FindUserByEmail(user.Email!);
			if (checkUser != null)
				return new GeneralResponse(false, "User registered already");

			var applicationUser = await AddToDatabase(new User()
			{
				FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Email = user.Email,
				Division = user.Division,
				Position = user.Position,
				Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
			});

			var checkAdminRole = await context.SystemRoles.FirstOrDefaultAsync
				(_ => _.Name!.Equals(Constants.Admin));
			if (checkAdminRole is null)
			{
				var createAdminRole = await AddToDatabase(new SystemRole() { Name = Constants.Admin });
				await AddToDatabase(new UserRole() { RoleId = createAdminRole.Id, UserId = applicationUser.Id });
				return new GeneralResponse(true, "Admin account created!");
			}

			var checkUserRole = await context.SystemRoles.FirstOrDefaultAsync(_ => _.Name!.Equals(Constants.Staff));
			SystemRole response = new();
			if (checkUserRole is null)
			{
				response = await AddToDatabase(new SystemRole() { Name = Constants.Staff });
				await AddToDatabase(new UserRole() { RoleId = response.Id, UserId = applicationUser.Id });
			}
			else
			{
				await AddToDatabase(new UserRole() { RoleId = checkUserRole.Id, UserId = applicationUser.Id });
			}
			return new GeneralResponse(true, "Staff account created!");
		}

		public async Task<LoginResponse> SignInAsync(Login user)
		{
			if (user is null)
				return new LoginResponse(false, "Model is empty");
			var applicationUser = await FindUserByEmail(user.Email!);
			if (applicationUser is null)
				return new LoginResponse(false, "User not found");
			if (!BCrypt.Net.BCrypt.Verify(user.Password, applicationUser.Password))
				return new LoginResponse(false, "Email/Password not valid");
			var getUserRole = await FindUserRole(applicationUser.Id);
			if (getUserRole is null)
				return new LoginResponse(false, "User role not found");
			var getRoleName = await FindRoleName(getUserRole.RoleId);
			if (getUserRole is null)
				return new LoginResponse(false, "User role not found");
			string jwtToken = GenerateToken(applicationUser, getRoleName!.Name!);
			string refreshToken = GenerateRefreshToken();
			var findUser = await context.RefreshTokenInfos.FirstOrDefaultAsync
				(_ => _.UserId == applicationUser.Id);
			if (findUser is not null)
			{
				findUser!.Token = refreshToken;
				await context.SaveChangesAsync();
			}
			else
			{
				await AddToDatabase(new RefreshTokenInfo() { Token = refreshToken, UserId = applicationUser.Id });
			}
			return new LoginResponse(true, "Login successfully", jwtToken, refreshToken);
		}

		private async Task<UserRole> FindUserRole(int userId) => await context.UserRoles.FirstOrDefaultAsync
			(_ => _.UserId == userId);
		private async Task<SystemRole> FindRoleName(int roleId) => await context.SystemRoles.FirstOrDefaultAsync
			(_ => _.Id == roleId);
		private static string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
		private string GenerateToken(User user, string role)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Value.Key!));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var userClaims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.FirstName),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, role!),
			};
			var token = new JwtSecurityToken(
				issuer: config.Value.Issuer,
				audience: config.Value.Audience,
				claims: userClaims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		private async Task<User> FindUserByEmail(string email) =>
			await context.Users.FirstOrDefaultAsync(_ => _.Email!.ToLower()!.Equals(email!.ToLower()));

		private async Task<T> AddToDatabase<T>(T model)
		{
			var result = context.Add(model!);
			await context.SaveChangesAsync();
			return (T)result.Entity;
		}

		public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
		{
			if (token == null)
				return new LoginResponse(false, "Model is empty");
			var findToken = await context.RefreshTokenInfos.FirstOrDefaultAsync
				(_ => _.Token!.Equals(token.Token));

			// get user details
			var user = await context.Users.FirstOrDefaultAsync(_ => _.Id == findToken.UserId);
			if (user is null)
				return new LoginResponse(false, "Refresh token could not be generated because user not found");

			var userRole = await FindUserRole(user.Id);
			var roleName = await FindRoleName(userRole.RoleId);
			string jwtToken = GenerateToken(user, roleName.Name!);
			string refreshToken = GenerateRefreshToken();

			var updateRefreshToken = await context.RefreshTokenInfos.FirstOrDefaultAsync
				(_ => _.UserId == user.Id);
			if (updateRefreshToken is null)
				return new LoginResponse(false, "Refresh token could not be generated because user has not signed in");

			updateRefreshToken.Token = refreshToken;
			await context.SaveChangesAsync();
			return new LoginResponse(true, "Token refreshed successfully", jwtToken, refreshToken);
		}

		public async Task<List<ManageUser>> GetUsers()
		{
			var allUsers = await GetApplicationUsers();
			var allUserRoles = await UserRoles();
			var allRoles = await SystemRoles();

			if (allUsers.Count == 0 || allRoles.Count == 0)
				return null!;

			var users = new List<ManageUser>();
			foreach (var user in allUsers)
			{
				var userRole = allUserRoles.FirstOrDefault(u => u.UserId == user.Id);
				var roleName = allRoles.FirstOrDefault(u => u.Id == userRole!.RoleId);
				users.Add(new ManageUser() { UserId = user.Id, FirstName = user.FirstName!, LastName = user.LastName!, Email = user.Email!, Division = user.Division, Position = user.Position, Role = roleName!.Name! });
			}
			return users;
		}

		public async Task<GeneralResponse> UpdateUser(ManageUser user)
		{
			var getRole = (await SystemRoles()).FirstOrDefault(r => r.Name!.Equals(user.Role));
			var userRole = await context.UserRoles.FirstOrDefaultAsync(u => u.UserId == user.UserId);
			userRole!.RoleId = getRole!.Id;
			await context.SaveChangesAsync();
			return new GeneralResponse(true, "User role updated successfully");
		}

		public async Task<List<SystemRole>> GetRoles() => await SystemRoles();

		public async Task<GeneralResponse> DeleteUser(int id)
		{
			var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
			context.Users.Remove(user!);
			await context.SaveChangesAsync();
			return new GeneralResponse(true, "User successfully deleted");
		}
		
		private async Task<List<SystemRole>> SystemRoles() => await context.SystemRoles.AsNoTracking().ToListAsync();
        private async Task<List<UserRole>> UserRoles() => await context.UserRoles.AsNoTracking().ToListAsync();
        private async Task<List<User>> GetApplicationUsers() => await context.Users.AsNoTracking().ToListAsync();
    }
}