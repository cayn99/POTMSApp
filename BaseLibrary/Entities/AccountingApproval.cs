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
        [Required, DataType(DataType.DateTime)]
		public DateTime DateReceived { get; set; }
        [Required]
        public required string ReceivedBy { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal FirstPayment { get; set; } = 0m;
        [DataType(DataType.Currency)]
		public decimal? SecondPayment { get; set; } = 0m;
        [DataType(DataType.Currency)]
        public decimal? ThirdPayment { get; set; } = 0m;
        [DataType(DataType.Currency)]
        public decimal? FourthPayment { get; set; } = 0m;
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