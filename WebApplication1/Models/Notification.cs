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
        public string @event { get; set; }   
        public string endpoint { get; set; }
        public bool enabled { get; set; }
    }
}