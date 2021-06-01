﻿using System;
using System.Collections.Generic;
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
        public byte[] Image { get; set; }
        public int UserRole { get; set; }

    }
}