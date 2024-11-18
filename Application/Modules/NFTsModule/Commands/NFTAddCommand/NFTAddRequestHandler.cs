using Application.Repositories;
using Domain.Models.Entities;
using Infrastructure.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.NFTsModule.Commands.NFTAddCommand
{
    public class NFTAddRequestHandler : IRequestHandler<NFTAddRequest, NFTAddRequestDto>
    {
        private readonly INFTRepository NFTRepository;
        private readonly IFileService fileService;

        public NFTAddRequestHandler(INFTRepository NFTRepository, IFileService fileService)
        {
            this.NFTRepository = NFTRepository;
            this.fileService = fileService;
        }

        public async Task<NFTAddRequestDto> Handle(NFTAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new NFT
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                HighestBid = request.HighestBid,
                CreatorId = request.CreatorId,
            };

            entity.ImagePath = await fileService.UploadAsync(request.Image);

            await NFTRepository.AddAsync(entity);
            await NFTRepository.SaveAsync(cancellationToken);

            var dto = new NFTAddRequestDto
            {
                Id = entity.Id,
                CreatorId = entity.CreatorId,
                Title = entity.Title,
                Description = entity.Description,
                Price = entity.Price,
                HighestBid = entity.HighestBid
            };

            return dto;
        }
    }
}
