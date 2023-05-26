import axios from "axios";
import { Restaurant } from "../Models/Restaurant";
import { Pizza } from "../Models/Pizza";

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
}
