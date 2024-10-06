using System.ComponentModel.DataAnnotations;

namespace WorkPoint_WebApp.Shared.DataTransferObjects
{
    public class NewsReturnDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Detail1 { get; set; }
        public string? Detail2 { get; set; }
        public string? Detail3 { get; set; }

        public string? Picture1 { get; set; }
        public string? Picture1FileName { get; set; }
        public string? Picture2 { get; set; }
        public string? Picture2FileName { get; set; }
        public string? Picture3 { get; set; }
        public string? Picture3FileName { get; set; }
        public string? Picture4 { get; set; }
        public string? Picture4FileName { get; set; }
        public string? Picture5 { get; set; }
        public string? Picture5FileName { get; set; }
        public string? Picture6 { get; set; }
        public string? Picture6FileName { get; set; }
        public string? Picture7 { get; set; }
        public string? Picture7FileName { get; set; }
        public string? Picture8 { get; set; }
        public string? Picture8FileName { get; set; }
        public string? Picture9 { get; set; }
        public string? Picture9FileName { get; set; }
        public string? Picture10 { get; set; }
        public string? Picture10FileName { get; set; }

    }
}
