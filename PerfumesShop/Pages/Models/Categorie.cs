using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PerfumesShop.Pages.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Display(Name = "Categorie")]
        public string Categ { get; set; }
        public ICollection<Parfum>? Parfumuri { get; set; } //navigation property
    }
}