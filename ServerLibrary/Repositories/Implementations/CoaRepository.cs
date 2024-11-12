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
    public class CoaRepository(AppDbContext context) : IGenericRepositoryInterface<Coa>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var coa = await context.Coa.FindAsync(id);
            if (coa == null)
                return NotFound();

            context.Coa.Remove(coa);
            await Commit();
            return Success();
        }

        public async Task<List<Coa>> GetAll() => await context.Coa.ToListAsync();
        public async Task<Coa> GetById(int id) => await context.Coa.FindAsync(id);

        public async Task<GeneralResponse> Insert(Coa item)
        {
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Coa details already added");
            context.Coa.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Coa item)
        {
            var coa = await context.Coa.FindAsync(item.Id);
            if (coa == null)
                return NotFound();
            coa.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, coa details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await context.Coa.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
