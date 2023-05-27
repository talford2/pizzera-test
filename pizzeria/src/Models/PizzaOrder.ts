import { Pizza } from "./Pizza";
import { Topping } from "./Topping";

export class PizzaOrder 
{
    pizza?: Pizza;
    toppings: Topping[] = [];
}