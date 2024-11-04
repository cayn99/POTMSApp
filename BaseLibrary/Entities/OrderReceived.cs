using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class OrderReceived : BaseEntity
	{
		[Key]
		public int OrderReceivedId { get; set; }
		public DateTime DateReceived { get; set; }
		public int DeliveryDays { get; set; }
		public bool ExtensionLetter { get; set; }
		public OrderDelivery? OrderDelivery { get; set; }
	}
}
