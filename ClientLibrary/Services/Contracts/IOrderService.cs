using BaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Services.Contracts
{
    public interface IOrderService
    {
        public bool IsOrderDeliveryComplete(int orderDeliveryId);
        Task<OrderReceived> TransferDataToOrderReceived(int orderDeliveryId, DateTime dateReceived,
            string confirmationStatus, string? extensionLetterFileName, byte[]? extensionLetterContent);

    }
}
