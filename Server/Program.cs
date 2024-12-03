using AspNetCore.Swagger.Themes;
using BaseLibrary.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.Data;
using ServerLibrary.Helper;
using ServerLibrary.Repositories.Contracts;
using ServerLibrary.Repositories.Implementations;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtSection>(builder.Configuration.GetSection("JwtSection"));
var jwtSection = builder.Configuration.GetSection(nameof(JwtSection)).Get<JwtSection>();

// starting

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")??
		throw new InvalidOperationException("Sorry, your connection is not found"));
});
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = jwtSection!.Issuer,
		ValidAudience = jwtSection.Audience,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.Key!))
	};
});

builder.Services.AddScoped<IUserAccount, UserAccountRepository>();
builder.Services.AddScoped<IGenericRepositoryInterface<AccountingApproval>, AccountingApprovalRepository>();
builder.Services.AddScoped<IGenericRepositoryInterface<AccountingComplete>, AccountingCompleteRepository>();
builder.Services.AddScoped<IGenericRepositoryInterface<Coa>, CoaRepository>();
builder.Services.AddScoped<IGenericRepositoryInterface<Inspection>, InspectionRepository>();
builder.Services.AddScoped<IGenericRepositoryInterface<OrderDelivery>, OrderDeliveryRepository>();
builder.Services.AddScoped<IGenericRepositoryInterface<OrderReceived>, OrderReceivedRepository>();
builder.Services.AddScoped<IGenericRepositoryInterface<PurchaseOrder>, PurchaseOrderRepository>();
builder.Services.AddScoped<IGenericRepositoryInterface<PurchaseRequest>, PurchaseRequestRepository>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowBlazorWasm",
		builder => builder
		.WithOrigins("http://localhost:5277", "https://localhost:7025")
		.AllowAnyMethod()
		.AllowAnyHeader()
		.AllowCredentials());
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(Style.Dark);
}

app.UseHttpsRedirection();
app.UseCors("AllowBlazorWasm");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
