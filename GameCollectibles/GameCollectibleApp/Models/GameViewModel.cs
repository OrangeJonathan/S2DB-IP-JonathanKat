using GameCollectiblesCore.Games;
namespace GameCollectibleApp.Models
{
    public class GameViewModel
    {
        public Game? game { get; set; }
        public int? gameID { get; set; }
        public string gameTitle { get; set; }
        public string gameDescription { get; set; }
        public IEnumerable<GameCollectiblesCore.Categories.Category>? categories { get; set; }
        public string? SelectedUserName { get; set; }
        public string? errorMessage { get; set; }
    }
}