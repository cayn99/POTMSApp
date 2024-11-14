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
            context.Inspections.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Inspection item)
        {
            var inspection = await context.Inspections.FindAsync(item.Id);
            if (inspection == null)
                return NotFound();
            inspection.Status = item.Status;
            inspection.DateInspected = item.DateInspected;
            inspection.Inspector = item.Inspector;
            inspection.DateAccepted = item.DateAccepted;
            inspection.AcceptedBy = item.AcceptedBy;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, inspection details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
    }
}
