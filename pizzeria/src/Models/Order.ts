import { PizzaOrder } from "./PizzaOrder";

export class Order {
  id: number = 0;
  restaurantId: number = 0;
  pizzaOrders: PizzaOrder[] = [];

  constructor(restaurantId: number) {
    this.restaurantId = restaurantId;
  }
}
