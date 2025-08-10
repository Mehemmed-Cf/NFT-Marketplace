using MediatR;

namespace Application.Modules.NFTsModule.Queries.NFTGetAllQuery
{
    public class NFTGetAllRequest : IRequest<IEnumerable<NFTGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
