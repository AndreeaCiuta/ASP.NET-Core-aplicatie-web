using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PerfumesShop.Pages.Models
{
    public class Utilizator
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
        "Numele trebuie sa inceapa cu majuscula (ex. Andreea")]
        [StringLength(20, MinimumLength = 3)]
        public string? Nume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
        "Prenumele trebuie sa inceapa cu majuscula (ex. Popescu")]
        [StringLength(20, MinimumLength = 3)]
        public string? Prenume { get; set; }
        [StringLength(50)]
        public string? Adresa { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Telefon { get; set; }
        [Display(Name = "Nume Complet")]
        public string? NCompl //Nume complet utilizator
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Vandut>? Vandute { get; set; }
    }
}
