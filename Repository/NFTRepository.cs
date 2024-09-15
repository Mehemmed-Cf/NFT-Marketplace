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
    public class NFTRepository : AsyncRepository<NFT>, INFTRepository
    {
        public NFTRepository(DbContext db) : base(db)
        {
            
        }
    }
}
