using Infrastructure.Concrates;

namespace Domain.Models.Entities
{
    public class Subscriber : AuditableEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
