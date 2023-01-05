using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PerfumesShop.Pages.Models
{
    public class Tip
    {
        public int ID { get; set; }
        [Display(Name = "Tip")]
        public string Type { get; set; }
        public ICollection<Parfum>? Parfumuri { get; set; }
    }
}