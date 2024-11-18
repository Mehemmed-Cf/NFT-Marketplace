using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.NFTsModule.Commands.NFTEditCommand
{
    public class NFTEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Price { get; set; }
        public short HighestBid { get; set; }
        public IFormFile NFTImage { get; set; }
        public int CreatorId { get; set; }
    }
}
