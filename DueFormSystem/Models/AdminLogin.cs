using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DueFormSystem.Models
{
    public class AdminLogin
    {
        [Required(ErrorMessage ="Mandatory Field")]
        [Display(Name ="Admin Name: ")]
        public string AdminName { get; set; }

        [Required(ErrorMessage ="Mandatory Field")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}