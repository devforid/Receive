using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class ChatThread
    {
        public string _id { get; set; }
        public Guid ThreadId { get; set; }
        public string CreatorId { get; set; }
        public string CreatorUsername { get; set; }
        public List<string> ReceipientsId { get; set; }
        public bool Active { get; set; }


    }
}
