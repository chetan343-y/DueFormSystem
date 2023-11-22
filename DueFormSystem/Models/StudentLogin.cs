using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DueFormSystem.Models
{
    public class StudentLogin
    {
        [Required(ErrorMessage = "Mandatory Field")]
        [Display(Name = "Student PRN NO.: ")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}