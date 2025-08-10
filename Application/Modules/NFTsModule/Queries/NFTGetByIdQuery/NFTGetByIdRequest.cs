using MediatR;

namespace Application.Modules.NFTsModule.Queries.NFTGetByIdQuery
{
    public class NFTGetByIdRequest : IRequest<NFTGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}
