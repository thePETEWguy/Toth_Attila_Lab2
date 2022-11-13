using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Toth_Attila_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prenumele autorului trebuie sa fie format de minim 3 caractere, si maxim 50"), Required, StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie format de minim 3 caractere, si maxim 50"), Required, StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Author Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
