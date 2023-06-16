using GameCollectiblesCore.Categories;

namespace GameCollectiblesCore
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories(int gameID);
        void createCategory(Category category);
        IEnumerable<Category> GetCategoriesCollectibles(int gameID, int? userID);

    }
}
