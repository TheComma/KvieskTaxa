/**
 * @(#) Tariff.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KvieskTaxa.Models
{
    public class Tariff
    {
        public int id { get; set; }
        public int isedimo_kaina { get; set; }
        public int kilometer_price { get; set; }
        public string valid_from { get; set; }
        public string valid_to { get; set; }
        Driver Driver { get; set; }

    }
}