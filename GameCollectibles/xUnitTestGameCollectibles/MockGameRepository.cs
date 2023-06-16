using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using GameCollectiblesCore;
using GameCollectiblesCore.Games;

namespace GameCollectiblesData.Games
{

    public class MockGameRepository : IGameRepository
    {
        List<Game> games = new List<Game>();

        public MockGameRepository()
        {
            
            games.Add(new Game("Minecraft")
            .setGameID(1)
            .setGameDescription("Blocky"));

            games.Add(new Game("Terraria")
            .setGameID(2)
            .setGameDescription("2D"));
        }

        public IEnumerable<Game> GetAllGames()
        {
            return games;
        }

        public void AddGame(Game game)
        {
            games.Add(game);
        }

        public Game? GetGameById(int? id)
        {
            foreach (var game in games)
            {
                if (game.gameID == id)
                {
                    return game;
                }
            }
            return null;
        }

        public void DeleteGame(int id)
        {
            games.Remove(GetGameById(id));
        }

        public void EditGame(Game game)
        {
            Game gameToEdit = GetGameById(game.gameID);
            gameToEdit.setGameTitle(game.gameTitle);
            gameToEdit.setGameDescription(game.gameDescription);

            foreach (var listGame in games)
            {
                if (listGame.gameID == gameToEdit.gameID)
                {
                    games.Remove(listGame);
                    games.Add(gameToEdit);
                    break;
                }
            }

        }
    
    }
    
}

