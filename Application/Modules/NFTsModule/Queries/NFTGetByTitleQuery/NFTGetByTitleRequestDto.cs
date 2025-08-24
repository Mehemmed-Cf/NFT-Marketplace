namespace Application.Modules.NFTsModule.Queries.NFTGetByTitleQuery
{
    public class NFTGetByTitleRequestDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double HighestBid { get; set; }
        public string ImagePath { get; set; }
    }
}
