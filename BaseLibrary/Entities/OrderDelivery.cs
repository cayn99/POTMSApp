using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class OrderDelivery : BaseEntity
	{
		[Key]
		public int OrderDeliveryId { get; set; }
		public DateTime Schedule { get; set; }
		public DateTime Conforme { get; set; }
		public DateTime Deadline { get; set; }
		public int OrderReceivedId { get; set; }
		public OrderReceived? OrderReceived { get; set; }
		public PurchaseOrder? PurchaseOrder { get; set; }
	}
}
