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
    public class AccountingApprovalRepository(AppDbContext context) : IGenericRepositoryInterface<AccountingApproval>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var accountingApproval = await context.AccountingApprovals.FindAsync(id);
            if (accountingApproval == null)
                return NotFound();

            context.AccountingApprovals.Remove(accountingApproval);
            await Commit();
            return Success();
        }

        public async Task<List<AccountingApproval>> GetAll() => await context.AccountingApprovals.ToListAsync();
        public async Task<AccountingApproval> GetById(int id) => await context.AccountingApprovals.FindAsync(id);

        public async Task<GeneralResponse> Insert(AccountingApproval item)
        {
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Approval details already added");
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(AccountingApproval item)
        {
            var accountingApproval = await context.AccountingApprovals.FindAsync(item.Id);
            if (accountingApproval == null)
                return NotFound();
            accountingApproval.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, approval details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await context.AccountingApprovals.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
