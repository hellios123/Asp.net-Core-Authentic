using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pagesweb.Models
{
    public class AppUser: BaseUser
    {
        
        [RegularExpression(@"^([\w]+)@([\w]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}$", 
            ErrorMessage = "Please enter a valid email address or phone number")]
            [Required(ErrorMessage = "is required.")]
        public override string MobileOrEmail { get; set; }

        [DataType(DataType.Password)]
        [ Required(ErrorMessage = "is required.")]
        public string Password { get; set; }

        [ Required(ErrorMessage = "is required.")]
        [DataType(DataType.Date)]
        public override DateTime? Birthday { get; set; }
        public override DateTime? RegistrDate
        {
            get => DateTime.Now;
        }
        [Required(ErrorMessage = "is required.")]
        public override string Gender { get; set; }
        // public Boolean IsLogedIn { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public ICollection<Friend> Friends { get; set; }
    }
    
}
