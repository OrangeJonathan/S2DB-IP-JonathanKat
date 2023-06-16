using GameCollectibleApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GameCollectiblesCore.Users;
using Microsoft.Data.SqlClient;

namespace GameCollectibleApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly string _connectionString;
        private readonly UserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IConfiguration configuration, ILogger<UsersController> logger)
        {
             _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
            _userService = new UserService(new GameCollectiblesData.Users.UserRepository(_connectionString));
        }

        public IActionResult Index()
        {
            try
            {
                string _selectedUserName = HttpContext.Session.GetString("UserName");
                var model = new UsersViewModel
                {
                    Users = _userService.GetAllUsers(),
                    SelectedUserId = HttpContext.Session.GetInt32("UserId"),
                    SelectedUserName = _selectedUserName
                };
                Console.WriteLine(_selectedUserName);
                return View(model);
            }
            catch (SqlException)
            {
                var model = new GameErrorViewModel
                {
                    errorMessage = "Something went wrong with the connection to the database",
                };    
                return RedirectToAction("error", "Games", model);
            }
            
        }

        public IActionResult SelectUser(int userId, string userName)
        {
            HttpContext.Session.SetInt32("UserId", userId);
            HttpContext.Session.SetString("UserName", userName);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}