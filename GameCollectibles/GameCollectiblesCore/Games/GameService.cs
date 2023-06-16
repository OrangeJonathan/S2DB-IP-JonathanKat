using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollectiblesCore.Categories;

namespace GameCollectiblesCore.Games
{
    public class GameService
    {
        private readonly IGameRepository _gameRepository;
        

        public GameService(IGameRepository repository)
        {
            _gameRepository = repository;
        }

        public IEnumerable<Game> GetAllGames()
        {
            // try-catch 
            IEnumerable<Game> games = _gameRepository.GetAllGames();
            return games;
        }
        
        public Game? GetGameByID(int Id)
        {
            Game gameGotten = _gameRepository.GetGameById(Id);
            if(gameGotten == null)
            {
                throw new Exception($"The Game with the ID: {Id} does not exist in our Database");
            }
            return gameGotten;
        }
        public void AddGame(Game game)
        {
            CheckIfValid(game);
            _gameRepository.AddGame(game);
        }
        public void DeleteGame(int Id)
        {
            Game gameGotten = _gameRepository.GetGameById(Id);
            if(gameGotten == null)
            {
                throw new Exception($"The Game with the ID: {Id} can't be deleted because it doesn't exist");
            }
            _gameRepository.DeleteGame(Id);
            return;
            
        }

        public int? EditGame(Game editGame)
        {
            CheckIfValid(editGame);
            Game gameGotten = _gameRepository.GetGameById(editGame.gameID);
            if (gameGotten == null)
            {
                throw new Exception($"The Game with the ID: {editGame.gameID} can't be edited because it doesn't exist");
            }

            _gameRepository.EditGame(editGame);
            return editGame.gameID;
        }

        private void CheckIfValid(Game game)
        {
            if (string.IsNullOrEmpty(game.gameTitle) && string.IsNullOrEmpty(game.gameDescription))
            {
                throw new Exception("No Title and No Description given");
            }
            if (string.IsNullOrEmpty(game.gameTitle))
            {
                throw new Exception("No Title given");
            }
            if (string.IsNullOrEmpty(game.gameDescription))
            {
                throw new Exception("No Description given");
            }
        }

    }
}
