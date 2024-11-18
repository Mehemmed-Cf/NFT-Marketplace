using Application.Repositories;
using Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.NFTsModule.Commands.NFTRemoveCommand
{
    public class NFTRemoveRequestHandler : IRequestHandler<NFTRemoveRequest>
    {
        private readonly INFTRepository nFTRepository;

        public NFTRemoveRequestHandler(INFTRepository nFTRepository)
        {
            this.nFTRepository = nFTRepository;
        }

        public async Task Handle(NFTRemoveRequest request, CancellationToken cancellationToken)
        {
            NFT entity;

            if (request.OnlyAvailable)
            {
                entity = await nFTRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);
            }
            else
            {
                entity = await nFTRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            nFTRepository.Remove(entity);
            await nFTRepository.SaveAsync(cancellationToken);
        }
    }
}
