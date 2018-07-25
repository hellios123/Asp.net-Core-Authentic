using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pagesweb.Models
{
    public class AppIdentUser: IdentityUser
    {
        

        [Required(ErrorMessage = "is required.")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "is required.")]
        public string LastName { get; set; }

        
        // [System.ComponentModel.DefaultValue("")]
        
        [Required(ErrorMessage = "is required.")]
        [RegularExpression(@"^([\w]+)@([\w]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}$",
            ErrorMessage = "Please enter a valid email address or phone number")]
        public  string MobileOrEmail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "is required.")]
        [DataType(DataType.Date)]
        public  DateTime? Birthday { get; set; }
        public  DateTime? RegistrDate
        {
            get => DateTime.Now;
        }
        [Required(ErrorMessage = "is required.")]
        public  string Gender { get; set; }
        // public Boolean IsLogedIn { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = new byte[100];

       public ICollection<Friend> Friends { get; set; } = new List<Friend>() { };

    }
}
