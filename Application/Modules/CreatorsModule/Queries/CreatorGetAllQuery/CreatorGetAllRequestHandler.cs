using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Queries.CreatorGetAllQuery
{
    public class CreatorGetAllRequestHandler : IRequestHandler<CreatorGetAllRequest, IEnumerable<CreatorGetAllRequestDto>>
    {
        private readonly ICreatorRepository creatorRepository;
        private readonly IActionContextAccessor ctx;

        public CreatorGetAllRequestHandler(ICreatorRepository creatorRepository, IActionContextAccessor ctx)
        {
            this.creatorRepository = creatorRepository;
            this.ctx = ctx;
        }

        public async Task<IEnumerable<CreatorGetAllRequestDto>> Handle(CreatorGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = creatorRepository.GetAll();

            if(request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            var queryResponse = await query.Select(m => new CreatorGetAllRequestDto
            {
                Id = m.Id,
                NickName = m.NickName,
                Email = m.Email,
                ChainId = m.ChainId,
                Bio = m.Bio,
                Followers = m.Followers,
                Volume = m.Volume,
                SoldNFts = m.SoldNFts,
                ImagePath = $"{host}/uploads/images/{m.ImagePath}",
            }).ToListAsync(cancellationToken);

            return queryResponse;
        }
    }
}
