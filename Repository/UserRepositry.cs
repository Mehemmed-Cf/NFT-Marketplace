using Application.Repositories;
using Domain.Models.Entities;
using Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepositry : AsyncRepository<User>, IUserRepository
    {
        public UserRepositry(DbContext db) : base(db)
        { 
        
        }
    }
}
