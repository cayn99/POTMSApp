using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class PurchaseOrder
	{
        public int Id { get; set; }
        [Required, DataType(DataType.Text)]
        public string? Remarks { get; set; }
        [Required, DataType(DataType.Text)]
        public int RequestId { get; set; }
		public Request? Request { get; set; }
		public int OrderReceivedId { get; set; }
		public OrderReceived? OrderReceived { get; set; }
		public int AccountingCompleteId { get; set; }
		public AccountingComplete? AccountingComplete { get; set; }
		public int InspectionId { get; set; }
		public Inspection? Inspection { get; set; }
		public int CoaId { get; set; }
		public Coa? Coa { get; set; }
	}
}
