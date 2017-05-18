/**
 * @(#) Administrator.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KvieskTaxa.Models
{
    public class Administrator : User
    {
        public int id { get; set; }
        public string email { get; set; }

    }
}