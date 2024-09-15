using Infrastructure.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class NFT : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Price { get; set; }
        public string ImagePath { get; set; }
        public int PostedBy { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
