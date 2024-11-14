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
        [Required, DataType(DataType.DateTime)]
        public DateTime DateReceived { get; set; }
        public int DeliveryDays => (DateReceived - OrderDelivery.Schedule).Days;
		public bool ExtensionLetter { get; set; }
		public OrderDelivery? OrderDelivery { get; set; }
	}
}
