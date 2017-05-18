/**
 * @(#) Client.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KvieskTaxa.Models
{
    public class Client : User
    {
        public int id { get; set; }
        public string email { get; set; }
        public Call Call { get; set; }
        public DiscountCode DiscountCode { get; set; }

    }
}