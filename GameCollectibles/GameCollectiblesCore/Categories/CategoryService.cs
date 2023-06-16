using GameCollectiblesCore.Games;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectiblesCore.Categories
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;
    	
        public CategoryService(ICategoryRepository catRepository, IGameRepository gamRepository)
        {
            _categoryRepository = catRepository;
            _gameRepository = gamRepository;
        }

        public IEnumerable<Category> GetCategories(int gameID, int? userID)
        {
            if (_gameRepository.GetGameById(gameID) == null)
            {
                throw new Exception($"Can't retrieve categories from game: {gameID} because the game does not exist in our Database");
            }
            var categories = _categoryRepository.GetCategoriesCollectibles(gameID, userID);
            return categories;

        }

        public void createCategory(Category category)
        {
            if (_gameRepository.GetGameById(category.gameID) == null)
            {
                throw new Exception($"Can't create a category for the game: {category.gameID} because the game does not exist in our Database");
            }
            if (string.IsNullOrEmpty(category.categoryName))
            {
                throw new Exception("Name is empty");
            }
            _categoryRepository.createCategory(category);
            return;
        }
    }
}
