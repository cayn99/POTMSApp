using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    public class BaseRequestDTO
    {
        [Display(Name = "Record Number")]
        [Required(ErrorMessage = "Record Number is required.")]
        public int RecordNumber { get; set; }
        [Required(ErrorMessage = "Division is required.")]
        public string? Division { get; set; }
        [Display(Name = "Project Code")]
        [Required(ErrorMessage = "Project code is required.")]
        public string? ProjectCode { get; set; }
        [Display(Name = "Fund Source")]
        [Required(ErrorMessage = "Fund Source is required.")]
        public string? FundSource { get; set; }
        [Display(Name = "Date Received")]
        [Required(ErrorMessage = "Date Received is required.")]
        public DateTime DateReceived { get; set; }
        [Display(Name = "Request Number")]
        [Required(ErrorMessage = "Request Number is required.")]
        public int RequestNumber { get; set; }
        [Display(Name = "Date of Request")]
        [Required(ErrorMessage = "Date of Request is required.")]
        public DateTime RequestDate { get; set; }
        [Display(Name = "Order Number")]
        [Required(ErrorMessage = "Order Number is required.")]
        public int OrderNumber { get; set; }
        [Display(Name = "Date of Order")]
        [Required(ErrorMessage = "Date of Order is required.")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Supplier is required.")]
        public string? Supplier { get; set; }
        [Required(ErrorMessage = "Particulars are required.")]
        public string? Particulars { get; set; }
        [Required(ErrorMessage = "Requestor is required.")]
        public string? Requestor { get; set; }
        [Required(ErrorMessage = "Amount is required.")]
        public int Amount { get; set; }
    }
}
