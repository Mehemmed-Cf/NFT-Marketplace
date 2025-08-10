using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Application.Modules.NFTsModule.Queries.NFTGetByIdQuery
{
    public class NFTGetByIdRequestHandler : IRequestHandler<NFTGetByIdRequest, NFTGetByIdRequestDto>
    {
        private readonly INFTRepository nFTRepository;
        private readonly IActionContextAccessor ctx;

        public NFTGetByIdRequestHandler(INFTRepository nFTRepository, IActionContextAccessor ctx)
        {
            this.nFTRepository = nFTRepository;
            this.ctx = ctx;
        }

        public async Task<NFTGetByIdRequestDto> Handle(NFTGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await nFTRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            return new NFTGetByIdRequestDto
            {
                Id = entity.Id,
                CreatorId = entity.CreatorId,
                Title = entity.Title,
                Description = entity.Description,
                Price = entity.Price,
                HighestBid = entity.HighestBid,
                ImagePath = $"{host}/uploads/images/{entity.ImagePath}",
            };

        }
    }
}
