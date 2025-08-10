
using Infrastructure.Concrates;

namespace Domain.Models.Entities
{
    public class Follow : AuditableEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CreatorId { get; set; }
        public DateTime FollowedAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; }
        public Creator Creator { get; set; }
    }
}
