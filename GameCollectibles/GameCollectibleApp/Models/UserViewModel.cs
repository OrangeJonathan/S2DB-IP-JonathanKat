namespace GameCollectibleApp.Models
{
    public class UsersViewModel
{
    public IEnumerable<GameCollectiblesCore.Users.User> Users { get; set; }
    public int? SelectedUserId { get; set; }
    public string? SelectedUserName { get; set; }
}
}