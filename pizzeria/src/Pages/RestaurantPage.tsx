import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { PizzaListItem } from "../Components/PizzaListItem/PizzaListItem";
import { Pizza } from "../Models/Pizza";
import { Restaurant } from "../Models/Restaurant";
import { PizzeriaService } from "../Services/PizzeriaService";

export const RestaurantPage = () => {
  const pizzeriaService = new PizzeriaService();
  const params = useParams();
  const [restaurant, setRestaurant] = React.useState<Restaurant>();
  const [pizzas, setPizzas] = React.useState<Pizza[]>();

  useEffect(() => {
    const restaurantId = parseInt(params.id || "0");

    pizzeriaService.GetRestaurant(restaurantId).then((r) => {
      setRestaurant(r);
    });

    pizzeriaService.GetRestaurantPizzas(restaurantId).then((r) => {
      setPizzas(r);
    });
  }, []);

  return (
    <section>
      <h1>{restaurant && restaurant.name}</h1>
      <h2>Pizza Menu</h2>
      <div>
        {pizzas?.map((p) => (
          <PizzaListItem pizza={p} />
        ))}
      </div>
    </section>
  );
};
