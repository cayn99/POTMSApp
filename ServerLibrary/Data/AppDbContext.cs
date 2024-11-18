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
		public DbSet<AccountingComplete> AllAccountingComplete { get; set; }
		public DbSet<Coa> AllCoa { get; set; }
		public DbSet<Inspection> Inspections { get; set; }
		public DbSet<OrderDelivery> OrderDeliveries { get; set; }
		public DbSet<OrderReceived> OrdersReceived { get; set; }
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

			modelBuilder.Entity<AccountingComplete>()
		   .HasOne(ac => ac.AccountingApproval)
		   .WithOne(aa => aa.AccountingComplete)
		   .HasForeignKey<AccountingComplete>(ac => ac.AccountingApprovalId);

			modelBuilder.Entity<OrderReceived>()
		   .HasOne(or => or.OrderDelivery)
		   .WithOne(od => od.OrderReceived)
		   .HasForeignKey<OrderReceived>(or => or.OrderDeliveryId);

			modelBuilder.Entity<PurchaseOrder>()
			.HasOne(p => p.AccountingComplete)
			.WithOne(ac => ac.PurchaseOrder)
			.HasForeignKey<PurchaseOrder>(p => p.AccountingCompleteId);

			modelBuilder.Entity<PurchaseOrder>()
		   .HasOne(p => p.OrderReceived)
		   .WithOne(or => or.PurchaseOrder)
		   .HasForeignKey<PurchaseOrder>(p => p.OrderReceivedId);

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

