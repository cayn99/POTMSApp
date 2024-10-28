using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class AccountingComplete : BaseEntity
	{
		[Key]
		public int AccountingCompleteId { get; set; }
		public bool Cancelled { get; set; }
		public decimal Amount { get; set; }
		public decimal Balance { get; set; }
		public bool Penalty { get; set; }
		public AccountingApproval? AccountingApproval { get; set; }
	}
}
