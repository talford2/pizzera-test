namespace Pizzeria.Repositories.Models
{
    public class RestaurantDto
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public string Name => $"{Location} Pizzeria";
    }
}
