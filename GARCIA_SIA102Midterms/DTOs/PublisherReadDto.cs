namespace GARCIA_SIA102Midterms.DTOs
{
    public class PublisherReadDto
    {
        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        // Optional: Info from PubInfo
        public string PrInfo { get; set; }

        // Optional: number of employees or titles
        public int EmployeeCount { get; set; }
        public int TitleCount { get; set; }
    }
}
