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
    public class InspectionRepository(AppDbContext context) : IGenericRepositoryInterface<Inspection>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var inspection = await context.Inspections.FindAsync(id);
            if (inspection == null)
                return NotFound();

            context.Inspections.Remove(inspection);
            await Commit();
            return Success();
        }

        public async Task<List<Inspection>> GetAll() => await context.Inspections.ToListAsync();
        public async Task<Inspection> GetById(int id) => await context.Inspections.FindAsync(id);

        public async Task<GeneralResponse> Insert(Inspection item)
        {
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Inspection details already added");
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Inspection item)
        {
            var inspection = await context.Inspections.FindAsync(item.Id);
            if (inspection == null)
                return NotFound();
            inspection.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, inspection details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await context.Inspections.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
