using Application.Repositories;
using Infrastructure.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.NFTsModule.Commands.NFTEditCommand
{
    public class NFTEditRequestHandler : IRequestHandler<NFTEditRequest>
    {
        private readonly IFileService fileService;
        private readonly INFTRepository nFTRepository;

        public NFTEditRequestHandler(INFTRepository nFTRepository, IFileService fileService)
        {
            this.fileService = fileService;
            this.nFTRepository = nFTRepository;
        }

        public async Task Handle(NFTEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await nFTRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Price = request.Price;
            entity.HighestBid = request.HighestBid;
            entity.CreatorId = request.CreatorId;

            if (request.NFTImage is not null)
                entity.ImagePath = await fileService.ChangeFileAsync(entity.ImagePath, request.NFTImage);

            await nFTRepository.SaveAsync(cancellationToken);
        }
    }
}
