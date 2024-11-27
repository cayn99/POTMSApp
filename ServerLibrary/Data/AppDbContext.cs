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

			modelBuilder.Entity<AccountingApproval>()
		   .HasOne(aa => aa.AccountingComplete)
		   .WithOne(ac => ac.AccountingApproval)
		   .HasForeignKey<AccountingComplete>(ac => ac.AccountingApprovalId);

			modelBuilder.Entity<OrderDelivery>()
		   .HasOne(od => od.OrderReceived)
		   .WithOne(or => or.OrderDelivery)
		   .HasForeignKey<OrderReceived>(or => or.OrderDeliveryId);

			modelBuilder.Entity<AccountingComplete>()
			.HasOne(ac => ac.PurchaseOrder)
			.WithOne(p => p.AccountingComplete)
			.HasForeignKey<PurchaseOrder>(p => p.AccountingCompleteId);

			modelBuilder.Entity<OrderReceived>()
		   .HasOne(or => or.PurchaseOrder)
		   .WithOne(p => p.OrderReceived)
		   .HasForeignKey<PurchaseOrder>(p => p.OrderReceivedId);

			modelBuilder.Entity<Coa>()
			.HasOne(c => c.PurchaseOrder)
			.WithOne(p => p.Coa)
			.HasForeignKey<PurchaseOrder>(p => p.CoaId);

			modelBuilder.Entity<Inspection>()
			.HasOne(i => i.PurchaseOrder)
			.WithOne(p => p.Inspection)
			.HasForeignKey<PurchaseOrder>(p => p.InspectionId);

			modelBuilder.Entity<Request>()
		   .HasOne(r => r.PurchaseOrder)
		   .WithOne(p => p.Request)
		   .HasForeignKey<PurchaseOrder>(p => p.RequestId);
		}
	}
}

