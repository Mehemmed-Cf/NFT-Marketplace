using Application.Repositories;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.NFTsModule.Queries.NFTGetByTitleQuery
{
    public class NFTGetByTitleRequestHandler : IRequestHandler<NFTGetByTitleRequest, IEnumerable<NFTGetByTitleRequestDto>>
    {
        private readonly INFTRepository nFTRepository;
        private readonly IMediator mediator;
        private readonly IActionContextAccessor ctx;

        public NFTGetByTitleRequestHandler(INFTRepository nFTRepository, IMediator mediator, IActionContextAccessor ctx)
        {
            this.nFTRepository = nFTRepository;
            this.mediator = mediator;
            this.ctx = ctx;
        }

        public async Task<IEnumerable<NFTGetByTitleRequestDto>> Handle(NFTGetByTitleRequest request, CancellationToken cancellationToken)
        {
            var nftSet = nFTRepository.GetAll(m => m.DeletedAt == null && m.Title.Contains(request.Title));

            if (nftSet == null)
            {
                throw new NotFoundException($"Product with Title {request.Title} not found.");
            }

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            var joinedQuery = await(from n in nftSet
                                    select new NFTGetByTitleRequestDto
                                    {
                                        Id = n.Id,
                                        CreatorId = n.CreatorId,
                                        Title = n.Title,
                                        Description = n.Description,
                                        Price = n.Price,
                                        HighestBid = n.HighestBid,
                                        ImagePath = $"{host}/uploads/images/{n.ImagePath}",
                                    }).ToListAsync(cancellationToken);

            if (joinedQuery == null)
            {
                return null;
            }

            return joinedQuery;
        }
    }
}
