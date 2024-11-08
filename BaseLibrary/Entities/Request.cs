using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class Request : BaseEntity
	{
		public int RecordNumber { get; set; }
		public required string Division { get; set; } = string.Empty;
        public required string ProjectCode { get; set; } = string.Empty;
        public required string FundSource { get; set; } = string.Empty;
        [Required, DataType(DataType.DateTime)]
        public DateTime DateReceived { get; set; }
		public int RequestNumber { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime RequestDate { get; set; }
		public int OrderNumber { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
		public required string Supplier { get; set; } = string.Empty;
        [Required, DataType(DataType.Text)]
        public string Particulars { get; set; } = string.Empty;
        public required string Requestor { get; set; } = string.Empty;
        [Required, DataType(DataType.Currency)]
        public decimal Amount { get; set; }
		public PurchaseOrder? PurchaseOrder { get; set; }
	}
}
