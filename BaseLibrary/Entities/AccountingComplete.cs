﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class AccountingComplete
	{
        public int Id { get; set; }
        public bool Cancelled { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal Amount { get; set; } = 0m;
        [Required, DataType(DataType.Currency)]
        public decimal Balance { get; set; } = 0m;
        public bool Penalty { get; set; }
        public int AccountingApprovalId { get; set; }
        [JsonIgnore]
        public AccountingApproval? AccountingApproval { get; set; }
        public int PurchaseRequestId { get; set; }
        [JsonIgnore]
        public PurchaseRequest? PurchaseRequest { get; set; }
    }
}
