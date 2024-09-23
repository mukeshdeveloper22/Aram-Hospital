using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.Specialized;

namespace Aram_Hospital.Models
{
    public class BookAppointment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        
        public DateTime Date { get; set; }


        
        [Display(Name = "Mobile_Number")]
        [Required(ErrorMessage = "Mobile Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Mobile_Number { get; set; }

        public string Email { get; set; }

        
    }
}