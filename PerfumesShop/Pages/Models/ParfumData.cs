using PerfumesShop.Migrations;

namespace PerfumesShop.Pages.Models
{
    public class ParfumData
    {
        public IEnumerable<Parfum> Parfumuri { get; set; }
        public IEnumerable<Tip> Tipuri { get; set; }
        public IEnumerable<TipParfum> TipuriParfum { get; set; }
    }
}