using System.Diagnostics.Metrics;

namespace PerfumesShop.Pages.Models
{
    public class Vandut
    {
        public int ID { get; set; }
        public int? UtilizatorID { get; set; }
        public Utilizator? Utilizator { get; set; }
        public int? ParfumID { get; set; }
        public Parfum? Parfum { get; set; }
    }
}
