using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toth_Attila_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Book Title")]
        public string? Title { get; set; }

        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        public int AuthorID { get; set; }

        [Display(Name="Author")]
        public Author? Author { get; set; } // navigation property

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int PublisherID { get; set; }
        public Publisher? Publisher { get; set; } // navigation property

        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
