using Application.Repositories;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.NFTsModule.Queries.FilterNftByCreatorIdQuery
{
    class FilterNftByCreatorIdRequestHandler : IRequestHandler<FilterNftByCreatorIdRequest, IEnumerable<FilterNftByCreatorIdRequestDto>>
    {
        private readonly INFTRepository nFTRepository;
        private readonly IActionContextAccessor ctx;

        public FilterNftByCreatorIdRequestHandler(INFTRepository nFTRepository, IActionContextAccessor ctx)
        {
            this.nFTRepository = nFTRepository;
            this.ctx = ctx;
        }

        public async Task<IEnumerable<FilterNftByCreatorIdRequestDto>> Handle(FilterNftByCreatorIdRequest request, CancellationToken cancellationToken)
        {
            var nftSet = nFTRepository.GetAll(m => m.DeletedAt == null && m.CreatorId == request.CreatorId);

            if(nftSet == null || !nftSet.Any())
            {
                //throw new NotFoundException($"No NFTs found for creator with ID {request.CreatorId}.");
                return new List<FilterNftByCreatorIdRequestDto>();
            }

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            var joinedQuery = await (from n in nftSet
                                     select new FilterNftByCreatorIdRequestDto
                                     {
                                         Id = n.Id,
                                         CreatorId = n.CreatorId,
                                         Title = n.Title,
                                         Description = n.Description,
                                         Price = n.Price,
                                         HighestBid = n.HighestBid,
                                         ImagePath = $"{host}/uploads/images/{n.ImagePath}",
                                     }).ToListAsync(cancellationToken);

            if (joinedQuery == null || !joinedQuery.Any())
            {
                //return null;
                return new List<FilterNftByCreatorIdRequestDto>();
            }

            return joinedQuery;
        }
    }
}
