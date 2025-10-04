using System.ComponentModel.DataAnnotations;

namespace GARCIA_SIA102Midterms.DTOs
{
    public class AuthorCreateDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Last name cannot exceed 20 characters.")]
        public string AuLname { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "First name cannot exceed 20 characters.")]
        public string AuFname { get; set; }

        [Phone(ErrorMessage = "Invalid phone format. Use (xxx) xxx-xxxx.")]
        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(40)]
        public string Address { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be 2 characters.")]
        public string State { get; set; }

        [RegularExpression(@"^\d{5}$", ErrorMessage = "Zip must be 5 digits.")]
        public string Zip { get; set; }

        public bool Contract { get; set; }
    }
}
