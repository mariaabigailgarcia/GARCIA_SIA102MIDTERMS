namespace GARCIA_SIA102Midterms.DTOs
{
    public class AuthorReadDto
    {
        public string AuId { get; set; } = string.Empty;

        public string AuFname { get; set; } = string.Empty;
        public string AuLname { get; set; } = string.Empty;

        public string FullName => $"{AuFname} {AuLname}";

        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public bool Contract { get; set; }
    }
}
