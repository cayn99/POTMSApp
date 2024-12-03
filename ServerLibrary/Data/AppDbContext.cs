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
		public DbSet<AccountingApproval>? AccountingApprovals { get; set; }
		public DbSet<AccountingComplete>? AllAccountingComplete { get; set; }
		public DbSet<Coa>? AllCoa { get; set; }
		public DbSet<Inspection>? Inspections { get; set; }
		public DbSet<OrderDelivery>? OrderDeliveries { get; set; }
		public DbSet<OrderReceived>? OrdersReceived { get; set; }
		public DbSet<PurchaseOrder>? PurchaseOrders { get; set; }
		public DbSet<PurchaseRequest>? PurchaseRequests { get; set; }
		// Authentication
		public DbSet<User>? Users { get; set; }
		public DbSet<SystemRole>? SystemRoles { get; set; }
		public DbSet<RefreshTokenInfo>? RefreshTokenInfos { get; set; }
		public DbSet<UserRole>? UserRoles { get; set; }

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

            modelBuilder.Entity<PurchaseRequest>()
                .HasOne(pr => pr.Coa)
                .WithOne(c => c.PurchaseRequest)
                .HasForeignKey<Coa>(c => c.PurchaseRequestId);

            modelBuilder.Entity<PurchaseRequest>()
                .HasOne(pr => pr.Inspection)
                .WithOne(i => i.PurchaseRequest)
                .HasForeignKey<Inspection>(i => i.PurchaseRequestId);

            modelBuilder.Entity<PurchaseRequest>()
			.HasOne(pr => pr.AccountingComplete)
			.WithOne(ac => ac.PurchaseRequest)
			.HasForeignKey<AccountingComplete>(ac => ac.PurchaseRequestId);

			modelBuilder.Entity<PurchaseRequest>()
		   .HasOne(pr => pr.OrderReceived)
		   .WithOne(or => or.PurchaseRequest)
		   .HasForeignKey<OrderReceived>(or => or.PurchaseRequestId);

			modelBuilder.Entity<PurchaseRequest>()
			.HasOne(pr => pr.PurchaseOrder)
			.WithOne(po => po.PurchaseRequest)
			.HasForeignKey<PurchaseOrder>(po => po.PurchaseRequestId);
		}
	}
}

