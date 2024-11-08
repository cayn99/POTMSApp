using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Data
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<AccountingApproval> AccountingApprovals { get; set; }
		public DbSet<AccountingComplete> AccountingComplete { get; set; }
		public DbSet<Coa> Coa { get; set; }
		public DbSet<Inspection> Inspections { get; set; }
		public DbSet<OrderDelivery> OrderDeliveries { get; set; }
		public DbSet<OrderReceived> OrderReceived { get; set; }
		public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
		public DbSet<Request> Requests { get; set; }
		// Authentication
		public DbSet<User> Users { get; set; }
		public DbSet<SystemRole> SystemRoles { get; set; }
		public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<AccountingApproval>()
		   .HasOne(aa => aa.AccountingComplete)
		   .WithOne(ac => ac.AccountingApproval)
		   .HasForeignKey<AccountingApproval>(aa => aa.AccountingCompleteId);

			modelBuilder.Entity<OrderDelivery>()
		   .HasOne(od => od.OrderReceived)
		   .WithOne(or => or.OrderDelivery)
		   .HasForeignKey<OrderDelivery>(od => od.OrderReceivedId);

			modelBuilder.Entity<PurchaseOrder>()
			.HasOne(p => p.AccountingApproval)
			.WithOne(aa => aa.PurchaseOrder)
			.HasForeignKey<PurchaseOrder>(p => p.AccountingApprovalId);

			modelBuilder.Entity<PurchaseOrder>()
		   .HasOne(p => p.OrderDelivery)
		   .WithOne(od => od.PurchaseOrder)
		   .HasForeignKey<PurchaseOrder>(p => p.OrderDeliveryId);

			modelBuilder.Entity<PurchaseOrder>()
			.HasOne(p => p.Coa)
			.WithOne(c => c.PurchaseOrder)
			.HasForeignKey<PurchaseOrder>(p => p.CoaId);

			modelBuilder.Entity<PurchaseOrder>()
			.HasOne(p => p.Inspection)
			.WithOne(i => i.PurchaseOrder)
			.HasForeignKey<PurchaseOrder>(p => p.InspectionId);

			modelBuilder.Entity<PurchaseOrder>()
		   .HasOne(p => p.Request)
		   .WithOne(r => r.PurchaseOrder)
		   .HasForeignKey<PurchaseOrder>(p => p.RequestId);
		}
	}
}

