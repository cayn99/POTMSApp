using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class OrderReceived
	{
        public int Id { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime DateReceived { get; set; }
        public int DeliveryDays { get; set; }
        public string? ExtensionLetterFileName { get; set; }
        public byte[]? ExtensionLetterContent { get; set; } // Optional: to store the file content
        public int OrderDeliveryId { get; set; }
        public OrderDelivery? OrderDelivery { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
    }
}
