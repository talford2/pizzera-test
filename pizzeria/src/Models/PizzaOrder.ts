import { Pizza } from "./Pizza";
import { Topping } from "./Topping";

export class PizzaOrder 
{
    id: number = 0;
    pizza?: Pizza;
    toppings: Topping[] = [];
}