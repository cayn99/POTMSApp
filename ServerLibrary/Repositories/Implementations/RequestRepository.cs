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
    public class RequestRepository(AppDbContext context) : IGenericRepositoryInterface<Request>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var request = await context.Requests.FindAsync(id);
            if (request == null)
                return NotFound();

            context.Requests.Remove(request);
            await Commit();
            return Success();
        }

        public async Task<List<Request>> GetAll() => await context.Requests.ToListAsync();
        public async Task<Request> GetById(int id) => await context.Requests.FindAsync(id);

        public async Task<GeneralResponse> Insert(Request item)
        {
            if (!await CheckRecordNumberExists(item.RecordNumber)) // Use RecordNumber to check uniqueness
                return new GeneralResponse(false, "Request with this record number already exists.");
            context.Requests.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Request item)
        {
            var request = await context.Requests.FindAsync(item.Id);
            if (request == null)
                return NotFound();
            request.RecordNumber = item.RecordNumber;
            request.Division = item.Division;
            request.ProjectCode = item.ProjectCode;
            request.FundSource = item.FundSource;
            request.DateReceived = item.DateReceived;
            request.RequestNumber = item.RequestNumber;
            request.RequestDate = item.RequestDate;
            request.OrderNumber = item.OrderNumber;
            request.OrderDate = item.OrderDate;
            request.Supplier = item.Supplier;
            request.Particulars = item.Particulars;
            request.Requestor = item.Requestor;
            request.Amount = item.Amount;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, request details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
        private async Task<bool> CheckRecordNumberExists(int recordNumber)
        {
            var item = await context.Requests.FirstOrDefaultAsync(x => x.RecordNumber == recordNumber);
            return item is null; // Returns true if no item is found (valid for insertion)
        }
    }
}
