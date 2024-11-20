using BaseLibrary.Entities;
using ClientLibrary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Services.Implementations
{
    public class OrderService : IOrderService
    {
        public bool IsOrderDeliveryComplete(int orderDeliveryId)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderReceived> TransferDataToOrderReceived(int orderDeliveryId, DateTime dateReceived, string confirmationStatus, string? extensionLetterFileName, byte[]? extensionLetterContent)
        {
            throw new NotImplementedException();
        }
    }
}
