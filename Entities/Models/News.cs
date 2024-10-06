using System.ComponentModel.DataAnnotations;

namespace WorkPoint_WebApp.Entities.Models
{
    public class News
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [StringLength(2500)]
        public string? Detail1 { get; set; }
        [StringLength(2500)]
        public string? Detail2 { get; set; }
        [StringLength(2500)]
        public string? Detail3 { get; set; }
        [StringLength(250)]
        public string? Picture1 { get; set; }
        [StringLength(250)]
        public string? Picture2 { get; set; }
        [StringLength(250)]
        public string? Picture3 { get; set; }
        [StringLength(250)]
        public string? Picture4 { get; set; }
        [StringLength(250)]
        public string? Picture5 { get; set; }
        [StringLength(250)]
        public string? Picture6 { get; set; }
        [StringLength(250)]
        public string? Picture7 { get; set; }
        [StringLength(250)]
        public string? Picture8 { get; set; }
        [StringLength(250)]
        public string? Picture9 { get; set; }
        [StringLength(250)]
        public string? Picture10 { get; set; }

        [StringLength(20)]
        public string? CreatedDate { get; set; }
        [StringLength(20)]
        public string? CreatedTime { get; set;}
    }

}
