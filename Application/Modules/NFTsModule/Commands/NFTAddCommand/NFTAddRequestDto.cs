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
        public short Price { get; set; }
        public short HighestBid { get; set; }
        public string ImagePath { get; set; }
        public int CreatorId { get; set; }
    }
}
