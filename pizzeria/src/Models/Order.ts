import { PizzaOrder } from "./PizzaOrder";
import { Restaurant } from "./Restaurant";

export class Order {
  id: number = 0;
  restaurant?: Restaurant;
  pizzaOrders: PizzaOrder[] = [];
  totalCost: number = 0;
}
