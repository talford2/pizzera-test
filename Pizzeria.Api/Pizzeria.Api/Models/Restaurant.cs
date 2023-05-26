namespace Pizzeria.Api.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public string Name => $"{Location} Pizzeria";
    }
}
