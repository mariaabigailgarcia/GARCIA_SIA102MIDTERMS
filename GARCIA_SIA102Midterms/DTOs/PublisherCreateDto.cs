using System.ComponentModel.DataAnnotations;

namespace GARCIA_SIA102Midterms.DTOs
{
    public class PublisherCreateDto
    {
        [Required]
        [StringLength(40)]
        public string PubName { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be 2 characters.")]
        public string State { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        // Optional: PubInfo
        public string PrInfo { get; set; }
    }
}
