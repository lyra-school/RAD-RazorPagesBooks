using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MinLength(5)]
        public string? Title { get; set; }
        [MinLength(50)]
        public string? Summary { get; set; }
        public string? Publication {  get; set; }
        public int AuthorID {  get; set; }
        public int PublisherID { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Cover")]
        public string? CoverURL { get; set; }
    }
}
