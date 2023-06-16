using GameCollectiblesCore.Collectibles;
namespace GameCollectibleApp.Models
{
    public class CollectibleViewModel
    {
        public Collectible? collectible { get; set; }
        public int? categoryID { get; set; }
        public int? gameID { get; set; }
        public int? collectibleID { get; set; }
        public string? collectibleName { get; set; }
        public string? collectibleDescription { get; set; }
    }
}