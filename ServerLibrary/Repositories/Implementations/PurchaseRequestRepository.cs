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
    public class PurchaseRequestRepository(AppDbContext context) : IGenericRepositoryInterface<PurchaseRequest>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var request = await context.PurchaseRequests.FindAsync(id);
            if (request == null)
                return NotFound();

            context.PurchaseRequests.Remove(request);
            await Commit();
            return Success();
        }

        public async Task<List<PurchaseRequest>> GetAll() => await context.PurchaseRequests.ToListAsync();
        public async Task<PurchaseRequest> GetById(int id) => await context.PurchaseRequests.FindAsync(id);

        public async Task<GeneralResponse> Insert(PurchaseRequest item)
        {
            var checkIfNull = await CheckPRNumber(item.PrNumber);
            if (!checkIfNull)
                return new GeneralResponse(false, "Purchase request already added");
            context.PurchaseRequests.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(PurchaseRequest item)
        {
            var purchaseRequest = await context.PurchaseRequests.FindAsync(item.Id);
            if (purchaseRequest == null)
                return NotFound();
            purchaseRequest.PrNumber = item.PrNumber;
            purchaseRequest.Division = item.Division;
            purchaseRequest.Date = item.Date;
            purchaseRequest.Particulars = item.Particulars;
            purchaseRequest.UnitType = item.UnitType;
            purchaseRequest.Quantity = item.Quantity;
            purchaseRequest.UnitCost = item.UnitCost;
            purchaseRequest.TotalCost = item.TotalCost;
            purchaseRequest.DeliveryTerm = item.DeliveryTerm;
            purchaseRequest.DeliveryArea = item.DeliveryArea;
            purchaseRequest.Purpose = item.Purpose;
            purchaseRequest.ProjectTitle = item.ProjectTitle;
            purchaseRequest.ProjectCode = item.ProjectCode;
            purchaseRequest.Requestor = item.Requestor;

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, request details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
        private async Task<bool> CheckPRNumber(string prNumber)
        {
            var item = await context.PurchaseRequests.FirstOrDefaultAsync(x => x.PrNumber!.ToLower().Equals(prNumber.ToLower()));
            return item is null; // Returns true if no item is found (valid for insertion)
        }
    }
}
