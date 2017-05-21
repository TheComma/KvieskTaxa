/**
 * @(#) Call.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KvieskTaxa.Models
{
    public class Call
    {
        public int id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string state { get; set; }
        public int estimated_price { get; set; }
        public DateTime send_time { get; set; }
        public DateTime accept_time { get; set; }
        public DateTime finish_time { get; set; }
        public DateTime book_time { get; set; }
        public int passenger_count { get; set; }
        public bool child_seat { get; set; }
        public bool animals { get; set; }
        public bool smoking { get; set; }
        public string rating { get; set; }
        public string review { get; set; }
        public Client Client { get; set; }
        public bool baggage { get; set; }
        public ICollection<Driver> SentDrivers { get; set; }
        public Driver AcceptedDriver { get; set; }
    }
}