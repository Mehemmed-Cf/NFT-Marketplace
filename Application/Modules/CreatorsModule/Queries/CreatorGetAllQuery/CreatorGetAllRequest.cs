using MediatR;

namespace Application.Modules.CreatorsModule.Queries.CreatorGetAllQuery
{
    public class CreatorGetAllRequest : IRequest<IEnumerable<CreatorGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
