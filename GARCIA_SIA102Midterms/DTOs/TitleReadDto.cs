namespace GARCIA_SIA102Midterms.DTOs
{
    public class TitleReadDto
    {
        public string TitleId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string PubId { get; set; }
        public string PublisherName { get; set; } // map from Title.Pub.PubName
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string Notes { get; set; }
        public DateTime Pubdate { get; set; }

        // Optional: list of authors for Details
        public List<string> Authors { get; set; } = new List<string>();
    }
}
