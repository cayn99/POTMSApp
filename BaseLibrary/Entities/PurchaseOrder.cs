using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string? Supplier { get; set; }
        public string? Address { get; set; }
        public string? Tin { get; set; }
        [DisplayName("Purchase Order Number")]
        public string? PoNumber { get; set; }
        public DateOnly Date { get; set; }
        public string? Procurement { get; set; }
        public string? DeliveryPlace { get; set; }
        public string? DeliveryTerm { get; set; }
        public string? PaymentTerm { get; set; }
        [DisplayName("Date of Delivery")]
        public int DeliveryDays { get; set; }
        [Required, DataType(DataType.Text)]
        public string? Remarks { get; set; }
        public int PurchaseRequestId { get; set; }
        [JsonIgnore]
        public PurchaseRequest? PurchaseRequest { get; set; }
        
    }
}
