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
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Request details already added");
            context.Requests.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Request item)
        {
            var request = await context.Requests.FindAsync(item.Id);
            if (request == null) 
                return NotFound();
            request.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, request details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await context.Requests.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
