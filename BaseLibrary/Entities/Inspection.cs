using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class Inspection : BaseEntity
	{
		[Required]
        public IStatus Status { get; set; }
        public enum IStatus
        {
            Success, Failed
        }
        [Required, DataType(DataType.DateTime)]
        public DateTime DateInspected { get; set; }
        public required string Inspector { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime DateAccepted { get; set; }
        public required string AcceptedBy { get; set; }
		public PurchaseOrder? PurchaseOrder { get; set; }
	}
}