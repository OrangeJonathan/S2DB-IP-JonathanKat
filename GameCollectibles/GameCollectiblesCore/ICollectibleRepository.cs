using GameCollectiblesCore.Collectibles;

namespace GameCollectiblesCore
{
    public interface ICollectibleRepository
    {
        IEnumerable<Collectible> GetCollectibles(int categoryID, int? userID);
        void createCollectible(Collectible collectible, int categoryID);
        void UpdateUserCollectible(int collectibleID, bool collectibleIsCollected, int? userId);
        void createUserCollectible(int collectibleID, int? userId);
        bool getIsCollected(int collectibleID, int? userID);
        void DeleteUserCollectible(int collectibleID, int? userId);
    }
}
