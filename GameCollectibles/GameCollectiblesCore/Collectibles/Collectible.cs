namespace GameCollectiblesCore.Collectibles
{
    public class Collectible
    {
        public int gameID { get; private set; }
        public int categoryID { get; private set; }
        public int collectibleID { get; private set; }
        public string collectibleName { get; private set; }
        public string collectibleDescription { get; private set; }
        public bool isCollected { get; private set; }

        public Collectible(int CategoryID, int CollectibleID, string Name, string Description, bool Collected)
        {
            categoryID = CategoryID;
            collectibleID = CollectibleID;
            collectibleName = Name;
            collectibleDescription = Description;
            isCollected = Collected;
        }

        public Collectible setGameID(int GameID)
        {
            gameID = GameID;
            return this;
        }

        public Collectible SetName(string Name)
        {
            collectibleName = Name;
            return this;
        }

        public Collectible SetDescription(string Description)
        {
            collectibleDescription = Description;
            return this;
        }


    }
}