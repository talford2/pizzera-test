using Moq;
using Pizzeria.Business.Services;
using Pizzeria.Repositories.Models;
using Pizzeria.Repository;

namespace Pizzeria.UnitTests
{
    public class PizzaServiceTests
    {
        [Fact]
        public void GetMenu_ReturnPizzaForRestaurantWithPizzaDetails()
        {
            var restaurantPizzaPriceRepo = new Mock<IRestaurantPizzaPriceRepository>();
            restaurantPizzaPriceRepo.Setup(r => r.GetForRestaurant(100)).Returns(new List<RestaurantPizzaPriceDto>
            {
                new RestaurantPizzaPriceDto
                {
                    RestaurantId = 100,
                    PizzaId = 111,
                    Price = 15.95m
                },
                new RestaurantPizzaPriceDto
                {
                    RestaurantId = 100,
                    PizzaId = 222,
                    Price = 18.95m
                }
            });

            var pizzaRepo = new Mock<IPizzaRepository>();
            pizzaRepo.Setup(r => r.GetAll()).Returns(new List<PizzaDto> {
                new PizzaDto
                {
                    Id = 111,
                    Name = "Pizza A",
                    BaseIngredients = new string[] { "A", "B", "C" }
                },
                new PizzaDto
                {
                    Id = 222,
                    Name = "Pizza B",
                    BaseIngredients = new string[] { "X", "Y" }
                },
                new PizzaDto
                {
                    Id = 333,
                    Name = "Pizza C",
                    BaseIngredients = new string[] { "T", "U" }
                }
            });

            var pizzaService = new PizzaService(restaurantPizzaPriceRepo.Object, pizzaRepo.Object);
            var menu = pizzaService.GetMenu(100).ToArray();

            Assert.Equal(2, menu.Length);

            Assert.Equal(100, menu[0].RestaurantId);
            Assert.Equal(111, menu[0].Id);
            Assert.Equal(15.95m, menu[0].BasePrice);
            Assert.Equal("Pizza A", menu[0].Name);
            Assert.Equal(new string[] { "A", "B", "C" }, menu[0].BaseIngredients);

            Assert.Equal(100, menu[1].RestaurantId);
            Assert.Equal(222, menu[1].Id);
            Assert.Equal(18.95m, menu[1].BasePrice);
            Assert.Equal("Pizza B", menu[1].Name);
            Assert.Equal(new string[] { "X", "Y" }, menu[1].BaseIngredients);
        }
    }
}