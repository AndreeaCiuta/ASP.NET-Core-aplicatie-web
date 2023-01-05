using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PerfumesShop.Pages.Models
{
    public class Concentratie
    {
        public int ID { get; set; }
        [Display(Name = "Concentratie")]
        public string Conctr { get; set; }
        public ICollection<Parfum>? Parfumuri { get; set; }
    }
}