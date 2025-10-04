using System;
using System.ComponentModel.DataAnnotations;

namespace GARCIA_SIA102Midterms.DTOs
{
    public class TitleCreateDto
    {
        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        [Required]
        [StringLength(12)]
        public string Type { get; set; }

        [Required]
        public string PubId { get; set; } // FK to Publisher

        [Range(0, 999.99)]
        public decimal? Price { get; set; }

        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }

        [StringLength(200)]
        public string Notes { get; set; }

        [Required]
        public DateTime Pubdate { get; set; } = DateTime.Now;
    }
}
