using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class Request : BaseEntity
	{
        [Required]
		public int RecordNumber { get; set; }
        [Required]
        public string Division { get; set; } = string.Empty;
        [Required]
        public string ProjectCode { get; set; } = string.Empty;
        [Required]
        public string FundSource { get; set; } = string.Empty;
        [Required, DataType(DataType.DateTime)]
        public DateTime DateReceived { get; set; }
        [Required]
        public int RequestNumber { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime RequestDate { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Supplier { get; set; } = string.Empty;
        [Required, DataType(DataType.Text)]
        public string Particulars { get; set; } = string.Empty;
        [Required]
        public string Requestor { get; set; } = string.Empty;
        [Required, DataType(DataType.Currency)]
        public decimal Amount { get; set; } = 0m;
		public PurchaseOrder? PurchaseOrder { get; set; }
	}
}
