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
    public class OrderReceivedRepository(AppDbContext context) : IGenericRepositoryInterface<OrderReceived>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var orderReceived = await context.OrdersReceived.FindAsync(id);
            if (orderReceived == null)
                return NotFound();

            context.OrdersReceived.Remove(orderReceived);
            await Commit();
            return Success();
        }

        public async Task<List<OrderReceived>> GetAll() => await context.OrdersReceived.ToListAsync();
        public async Task<OrderReceived> GetById(int id) => await context.OrdersReceived.FindAsync(id);

        public async Task<GeneralResponse> Insert(OrderReceived item)
        {
            context.OrdersReceived.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(OrderReceived item)
        {
            var orderReceived = await context.OrdersReceived.FindAsync(item.Id);
            if (orderReceived == null)
                return NotFound();
            orderReceived.DateReceived = item.DateReceived;
            orderReceived.ExtensionLetterFileName = item.ExtensionLetterFileName;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, order details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
    }
}
