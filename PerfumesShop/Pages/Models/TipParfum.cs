using PerfumesShop.Migrations;

namespace PerfumesShop.Pages.Models
{
    public class TipParfum
    {
        public int ID { get; set; }
        public int ParfumID { get; set; }
        public Parfum Parfum { get; set; }
        public int TipID { get; set; }
        public Tip Tip { get; set; }
    }
}