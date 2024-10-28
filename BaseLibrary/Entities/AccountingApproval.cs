using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class AccountingApproval : BaseEntity
	{
			[Key]
			public int AccountingApprovalId { get; set; }
			public DateTime DateReceived { get; set; }
			public required string ReceivedBy { get; set; }
			public Status Status { get; set; }
			public decimal FirstPayment { get; set; }
			public decimal? SecondPayment { get; set; }
			public decimal? ThirdPayment { get; set; }
			public decimal? FourthPayment { get; set; }
			public int AccountingCompleteId { get; set; }
			public AccountingComplete? AccountingComplete { get; set; }
			public PurchaseOrder? PurchaseOrder { get; set; }
		}
	}

namespace BaseLibrary
{
	public enum Status
	{
		Paid, Unpaid, FullPayment, PartialPayment
	}
}