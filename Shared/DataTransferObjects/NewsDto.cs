using System.ComponentModel.DataAnnotations;

namespace WorkPoint_WebApp.Shared.DataTransferObjects
{
    public class NewsDto
    {
        [Required]
        public string Title { get; set; }
        [StringLength(2500)]
        [MaxLength(2500, ErrorMessage = "Maximum length for the Detail1 is 2500 characters.")]
        public string? Detail1 { get; set; }
        [StringLength(2500)]
        [MaxLength(2500, ErrorMessage = "Maximum length for the Detail2 is 2500 characters.")]
        public string? Detail2 { get; set; }
        [StringLength(2500)]
        [MaxLength(2500, ErrorMessage = "Maximum length for the Detail3 is 2500 characters.")]
        public string? Detail3 { get; set; }
        public IFormFile? Picture1 { get; set; }
        public IFormFile? Picture2 { get; set; }
        public IFormFile? Picture3 { get; set; }
        public IFormFile? Picture4 { get; set; }
        public IFormFile? Picture5 { get; set; }
        public IFormFile? Picture6 { get; set; }
        public IFormFile? Picture7 { get; set; }
        public IFormFile? Picture8 { get; set; }
        public IFormFile? Picture9 { get; set; }
        public IFormFile? Picture10 { get; set; }
    }
}
