using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
	public class OrderDelivery
	{
        public int Id { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Schedule { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Conforme { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }
        [JsonIgnore]
        public OrderReceived? OrderReceived { get; set; }


    }
}
