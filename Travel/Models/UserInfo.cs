using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class UserInfo
    {
        public int ID { get; set; }

        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "User Profile Pic")]
        public string Image { get; set; }
        public string UserRole { get; set; }


    }
}