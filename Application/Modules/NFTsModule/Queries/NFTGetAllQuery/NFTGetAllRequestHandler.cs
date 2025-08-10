using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.NFTsModule.Queries.NFTGetAllQuery
{
    public class NFTGetAllRequestHandler : IRequestHandler<NFTGetAllRequest, IEnumerable<NFTGetAllRequestDto>>
    {
        private readonly INFTRepository nFTRepository;
        private readonly IActionContextAccessor ctx;

        public NFTGetAllRequestHandler(INFTRepository nFTRepository, IActionContextAccessor ctx)
        {
            this.nFTRepository = nFTRepository;
            this.ctx = ctx;
        }

        public async Task<IEnumerable<NFTGetAllRequestDto>> Handle(NFTGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = nFTRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            var queryResponse = await query.Select(m => new NFTGetAllRequestDto
            {
                Id = m.Id,
                CreatorId = m.CreatorId,
                Title = m.Title,
                Description = m.Description,
                Price = m.Price,
                HighestBid = m.HighestBid,
                ImagePath = $"{host}/uploads/images/{m.ImagePath}",
            }).ToListAsync(cancellationToken);

            return queryResponse;
        }
    }
}
