﻿using SIMSWeb.Model.Models;

namespace SIMSWeb.Models.User
{
    public class AddUserModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }   

}
