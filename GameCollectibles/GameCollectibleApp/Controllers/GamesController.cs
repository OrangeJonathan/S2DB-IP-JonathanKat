using GameCollectibleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
using GameCollectiblesCore.Games;
using GameCollectiblesData.Games;
using GameCollectiblesCore.Categories;
using GameCollectiblesData.Categories;
using GameCollectiblesCore.Collectibles;
using GameCollectiblesData.Collectibles;

namespace GameCollectibleApp.Controllers
{
    public class GamesController : Controller
    {
        private readonly string _connectionString;
        private readonly GameService _gameService;
        private readonly CategoryService _categoryService;
        private readonly CollectibleService _collectibleService;
        private readonly ILogger<HomeController> _logger;

        public GamesController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            
            _gameService = new GameService(new GameCollectiblesData.Games.GameRepository(_connectionString));
            _categoryService = new CategoryService(new GameCollectiblesData.Categories.CategoryRepository(_connectionString), new GameCollectiblesData.Games.GameRepository(_connectionString));
            _collectibleService = new CollectibleService(new CollectibleRepository(_connectionString), new GameCollectiblesData.Categories.CategoryRepository(_connectionString), new GameCollectiblesData.Games.GameRepository(_connectionString));
            
            _logger = logger;
        }

        public IActionResult Index(string sortOrder)
        {
            try
            {
                var games = _gameService.GetAllGames();
                return View(games);
            }
            catch (SqlException)
            {
                var model = new GameErrorViewModel
                {
                    errorMessage = "Something went wrong with the connection to the database",
                };    
                return RedirectToAction("error", model);
            }
        }
        public IActionResult Create(GameViewModel model)
        {   
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete([FromQuery] int gameID)
        {
            try
            {
                _gameService.DeleteGame(gameID);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                var model = new GameErrorViewModel
                {
                    errorMessage = ex.Message,
                };    
                return RedirectToAction("error", model);
            }
            
        }
        public ActionResult Edit([FromQuery] int gameID)
        {   
            try
            {
                var game = _gameService.GetGameByID(gameID);
                if (game == null)
                {
                    return NotFound();
                }
                return View(game);
            }
            catch (Exception ex)
            {
                var model = new GameErrorViewModel
                {
                    errorMessage = ex.Message,
                };    
                return RedirectToAction("error", model);
            }
        }
        
        [HttpPost]
        public ActionResult SubmitGame(GameViewModel gameVM)
        {
            Game game = new Game(gameVM.gameTitle)
            .setGameDescription(gameVM.gameDescription);
            try
            {
                _gameService.AddGame(game);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {

                var model = new GameViewModel
                {
                    errorMessage = ex.Message,
                };    
                return RedirectToAction("create", model);
            }
            
        }

        [HttpPost]
        public ActionResult EditGame(GameViewModel gameVM)
        {
            Game game = new Game(gameVM.gameTitle)
            .setGameDescription(gameVM.gameDescription)
            .setGameID(gameVM.gameID.GetValueOrDefault());
            try
            {
                if (ModelState.IsValid)
                {
                    _gameService.EditGame(game);
                    return RedirectToAction("index");
                }
                return RedirectToAction("game", game);
            }
            catch (Exception ex)
            {
                var model = new GameErrorViewModel
                {
                    errorMessage = ex.Message,
                };    
                return RedirectToAction("error", model);
            }
            
        }

        public IActionResult Game([FromQuery] int gameID)
        {
            try
            {
                int? currentUserID = HttpContext.Session.GetInt32("UserId");
                if (currentUserID == null)
                {
                    return RedirectToAction("index", "Users");
                }
                var _game = _gameService.GetGameByID(gameID);
                var categoriesWithoutCollectibles = _categoryService.GetCategories(gameID, currentUserID);
                var categoriesWithCollectibles = new List<Category>();

                foreach (var category in categoriesWithoutCollectibles)
                {
                    IEnumerable<Collectible> _collectibles = _collectibleService.GetCollectibles(category.categoryID, currentUserID);

                    category.setCollectibles(_collectibles);

                    categoriesWithCollectibles.Add(category);
                }

                

                if (_game == null)
                {
                    return RedirectToAction("error");
                }
                if (currentUserID == null)
                {
                    return NotFound();
                }
                var model = new GameViewModel
                {
                    game = _game,
                    categories = categoriesWithCollectibles,
                };
                return View(model);
            }
            catch (Exception ex)
            {
                var model = new GameErrorViewModel
                {
                    errorMessage = ex.Message,
                };    
                return RedirectToAction("error", model);
            }
            
        }

        

        public ActionResult ToggleCollected(int collectibleId, bool isToggledCollected, int categoryID, int gameId)
        {
            try
            {
                int? userId = HttpContext.Session.GetInt32("UserId");
                _collectibleService.ToggleCollected(collectibleId, isToggledCollected, userId, categoryID);
                return RedirectToAction("Game", new { gameID = gameId });
            }
            catch (Exception ex)
            {
                var model = new GameErrorViewModel
                {
                    errorMessage = ex.Message,
                };    
                return RedirectToAction("error", model);
            }

            
        }

        public IActionResult Error(GameErrorViewModel model)
        {
            return View(model);
        }

    }
}
