/**
 * @(#) Driver.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KvieskTaxa.Models
{
    public class Driver : User
    {
        public string state { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int number_of_seats { get; set; }
        public bool child_seat { get; set; }
        public bool animals { get; set; }
        public Tariff Tariff { get; set; }
        public ICollection<Call> Calls { get; set; }
        public ICollection<Call> AcceptedCalls { get; set; }
        public bool smoking { get; set; }

    }
}