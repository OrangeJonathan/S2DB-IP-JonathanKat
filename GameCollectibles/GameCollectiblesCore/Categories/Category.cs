using GameCollectiblesCore.Collectibles;
namespace GameCollectiblesCore.Categories
{
    public class Category
    {
        public int gameID { get; private set; }
        public int categoryID { get; private set; }
        public string categoryName { get; private set; }
        public string? categoryDescription { get; private set; }
        public IEnumerable<Collectible>? collectibles { get; private set; }

        public Category (int GameID, int CategoryID, string Name)
        {
            gameID = GameID;
            categoryID = CategoryID;
            categoryName = Name;
        }

        public Category SetName(string Name)
        {
            categoryName = Name;
            return this;
        }

        public Category setDescription(string Description)
        {
            categoryDescription = Description;
            return this;
        }

        public Category setCollectibles(IEnumerable<Collectible> Collectibles)
        {
            collectibles = Collectibles;
            return this;
        }



    }
}