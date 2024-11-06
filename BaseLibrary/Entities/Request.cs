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
		[Key]
		public int RecordNumber { get; set; }
		public new required string Division { get; set; } = string.Empty;
        public required string ProjectCode { get; set; } = string.Empty;
        public required string FundSource { get; set; } = string.Empty;
        public DateTime DateReceived { get; set; }
		public int RequestNumber { get; set; }
		public DateTime RequestDate { get; set; }
		public int OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }
		public required string Supplier { get; set; } = string.Empty;
        public required string Particulars { get; set; } = string.Empty;
        public required string Requestor { get; set; } = string.Empty;
        public decimal Amount { get; set; }
		public PurchaseOrder? PurchaseOrder { get; set; }
	}
}
