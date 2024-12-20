﻿using BaseLibrary.Entities;
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
            var coa = await context.AllCoa!.FindAsync(id);
            if (coa == null)
                return NotFound();

            context.AllCoa.Remove(coa);
            await Commit();
            return Success();
        }

        public async Task<List<Coa>> GetAll() => await context.AllCoa!.AsNoTracking().Include(c => c.PurchaseRequest).ToListAsync();
        public async Task<Coa> GetById(int id) => await context.AllCoa.FindAsync(id);

        public async Task<GeneralResponse> Insert(Coa item)
        {
            context.AllCoa.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Coa item)
        {
            var coa = await context.AllCoa!.FindAsync(item.Id);
            if (coa == null)
                return NotFound();
            coa.PurchaseRequestId = item.PurchaseRequestId;
            coa.OrderCopy = item.OrderCopy;
            coa.ReceivedBy = item.ReceivedBy;
            coa.InspectionRequest = item.InspectionRequest;
            coa.InspectionReceivedBy = item.InspectionReceivedBy;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, coa details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
    }
}
