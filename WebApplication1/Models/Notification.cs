using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models {
    public class Notification {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime creation_datetime { get; set; }
        public int parent { get; set; }
        public string Event { get; set; }   // TODO: Fix ;  lowercase event is reserved in C#
        public string endpoint { get; set; }
        public bool enabled { get; set; }
    }
}