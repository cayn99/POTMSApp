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
    public class OrderDeliveryRepository(AppDbContext context) : IGenericRepositoryInterface<OrderDelivery>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var orderDelivery = await context.OrderDeliveries.FindAsync(id);
            if (orderDelivery == null)
                return NotFound();

            context.OrderDeliveries.Remove(orderDelivery);
            await Commit();
            return Success();
        }

        public async Task<List<OrderDelivery>> GetAll() => await context.OrderDeliveries.ToListAsync();
        public async Task<OrderDelivery> GetById(int id) => await context.OrderDeliveries.FindAsync(id);

        public async Task<GeneralResponse> Insert(OrderDelivery item)
        {
            context.OrderDeliveries.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(OrderDelivery item)
        {
            var orderDelivery = await context.OrderDeliveries.FindAsync(item.Id);
            if (orderDelivery == null)
                return NotFound();
            orderDelivery.Schedule = item.Schedule;
            orderDelivery.Conforme = item.Conforme;
            orderDelivery.Deadline = item.Deadline;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry, delivery details not found");
        private static GeneralResponse Success() => new(true, "Process completed!");
        private async Task Commit() => await context.SaveChangesAsync();
    }
}
