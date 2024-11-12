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
            var orderReceived = await context.OrderReceived.FindAsync(id);
            if (orderReceived == null)
                return NotFound();

            context.OrderReceived.Remove(orderReceived);
            await Commit();
            return Success();
        }

        public async Task<List<OrderReceived>> GetAll() => await context.OrderReceived.ToListAsync();
        public async Task<OrderReceived> GetById(int id) => await context.OrderReceived.FindAsync(id);

        public async Task<GeneralResponse> Insert(OrderReceived item)
        {
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Order details already added");
            context.OrderReceived.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(OrderReceived item)
        {
            var orderReceived = await context.OrderReceived.FindAsync(item.Id);
            if (orderReceived == null)
                return NotFound();
            orderReceived.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, order details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await context.OrderReceived.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals
            (name.ToLower()));
            return item is null;
        }
    }
}
