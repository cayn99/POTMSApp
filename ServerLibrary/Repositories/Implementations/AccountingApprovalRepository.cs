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

        public async Task<List<AccountingApproval>> GetAll() => await context.AccountingApprovals.AsNoTracking().Include(aa => aa.AccountingComplete)
        .ThenInclude(ac => ac.PurchaseRequest) // Load PurchaseRequest
        .ToListAsync();
        public async Task<AccountingApproval> GetById(int id) => await context.AccountingApprovals.FindAsync(id);

        public async Task<GeneralResponse> Insert(AccountingApproval item)
        {
            context.AccountingApprovals.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(AccountingApproval item)
        {
            var accountingApproval = await context.AccountingApprovals.FindAsync(item.Id);
            if (accountingApproval == null)
                return NotFound();
            accountingApproval.DateReceived = item.DateReceived;
            accountingApproval.ReceivedBy = item.ReceivedBy;
            accountingApproval.Status = item.Status;
            accountingApproval.FirstPayment = item.FirstPayment;
            accountingApproval.SecondPayment = item.SecondPayment;
            accountingApproval.ThirdPayment = item.ThirdPayment;
            accountingApproval.FourthPayment = item.FourthPayment;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, approval details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
    }
}
