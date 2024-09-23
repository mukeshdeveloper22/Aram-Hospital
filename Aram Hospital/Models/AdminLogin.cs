using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aram_Hospital.Models
{
    public class AdminLogin
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Username is Required")]
        [StringLength(100)]
        public string Employee_Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(100)]
        public string Password { get; set; }
    }
}