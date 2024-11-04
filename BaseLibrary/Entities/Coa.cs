using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class Coa : BaseEntity
	{
		[Key]
		public int CoaId { get; set; }
		public DateTime OrderCopy { get; set; }
		public required string ReceivedBy { get; set; }
		public DateTime InspectionRequest { get; set; }
		public required string InspectionReceivedBy { get; set; }
		public PurchaseOrder? PurchaseOrder { get; set; }
	}
}
