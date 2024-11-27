using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    public class OrderReceivedDto
    {
        public int OrderDeliveryId { get; set; }
        public DateTime DateReceived { get; set; }
        public string? ExtensionLetterFileName { get; set; }
        public byte[]? ExtensionLetterContent { get; set; }
    }
}
