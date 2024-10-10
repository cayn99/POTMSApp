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
        public DbSet<User> Users { get; set; }
    }
}
