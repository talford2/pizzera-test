import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { PizzaListItem } from "../Components/PizzaListItem/PizzaListItem";
import { Pizza } from "../Models/Pizza";
import { Restaurant } from "../Models/Restaurant";
import { PizzeriaService } from "../Services/PizzeriaService";
import { OrderSummary } from "../Components/OrderSummary/OrderSummary";
import { Order } from "../Models/Order";

export const RestaurantPage = () => {
  const pizzeriaService = new PizzeriaService();
  const params = useParams();
  const [restaurant, setRestaurant] = React.useState<Restaurant>();
  const [pizzas, setPizzas] = React.useState<Pizza[]>();
  const [order, setOrder] = React.useState<Order>();
  const restaurantId = parseInt(params.id || "0");

  useEffect(() => {
    pizzeriaService.GetRestaurant(restaurantId).then((r) => {
      setRestaurant(r);
    });

    pizzeriaService.GetRestaurantPizzas(restaurantId).then((r) => {
      setPizzas(r);
    });
  }, []);

  const handleAddToOrder = (p: Pizza) => {
    // Should push this up to the server and get a fresh copy of the order
    
    let localOrder = order && {...order} as Order || new Order(restaurantId);
    localOrder.pizzaOrders?.push({ pizza: p, toppings: [] });
    console.log("Set order", localOrder);
    setOrder(localOrder);
  };

  return (
    <>
      {order && <OrderSummary order={order} />}
      <section>
        <h1>{restaurant && restaurant.name}</h1>
        <h2>Pizza Menu</h2>
        <div>
          {pizzas?.map((p) => (
            <PizzaListItem
              key={p.id}
              pizza={p}
              onAddToOrder={handleAddToOrder}
            />
          ))}
        </div>
      </section>
    </>
  );
};
