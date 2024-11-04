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
		public new required string Division { get; set; }
		public required string ProjectCode { get; set; }
		public required string FundSource { get; set; }
		public DateTime DateReceived { get; set; }
		public int RequestNumber { get; set; }
		public DateTime RequestDate { get; set; }
		public int OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }
		public required string Supplier { get; set; }
		public required string Particulars { get; set; }
		public required string Requestor { get; set; }
		public decimal Amount { get; set; }
		public PurchaseOrder? PurchaseOrder { get; set; }
	}
}
