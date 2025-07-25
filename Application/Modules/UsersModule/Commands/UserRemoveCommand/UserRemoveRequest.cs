﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.UsersModule.Commands.UserRemoveCommand
{
    public class UserRemoveRequest : IRequest
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; }
    }
}
