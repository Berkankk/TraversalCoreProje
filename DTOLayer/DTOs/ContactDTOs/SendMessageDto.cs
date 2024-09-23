using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ContactDTOs
{
    public class SendMessageDto
    {
        public string Description { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Map { get; set; }
        public string MessageBody { get; set; }
        public string Subject { get; set; }
        public string Name { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
