import axios from "axios";
import { Restaurant } from "../Models/Restaurant";
import { Pizza } from "../Models/Pizza";
import { Order } from "../Models/Order";
import { Topping } from "../Models/Topping";

export class PizzeriaService {
  constructor() {
    axios.defaults.baseURL = "https://localhost:7032/";
  }

  GetRestaurants = async (): Promise<Restaurant[]> => {
    return (await axios.get("restaurant")).data;
  };

  GetRestaurant = async (id: number): Promise<Restaurant> => {
    return (await axios.get(`restaurant/${id}`)).data;
  };

  GetRestaurantPizzas = async (id: number): Promise<Pizza[]> => {
    return (await axios.get(`restaurant/${id}/pizza`)).data;
  };

  GetOrder = async (orderId: number): Promise<Order> => {
    return (await axios.get(`order/${orderId}`)).data;
  };

  CreateNewOrder = async (
    restaurantId: number,
    pizzaId: number,
    additionalToppings?: number[]
  ): Promise<Order> => {
    return (
      await axios.post(`order`, {
        restaurantId: restaurantId,
        pizzaId: pizzaId,
        toppingIds: additionalToppings,
      })
    ).data;
  };

  AddPizzaToOrder = async (
    orderId: number,
    pizzaId: number,
    additionalToppings?: number[]
  ): Promise<void> => {
    return await axios.post(`order/pizza-order`, {
      orderId: orderId,
      pizzaId: pizzaId,
      toppingIds: additionalToppings,
    });
  };

  RemovePizzaFromOrder = async (pizzaOrderId: number): Promise<void> => {
    return await axios.delete(`order/pizza-order/${pizzaOrderId}`);
  };

  GetToppings = async (): Promise<Topping[]> => {
    return (await axios.get(`toppings`)).data;
  };

  DeleteOrder = async (orderId: number): Promise<void> => {
    return await axios.delete(`order/${orderId}`);
  };
}
