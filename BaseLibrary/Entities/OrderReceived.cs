using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class OrderReceived
	{
        public int Id { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime DateReceived { get; set; }
        public int DeliveryDays { get; set; }
        public byte[]? ExtensionLetterFile { get; set; }
        public string? ExtensionLetterFileName { get; set; }
        public int OrderDeliveryId { get; set; }
        [JsonIgnore]
        public OrderDelivery? OrderDelivery { get; set; }
        public int PurchaseRequestId { get; set; }
        [JsonIgnore]
        public PurchaseRequest? PurchaseRequest { get; set; }
    }
}
