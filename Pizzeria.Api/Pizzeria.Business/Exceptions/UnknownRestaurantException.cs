namespace Pizzeria.Business.Exceptions
{
    public class UnknownRestaurantException : Exception
    {
        public UnknownRestaurantException(int restaurantId) : base($"Could not find restaurant with ID {restaurantId}") { }
    }
}
