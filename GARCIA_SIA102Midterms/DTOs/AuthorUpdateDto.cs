using System.ComponentModel.DataAnnotations;

namespace GARCIA_SIA102Midterms.DTOs
{
    public class AuthorUpdateDto
    {
        [Required]
        public string AuId { get; set; }  // Hidden field in edit form

        [Required]
        [StringLength(20)]
        public string AuLname { get; set; }

        [Required]
        [StringLength(20)]
        public string AuFname { get; set; }

        [Phone]
        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(40)]
        public string Address { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [RegularExpression(@"^\d{5}$")]
        public string Zip { get; set; }

        public bool Contract { get; set; }
    }
}
