using Application.Repositories;
using Infrastructure.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Commands.CreatorEditCommand
{
    public class CreatorEditRequestHandler : IRequestHandler<CreatorEditRequest>
    {
        private readonly ICreatorRepository creatorRepository;
        private readonly IFileService fileService;

        public CreatorEditRequestHandler(ICreatorRepository creatorRepository, IFileService fileService)
        {
            this.creatorRepository = creatorRepository;
            this.fileService = fileService;
        }

        public async Task Handle(CreatorEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await creatorRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            entity.NickName = request.NickName;
            entity.ChainId = request.ChainId;
            entity.Bio = request.Bio;
            entity.Followers = request.Followers;
            entity.Volume = request.Volume;
            entity.SoldNFts = request.SoldNFts;
            entity.Email = request.Email;

            if (request.ProfileImage is not null)
                entity.ImagePath = await fileService.ChangeFileAsync(entity.ImagePath, request.ProfileImage);

            await creatorRepository.SaveAsync(cancellationToken);
        }
    }
}
