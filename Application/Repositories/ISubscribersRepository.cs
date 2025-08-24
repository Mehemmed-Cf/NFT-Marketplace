﻿using Domain.Models.Entities;
using Infrastructure.Abstracts;

namespace Application.Repositories
{
    public interface ISubscribersRepository : IAsyncRepository<Subscriber>
    {
    }
}
