using System.Security.Policy;

namespace PerfumesShop.Pages.Models.ViewModels
{
    public class CategorieIndexData
    {
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<Parfum> Parfumuri { get; set; }

    }
}