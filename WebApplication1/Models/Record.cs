using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models {
    public class Record {
        public int id { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public DateTime creation_datetime { get; set; }
        public int parent { get; set; }
    }
}