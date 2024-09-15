﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException()
            : base("Username or Password is incorrect")
        {
        }
    }
}