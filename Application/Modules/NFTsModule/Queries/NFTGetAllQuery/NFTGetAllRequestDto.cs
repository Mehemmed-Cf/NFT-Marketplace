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
        public double Price { get; set; }
        public double HighestBid { get; set; }
        public string ImagePath { get; set; }
    }
}
