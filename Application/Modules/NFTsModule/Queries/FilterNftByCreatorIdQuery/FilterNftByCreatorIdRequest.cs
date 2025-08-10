using MediatR;

namespace Application.Modules.NFTsModule.Queries.FilterNftByCreatorIdQuery
{
    public class FilterNftByCreatorIdRequest : IRequest<IEnumerable<FilterNftByCreatorIdRequestDto>>
    {
        public int CreatorId { get; set; }
    }
}
