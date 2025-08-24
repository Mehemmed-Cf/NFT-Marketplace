using MediatR;

namespace Application.Modules.NFTsModule.Queries.NFTGetByTitleQuery
{
    public class NFTGetByTitleRequest : IRequest<IEnumerable<NFTGetByTitleRequestDto>>
    {
        public string Title { get; set; }
    }
}
