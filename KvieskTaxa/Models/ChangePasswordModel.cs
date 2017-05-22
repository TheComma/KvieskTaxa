using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KvieskTaxa.Models
{
    public class ChangePasswordModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Būtina įvesti vartotojo slaptažodį")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Būtina įvesti naują slaptažodį")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "{0} turi būti bent {2} simbolių ilgio.", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Būtina pakartotinai įvesti naują slaptažodį")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Slaptažodžiai nesutampa")]
        public string ConfirmPassword { get; set; }
    }
}