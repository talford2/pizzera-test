namespace Pizzeria.Business.Exceptions
{
    internal class UnknownOrderException : Exception
    {
        public UnknownOrderException(int orderId) : base($"Could not find order with ID {orderId}") { }
    }
}
