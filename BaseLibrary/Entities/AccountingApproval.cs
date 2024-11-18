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
        public AStatus Status { get; set; }
        public enum AStatus
        {
            Paid, Unpaid, FullPayment, PartialPayment
        }

        [Required, DataType(DataType.Currency)]
        public decimal FirstPayment { get; set; } = 0m;
        [DataType(DataType.Currency)]
		public decimal? SecondPayment { get; set; } = 0m;
        [DataType(DataType.Currency)]
        public decimal? ThirdPayment { get; set; } = 0m;
        [DataType(DataType.Currency)]
        public decimal? FourthPayment { get; set; } = 0m;
		public AccountingComplete? AccountingComplete { get; set; }
		}
	}