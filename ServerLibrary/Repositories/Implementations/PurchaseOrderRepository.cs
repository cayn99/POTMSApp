using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations
{
    public class PurchaseOrderRepository(AppDbContext context) : IGenericRepositoryInterface<PurchaseOrder>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var purchaseOrder = await context.PurchaseOrders.FindAsync(id);
            if (purchaseOrder == null)
                return NotFound();

            context.PurchaseOrders.Remove(purchaseOrder);
            await Commit();
            return Success();
        }

        public async Task<List<PurchaseOrder>> GetAll() => await context.PurchaseOrders.ToListAsync();
        public async Task<PurchaseOrder> GetById(int id) => await context.PurchaseOrders.FindAsync(id);

        public async Task<GeneralResponse> Insert(PurchaseOrder item)
        {
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Purchase order details already added");
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(PurchaseOrder item)
        {
            var purchaseOrder = await context.PurchaseOrders.FindAsync(item.Id);
            if (purchaseOrder == null)
                return NotFound();
            purchaseOrder.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, purchase order details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await context.PurchaseOrders.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
