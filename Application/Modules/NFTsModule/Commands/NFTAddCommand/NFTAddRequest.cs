using Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.NFTsModule.Commands.NFTAddCommand
{
    public class NFTAddRequest : IRequest<NFTAddRequestDto>
    {
        public string Title { get; set; }
        public string Description{ get; set; }
        public double Price { get; set; }
        public double HighestBid { get; set; }
        public IFormFile Image { get; set; }
        public int CreatorId { get; set; }
    }
}
