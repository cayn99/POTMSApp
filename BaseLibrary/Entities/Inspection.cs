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
		[Key]
		public int InspectionId { get; set; }
		public IStatus Status { get; set; }
		public DateTime DateInspected { get; set; }
		public required string Inspector { get; set; }
		public DateTime DateAccepted { get; set; }
		public required string AcceptedBy { get; set; }
		public PurchaseOrder? PurchaseOrder { get; set; }
	}
}

namespace BaseLibrary
{
	public enum IStatus
	{
		Success, Failed
	}
}