using Application.Repositories;
using Infrastructure.Concrates;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class CreatorRepository : AsyncRepository<Creator>, ICreatorRepository
    {
        public CreatorRepository(DbContext db) : base(db)
        {
            
        }
    }
}
