using GameCollectiblesCore;
using GameCollectiblesCore.Games;
using GameCollectiblesData.Games;

namespace xUnitTestGameCollectibles
{

    public class TestGames
    {
        [Fact]
        public void NewGame_AddGame_ShouldBeAdded()
        {
            // Arrange
            MockGameRepository repository = new MockGameRepository();
            GameService service = new GameService(repository);
            Game game = new Game("Pokemon")
            .setGameID(3)
            .setGameDescription("All pokemon games in 1");

            

            // Act
            service.AddGame(game);

            // Assert
            var addedGame = service.GetGameByID(game.gameID);
            Assert.NotNull(addedGame);
            Assert.Equal("Pokemon", addedGame.gameTitle);
            Assert.Equal("All pokemon games in 1", addedGame.gameDescription);
        }

        [Fact]
        public void NewGame_AddGame_ShouldNotBeAdded()
        {
            // Arrange
            MockGameRepository repository = new MockGameRepository();
            GameService service = new GameService(repository);

            // Act & Assert
            void AddGame()
            {
                service.AddGame(new Game("")
                .setGameID(1)
                .setGameDescription("All pokemon games in 1"));
            }
            Assert.Throws<Exception>(AddGame);
        }



        [Fact]
        public void GetGames_GetAllGames_ShouldBeGotten()
        {
            // Arrange
            MockGameRepository repository = new MockGameRepository();
            GameService service = new GameService(repository);
            List<Game> games;

            // Act
            games = (List<Game>)service.GetAllGames();

            // Assert
            Assert.Equal("Minecraft", games[0].gameTitle);
            Assert.Equal(1, games[0].gameID);
            Assert.Equal("Blocky", games[0].gameDescription);
            Assert.Equal("Terraria", games[1].gameTitle);
            Assert.Equal(2, games[1].gameID);
            Assert.Equal("2D", games[1].gameDescription);

        }

        [Fact]
        public void GetGame_GetGameById_ShouldBeGotten()
        {
            // Arrange
            MockGameRepository repository = new MockGameRepository();
            GameService service = new GameService(repository);
            Game game;
            int id = 1;
            // Act
            game = service.GetGameByID(id);

            // Assert
            Assert.Equal(id, game.gameID);
            Assert.Equal("Minecraft", game.gameTitle);
            Assert.Equal("Blocky", game.gameDescription);


        }
        [Fact]
        public void GetGame_GetGameById_ShouldNotBeGotten()
        {
            // Arrange
            MockGameRepository repository = new MockGameRepository();
            GameService service = new GameService(repository);
            int id = 100;

            // Act & Assert
            void GetGameByID()
            {
                service.GetGameByID(id);
            }
            Assert.Throws<Exception>(GetGameByID);
        }

        [Fact]
        public void DeleteGame_ShouldBeDeleted()
        {
            // Arrange
            MockGameRepository repository = new MockGameRepository();
            GameService service = new GameService(repository);
            int id = 1;
            // Act
            service.DeleteGame(id);

            // Assert
            Assert.Null(repository.GetGameById(id));


        }
        [Fact]
        public void DeleteGame_ShouldNotBeDeleted()
        {
            // Arrange
            MockGameRepository repository = new MockGameRepository();
            GameService service = new GameService(repository);
            IEnumerable<Game> games = service.GetAllGames();
            Game game = new Game("AppelFarmer")
                .setGameID(100)
                .setGameDescription("Lekker");

            // Act & Assert
            void DeleteGame()
            {
                service.DeleteGame(game.gameID);
            }
            Assert.Throws<Exception>(DeleteGame);


        }


        [Fact]
        public void EditGame_ShouldBeEdited()
        {
            // Arrange
            MockGameRepository repository = new MockGameRepository();
            GameService service = new GameService(repository);
            int? editedGameID;
            Game editedGame;
            
            Game game = new Game("Stardew Valley")
                        .setGameID(1)
                        .setGameDescription("Farming");
            string editTitle = "Stardew Valley";
            string editDescription = "Farming";

            // Act
            editedGameID = service.EditGame(game);

            // Assert
            editedGame = service.GetGameByID(editedGameID ?? default(int));
            Assert.NotNull(editedGame);
            Assert.Equal(editedGame.gameTitle, editTitle);
            Assert.Equal(editedGame.gameDescription, editDescription);
        }

        [Fact]
        public void EditGame_ShouldNotBeEdited()
        {
            // Arrange
            MockGameRepository repository = new MockGameRepository();
            GameService service = new GameService(repository);

            // Act & Assert
            void EditGame()
            {
                new Game("AppelFarmer")
                .setGameID(100)
                .setGameDescription("Lekker");
            }
            Assert.Throws<Exception>(EditGame);
        }

    }
}