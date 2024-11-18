using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Queries.CreatorGetAllQuery
{
    public class CreatorGetAllRequestDto
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string ChainId { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public int Followers { get; set; }
        public int Volume { get; set; }
        public int SoldNFts { get; set; }
        public string ImagePath { get; set; }
    }
}
