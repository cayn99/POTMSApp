using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class Coa
	{
        public int Id { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime OrderCopy { get; set; }
        public required string ReceivedBy { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime InspectionRequest { get; set; }
        public required string InspectionReceivedBy { get; set; }
		public PurchaseOrder? PurchaseOrder { get; set; }
	}
}
