using GameCollectibleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
using GameCollectiblesCore.Collectibles;
using GameCollectiblesData.Collectibles;

namespace GameCollectibleApp.Controllers
{
    public class CollectiblesController : Controller
    {
        private readonly string _connectionString;
        private readonly CollectibleService _collectibleService;
        private readonly ILogger<HomeController> _logger;

        public CollectiblesController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _collectibleService = new CollectibleService(new CollectibleRepository(_connectionString), new GameCollectiblesData.Categories.CategoryRepository(_connectionString), new GameCollectiblesData.Games.GameRepository(_connectionString));
            _logger = logger;
        }

        public IActionResult Index([FromQuery] int categoryID)
        {
            return View();
        }

        public IActionResult Create([FromQuery]int CategoryID, [FromQuery]int GameID)
        {
            var model = new CollectibleViewModel{
                categoryID = CategoryID,
                gameID = GameID
            };
            return View(model);
        }

        public ActionResult AddCollectible(CollectibleViewModel collectibleVM)
        {
            Collectible collectible = new Collectible(collectibleVM.categoryID ?? default(int), collectibleVM.collectibleID ?? default(int), collectibleVM.collectibleName, collectibleVM.collectibleDescription, false)
            .setGameID(collectibleVM.gameID ?? default(int));

            _collectibleService.createCollectible(collectible);
            return RedirectToAction("Game", "Games", new { gameID = collectible.gameID });
        }

        


    }
}
