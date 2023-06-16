using GameCollectiblesCore.Categories;
namespace GameCollectibleApp.Models
{
    public class CategoryViewModel
    {
        public Category category { get; set; }
        public int? categoryID { get; set; }
        public string? categoryName { get; set; }
        public string? categoryDescription { get; set; }
        public int? gameID { get; set; }
        public string? errorMessage { get; set; }
    }
}