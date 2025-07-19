using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.NFTsModule.Commands.NFTAddCommand
{
    public class NFTAddRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double HighestBid { get; set; }
        public string ImagePath { get; set; }
        public int CreatorId { get; set; }
    }
}
