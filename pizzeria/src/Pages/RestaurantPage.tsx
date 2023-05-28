import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { PizzaListItem } from "../Components/PizzaListItem/PizzaListItem";
import { Pizza } from "../Models/Pizza";
import { Restaurant } from "../Models/Restaurant";
import { PizzeriaService } from "../Services/PizzeriaService";
import { OrderSummary } from "../Components/OrderSummary/OrderSummary";
import { Order } from "../Models/Order";
import { Button } from "../Components/Button/Button";
import { EditPizzaOrderPopup } from "../Components/EditPizzaOrderPopup/EditPizzaOrderPopup";
import { PizzaOrder } from "../Models/PizzaOrder";
import { Topping } from "../Models/Topping";

export const RestaurantPage = () => {
  const pizzeriaService = new PizzeriaService();
  const params = useParams();
  const [restaurant, setRestaurant] = React.useState<Restaurant>();
  const [pizzas, setPizzas] = React.useState<Pizza[]>();
  const [order, setOrder] = React.useState<Order>();
  const [showOrder, setShowOrder] = React.useState<boolean>(false);
  const [toppings, setToppings] = React.useState<Topping[]>([]);
  const [pizzaOrder, setPizzaOrder] = React.useState<PizzaOrder | undefined>(
    undefined
  );
  const [showToppingPopup, setShowToppingPopup] =
    React.useState<boolean>(false);

  const restaurantId = parseInt(params.id || "0");

  useEffect(() => {
    pizzeriaService.GetRestaurant(restaurantId).then((r) => {
      setRestaurant(r);
    });

    pizzeriaService.GetRestaurantPizzas(restaurantId).then((r) => {
      setPizzas(r);
    });

    pizzeriaService.GetToppings().then((t) => {
      setToppings(t);
    });
  }, []);

  const handleAddToOrder = (pizza: Pizza) => {
    setShowToppingPopup(true);
    setPizzaOrder({
      pizza: pizza,
      extraToppings: [],
      id: 0,
      totalCost: 0,
    } as PizzaOrder);
  };

  const handleConfirmToOrder = () => {
    if (!order) {
      pizzeriaService
        .CreateNewOrder(
          restaurantId,
          pizzaOrder?.pizza?.id || 0,
          pizzaOrder?.extraToppings.map((t) => t.id)
        )
        .then((o) => {
          setOrder(o);
        });
    } else {
      pizzeriaService
        .AddPizzaToOrder(
          order.id,
          pizzaOrder?.pizza?.id || 0,
          pizzaOrder?.extraToppings.map((t) => t.id)
        )
        .then(() => {
          pizzeriaService.GetOrder(order?.id || 0).then((o) => {
            setOrder(o);
          });
        });
    }
    setShowOrder(true);
    setShowToppingPopup(false);
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
      {showToppingPopup && (
        <EditPizzaOrderPopup
          pizzaOrder={pizzaOrder}
          toppingsOptions={toppings}
          onCancel={() => setShowToppingPopup(false)}
          onAddToOrder={handleConfirmToOrder}
        />
      )}
      {order && showOrder && (
        <OrderSummary
          order={order}
          onRemovePizzaOrder={handleRemoveFromOrder}
          onCloseOrderSummary={() => setShowOrder(false)}
        />
      )}
      <section>
        <h1>{restaurant && restaurant.name}</h1>
        {order && !showOrder && (
          <Button label="Show Order" onClick={() => setShowOrder(true)} />
        )}
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
