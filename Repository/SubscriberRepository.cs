using Application.Repositories;
using Domain.Models.Entities;
using Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SubscriberRepository : AsyncRepository<Subscriber>, ISubscribersRepository
    {
        public SubscriberRepository(DbContext db) : base(db)
        {
        }
    }
}
