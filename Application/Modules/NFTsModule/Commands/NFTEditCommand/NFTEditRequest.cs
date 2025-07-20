using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Modules.NFTsModule.Commands.NFTEditCommand
{
    public class NFTEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double HighestBid { get; set; }
        public IFormFile NFTImage { get; set; }
        public int CreatorId { get; set; }
    }
}
