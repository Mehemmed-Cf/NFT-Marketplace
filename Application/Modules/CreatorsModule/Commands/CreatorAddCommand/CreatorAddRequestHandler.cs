using Application.Repositories;
using Domain.Models.Entities;
using Infrastructure.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Commands.CreatorAddCommand
{
    public class CreatorAddRequestHandler : IRequestHandler<CreatorAddRequest, CreatorAddRequestDto>
    {
        private readonly ICreatorRepository creatorRepository;
        private readonly IFileService fileService;

        public CreatorAddRequestHandler(ICreatorRepository creatorRepository, IFileService fileService)
        {
            this.creatorRepository = creatorRepository;
            this.fileService = fileService;
        }

        public async Task<CreatorAddRequestDto> Handle(CreatorAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Creator
            {
                NickName = request.NickName,
                Email = request.Email,
                Bio = request.Bio,
                Volume = request.Volume,
                SoldNFts = request.SoldNFts,
                Followers = request.Followers,
                CreatedBy = 1,
                CreatedAt = DateTime.UtcNow,
            };

            entity.ImagePath = await fileService.UploadAsync(request.ProfileImage);

            await creatorRepository.AddAsync(entity);
            await creatorRepository.SaveAsync(cancellationToken);

            var dto = new CreatorAddRequestDto
            {
                Id = entity.Id,
                NickName = entity.NickName,
                ImagePath = entity.ImagePath,
                Bio = entity.Bio,
                Followers = entity.Followers,
                Volume = entity.Volume,
                SoldNFts = entity.SoldNFts,
            };

            return dto;
        }
    }
}
