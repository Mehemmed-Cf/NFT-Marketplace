using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.NFTsModule.Queries.NFTGetAllQuery
{
    public class NFTGetAllRequestDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Price { get; set; }
        public short HighestBid { get; set; }
        public string ImagePath { get; set; }
    }
}
