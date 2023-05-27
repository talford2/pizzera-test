import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { PizzaListItem } from "../Components/PizzaListItem/PizzaListItem";
import { Pizza } from "../Models/Pizza";
import { Restaurant } from "../Models/Restaurant";
import { PizzeriaService } from "../Services/PizzeriaService";
import { OrderSummary } from "../Components/OrderSummary/OrderSummary";
import { Order } from "../Models/Order";
import { Button } from "../Components/Button/Button";

export const RestaurantPage = () => {
  const pizzeriaService = new PizzeriaService();
  const params = useParams();
  const [restaurant, setRestaurant] = React.useState<Restaurant>();
  const [pizzas, setPizzas] = React.useState<Pizza[]>();
  const [order, setOrder] = React.useState<Order>();
  const [showOrder, setShowOrder] = React.useState<boolean>(false);
  const restaurantId = parseInt(params.id || "0");

  useEffect(() => {
    pizzeriaService.GetRestaurant(restaurantId).then((r) => {
      setRestaurant(r);
    });

    pizzeriaService.GetRestaurantPizzas(restaurantId).then((r) => {
      setPizzas(r);
    });
  }, []);

  const handleAddToOrder = (pizza: Pizza) => {
    if (!order) {
      pizzeriaService.CreateNewOrder(restaurantId, pizza.id).then((o) => {
        setOrder(o);
      });
    } else {
      pizzeriaService.AddPizzaToOrder(order.id, pizza.id).then(() => {
        pizzeriaService.GetOrder(order?.id || 0).then((o) => {
          setOrder(o);
        });
      });
    }
    setShowOrder(true);
  };

  const handleRemoveFromOrder = (pizzaOrderId: number) => {
    pizzeriaService.RemovePizzaFromOrder(pizzaOrderId).then(() => {
      pizzeriaService.GetOrder(order?.id || 0).then((o) => {
        setOrder(o);
      });
    });
  };

  return (
    <>
      {order && showOrder && (
        <OrderSummary
          order={order}
          onRemovePizzaOrder={handleRemoveFromOrder}
          onCloseOrderSummary={() => setShowOrder(false)}
        />
      )}
      <section>
        <h1>{restaurant && restaurant.name}</h1>
        {order && !showOrder && <Button label="Show Order" onClick={() => setShowOrder(true)} />}
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
