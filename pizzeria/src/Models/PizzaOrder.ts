import { Pizza } from "./Pizza";
import { Topping } from "./Topping";

export class PizzaOrder {
  id: number = 0;
  pizza?: Pizza;
  extraToppings: Topping[] = [];
  totalCost: number = 0;
}
