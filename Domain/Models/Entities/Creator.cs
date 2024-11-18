using Infrastructure.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class Creator : AuditableEntity
    {
        public int Id { get; set; }
        public string ChainId { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public int Followers { get; set; }
        public int Volume { get; set; }
        public int SoldNFts { get; set; }
        public string ImagePath { get; set; }
    }
}
