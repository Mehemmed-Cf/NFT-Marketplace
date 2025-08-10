using Domain.Models.Entities;
using Infrastructure.Abstracts;

namespace Application.Repositories
{
    public interface IFollowRepository : IAsyncRepository<Follow>
    {
        Task<Follow> GetFollowAsync(string userId, int creatorId, CancellationToken cancellationToken = default);
        Task<int> GetFollowerCountAsync(int creatorId, CancellationToken cancellationToken = default);
    }
}
