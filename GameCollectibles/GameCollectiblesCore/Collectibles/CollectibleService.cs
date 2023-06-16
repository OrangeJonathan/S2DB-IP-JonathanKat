using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectiblesCore.Collectibles
{
    public class CollectibleService
    {
        private readonly ICollectibleRepository _collectibleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;
    	
        public CollectibleService(ICollectibleRepository colRepository, ICategoryRepository catRepository, IGameRepository gamRepository)
        {
            _collectibleRepository = colRepository;
            _categoryRepository = catRepository;
            _gameRepository = gamRepository;
        }

        public IEnumerable<Collectible> GetCollectibles(int categoryID, int? userID)
        {
            IEnumerable<Collectible> collectibles = _collectibleRepository.GetCollectibles(categoryID, userID);
            return collectibles;
        }

        public void createCollectible(Collectible collectible)
        {
            _collectibleRepository.createCollectible(collectible, collectible.categoryID);
            return;
        }

        public void ToggleCollected(int collectibleID, bool collectibleIsToggled, int? userId, int categoryID)
        {
            if (userId == null)
            {
                throw new Exception("No UserID Given");
            }
            if (collectibleIsToggled)
            {
                _collectibleRepository.DeleteUserCollectible(collectibleID, userId);
            }
            else
            {
                _collectibleRepository.createUserCollectible(collectibleID, userId);       
            }
        }

    }
}
