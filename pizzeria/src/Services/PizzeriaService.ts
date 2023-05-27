import axios from "axios";
import { Restaurant } from "../Models/Restaurant";
import { Pizza } from "../Models/Pizza";
import { Order } from "../Models/Order";

export class PizzeriaService {
  constructor() {
    axios.defaults.baseURL = "https://localhost:44314/";
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

  CreateNewOrder = async (restaurantId: number, pizzaId: number): Promise<Order> => {
    return (await axios.post(`order`, { restaurantId: restaurantId, pizzaId: pizzaId})).data;
  }

  AddPizzaToOrder = async (orderId: number, pizzaId: number): Promise<void> => {
    return (await axios.post(`order/pizza-order`, { orderId: orderId, pizzaId: pizzaId}));
  };

  RemovePizzaFromOrder = async (pizzaOrderId: number): Promise<void> => {
    return (await axios.delete(`order/pizza-order/${pizzaOrderId}`));
  };
}
