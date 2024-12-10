using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace API.Models {
    public class EventNotification {
        public Record record { get; set; }
        public string @event { get; set; }

    }
}