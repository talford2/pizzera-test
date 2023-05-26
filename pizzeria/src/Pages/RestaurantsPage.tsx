import { useEffect } from "react";
import { PizzeriaService } from "../Services/PizzeriaService";
import React from "react";
import { RestaurantList } from "../Components/RestaurantList/RestaurantList";

export const RestaurantsPage = () => {
  const pizzeriaService = new PizzeriaService();
  const [restaurants, setRestaurants] = React.useState<any[] | undefined>();

  useEffect(() => {
    pizzeriaService.GetRestaurants().then((r) => {
      console.log("Restaurants", r);
      setRestaurants(r);
    });
  }, []);

  return (
    <section>
      <h1>Restaurants</h1>
      {restaurants && <RestaurantList restaurants={restaurants} />}
    </section>
  );
};
