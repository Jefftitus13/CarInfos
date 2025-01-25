namespace CarInfos.Models.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
    }
}
