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
    public class FollowRepository : AsyncRepository<Follow>//, IFollowRepository
    {
        private readonly DbContext db;

        public FollowRepository(DbContext db) : base(db)
        {
            this.db = db;
        }

        //public async Task<Follow> GetFollowAsync(string userId, int creatorId, CancellationToken cancellationToken = default)
        //{
        //    return await db.Follows.FirstOrDefaultAsync(f => f.UserId == userId && f.CreatorId == creatorId, cancellationToken);
        //}

        //public Task<int> GetFollowerCountAsync(int creatorId, CancellationToken cancellationToken = default)
        //{
        //    //return await _dbContext.Follows.CountAsync(f => f.CreatorId == creatorId, cancellationToken);
        //}
    }
}
