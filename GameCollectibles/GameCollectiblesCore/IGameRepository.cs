using GameCollectiblesCore.Games;

namespace GameCollectiblesCore
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        Game? GetGameById(int? id);
        void AddGame(Game game);
        void DeleteGame(int id);
        void EditGame(Game game);
    }
}
