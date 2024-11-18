using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Queries.CreatorGetByIdQuery
{
    public class CreatorGetByIdRequestHandler : IRequestHandler<CreatorGetByIdRequest, CreatorGetByIdRequestDto>
    {
        private readonly ICreatorRepository creatorRepository;
        private readonly IActionContextAccessor ctx;

        public CreatorGetByIdRequestHandler(ICreatorRepository creatorRepository, IActionContextAccessor ctx)
        {
            this.creatorRepository = creatorRepository;
            this.ctx = ctx;
        }

        public async Task<CreatorGetByIdRequestDto> Handle(CreatorGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await creatorRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            return new CreatorGetByIdRequestDto
            {
                Id = entity.Id,
                NickName = entity.NickName,
                ChainId = entity.ChainId,
                Bio = entity.Bio,
                Followers = entity.Followers,
                Volume = entity.Volume,
                SoldNFts = entity.SoldNFts,
                ImagePath = $"{host}/uploads/images/{entity.ImagePath}",
            };
        }
    }
}
