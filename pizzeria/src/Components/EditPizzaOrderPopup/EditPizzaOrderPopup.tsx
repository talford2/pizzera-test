import { PizzaOrder } from "../../Models/PizzaOrder";
import { Topping } from "../../Models/Topping";

export interface IEditPizzaOrderPopupProps
{
    pizzaOrder: PizzaOrder;
    toppingsOptions: Topping[];
}

export const EditPizzaOrderPopup = (props: IEditPizzaOrderPopupProps) => {
    return (
        <div className="popup">
            <header>Edit Pizza</header>
            <p>{props.pizzaOrder.pizza?.name}</p>

            <h3>Toppings:</h3>

        </div>
    );
};