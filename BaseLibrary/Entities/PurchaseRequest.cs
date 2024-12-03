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
	public class PurchaseRequest
    {
        public int Id { get; set; }
        [DisplayName("Purchase Request Number")]
        public string? PrNumber { get; set; }
        public string? Division { get; set; }
        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }
        [DataType(DataType.Text), DisplayName("Item Description")]
        public string? Particulars { get; set; }
        public Unit UnitType { get; set; }
        public enum Unit
        {
            Gallon, Piece, Pack, Bottle, Roll
        }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public decimal UnitCost { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalCost { get; set; }
        public string? DeliveryTerm { get; set; }
        public string? DeliveryArea { get; set; }
        [DataType(DataType.Text)]
        public string? Purpose { get; set; }
        [DataType(DataType.Text)]
        public string? ProjectTitle { get; set; }
        public string? ProjectCode { get; set; }
        public string? Requestor { get; set; }

        [JsonIgnore]
        public OrderReceived? OrderReceived { get; set; }
        [JsonIgnore]
        public AccountingComplete? AccountingComplete { get; set; }
        [JsonIgnore]
        public PurchaseOrder? PurchaseOrder { get; set; }
        [JsonIgnore]
        public Coa? Coa { get; set; }
        [JsonIgnore]
        public Inspection? Inspection { get; set; }
    }
}
