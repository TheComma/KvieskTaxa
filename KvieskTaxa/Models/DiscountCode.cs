/**
 * @(#) DiscountCode.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KvieskTaxa.Models
{
    public class DiscountCode
    {
        public int id { get; set; }
        public string code { get; set; }
        public Discount Discount { get; set; }
        public Client Client { get; set; }

    }
}