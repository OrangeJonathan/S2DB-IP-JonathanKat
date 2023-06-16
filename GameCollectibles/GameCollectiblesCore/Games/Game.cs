namespace GameCollectiblesCore.Games
{
    public class Game
    {
        public int gameID { get; private set; }
        public string? gameTitle { get; private set; }
        public string? gameDescription { get; private set; }

        public Game (string Title)
        {
            gameTitle = Title;
        }
        public Game setGameID(int GameID)
        {
            gameID = GameID;
            return this;
        }

        public Game setGameTitle(string Title)
        {
            gameTitle = Title;
            return this;
        }

        public Game setGameDescription(string Description)
        {
            gameDescription = Description;
            return this;
        }
    }
}