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

        public async Task<List<PurchaseOrder>> GetAll() => await context.PurchaseOrders.AsNoTracking()
            .Include(r => r.Request).ToListAsync();
        public async Task<PurchaseOrder> GetById(int id) => await context.PurchaseOrders.FindAsync(id);

        public async Task<GeneralResponse> Insert(PurchaseOrder item)
        {
            if (!await CheckRecordNumberExists(item.RequestId)) // Use RecordNumber to check uniqueness
                return new GeneralResponse(false, "Purchase Order with this record number already exists.");
            context.PurchaseOrders.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(PurchaseOrder item)
        {
            var purchaseOrder = await context.PurchaseOrders.FindAsync(item.Id);
            if (purchaseOrder == null)
                return NotFound();
            purchaseOrder.Remarks = item.Remarks;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, purchase order details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
        private async Task<bool> CheckRecordNumberExists(int recordNumber)
        {
            var item = await context.Requests.FirstOrDefaultAsync(x => x.RecordNumber == recordNumber);
            return item is null; // Returns true if no item is found (valid for insertion)
        }
    }
}
