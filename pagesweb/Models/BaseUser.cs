using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pagesweb.Models
{
    public class BaseUser
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "is required.")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "is required.")]
        public string LastName { get; set; }

        [RegularExpression(@"^([\w]+)@([\w]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}$",
            ErrorMessage = "Please enter a valid email address or phone number")]
       // [System.ComponentModel.DefaultValue("")]
          public virtual string MobileOrEmail { get; set; } = "";


        public virtual DateTime? Birthday { get; set; }
        public virtual  DateTime? RegistrDate { get;  }
        [Required(ErrorMessage = "is required.")]
        public virtual string Gender { get; set; }

    }
}
