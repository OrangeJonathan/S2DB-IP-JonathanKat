using GameCollectibleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
using GameCollectiblesCore.Categories;
using GameCollectiblesData.Categories;
using GameCollectiblesCore.Games;
using GameCollectiblesData.Games;

namespace GameCollectibleApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly string _connectionString;
        private readonly CategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;

        public CategoriesController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _categoryService = new CategoryService(new CategoryRepository(_connectionString), new GameRepository(_connectionString));
            _logger = logger;
        }

        public IActionResult Index([FromQuery] int categoryID)
        {
            return View();
        }

        public IActionResult Create([FromQuery]int GameID, string errMessage)
        {
            var model = new CategoryViewModel{
                gameID = GameID,
                errorMessage = errMessage
            };
            return View(model);
        }

        public ActionResult AddCategory(CategoryViewModel categoryVM)
        {
            Category category = new Category(categoryVM.gameID ?? default(int), categoryVM.categoryID ?? default(int), categoryVM.categoryName);


            try
            {
                _categoryService.createCategory(category);
                return RedirectToAction("Game", "Games", new { gameID = category.gameID });
            }
            catch (System.Exception)
            {
                // ik doe er niks mee
                throw;
            }
            
        }
        


    }
}
