using Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.NFTsModule.Commands.NFTAddCommand
{
    public class NFTAddRequest : IRequest<NFTAddRequestDto>
    {
        public string Title { get; set; }
        public string Description{ get; set; }
        public short Price { get; set; }
        public short HighestBid { get; set; }
        public IFormFile Image { get; set; }
        public int CreatorId { get; set; }
    }
}
