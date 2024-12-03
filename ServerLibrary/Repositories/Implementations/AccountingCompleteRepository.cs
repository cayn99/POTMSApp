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
    public class AccountingCompleteRepository(AppDbContext context) : IGenericRepositoryInterface<AccountingComplete>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var accountingComplete = await context.AllAccountingComplete.FindAsync(id);
            if (accountingComplete == null)
                return NotFound();

            context.AllAccountingComplete.Remove(accountingComplete);
            await Commit();
            return Success();
        }

        public async Task<List<AccountingComplete>> GetAll() => await context.AllAccountingComplete.AsNoTracking().
            Include(aa => aa.AccountingApproval).ToListAsync();
        public async Task<AccountingComplete> GetById(int id) => await context.AllAccountingComplete.FindAsync(id);

        public async Task<GeneralResponse> Insert(AccountingComplete item)
        {
            context.AllAccountingComplete.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(AccountingComplete item)
        {
            var accountingComplete = await context.AllAccountingComplete.FindAsync(item.Id);
            if (accountingComplete == null)
                return NotFound();
            accountingComplete.Cancelled = item.Cancelled;
            accountingComplete.Amount = item.Amount;
            accountingComplete.Balance = item.Balance;
            accountingComplete.Penalty = item.Penalty;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, accounting details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
    }
}
