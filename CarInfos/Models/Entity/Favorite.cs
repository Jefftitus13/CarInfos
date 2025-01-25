namespace CarInfos.Models.Entity
{
    public class Favorite
    {
        public int UserId { get; set; }
        public int CarId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Cars Car { get; set; }
    }
}
