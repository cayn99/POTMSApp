using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class BaseEntity
	{
        public int Id { get; set; }
        public string? Division { get; set; }

        [JsonIgnore]
        public List<PurchaseOrder>? PurchaseOrders { get; set; }
    }
}
