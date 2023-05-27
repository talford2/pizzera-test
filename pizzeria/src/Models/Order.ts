import { PizzaOrder } from "./PizzaOrder";

export class Order {
  restaurantId: number = 0;
  pizzaOrders: PizzaOrder[] = [];

  constructor(restaurantId: number) {
    this.restaurantId = restaurantId;
  }
}
