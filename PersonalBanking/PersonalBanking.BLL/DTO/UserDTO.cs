﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model;

namespace PersonalBanking.BLL.DTO
{
    public class UserDTO : EntityBaseDTO
    {
        public int Id{ get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public PersonDTO Person { get; set; }
    }
}
