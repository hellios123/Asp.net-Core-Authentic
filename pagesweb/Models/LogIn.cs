using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pagesweb.Models
{
    public class LogIn
    {
        [RegularExpression(@"^([\w]+)@([\w]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}$",
            ErrorMessage = "Please enter a valid email address or phone number")]
        [Required(ErrorMessage = "is required.")]
        public  string MobileOrEmail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "is required.")]
        public string Password { get; set; }
    }
}
