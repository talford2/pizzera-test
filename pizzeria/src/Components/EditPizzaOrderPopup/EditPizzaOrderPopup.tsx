import { PizzaOrder } from "../../Models/PizzaOrder";
import { Topping } from "../../Models/Topping";
import { Checkbox } from "../Checkbox/Checkbox";
import "./EditPizzaOrderPopup.css";
import { Utility } from "../../Services/Utility";
import { Button } from "../Button/Button";
import React from "react";

export interface IEditPizzaOrderPopupProps {
  pizzaOrder?: PizzaOrder;
  toppingsOptions: Topping[];
  onAddToOrder?: () => void;
  onCancel?: () => void;
}

export const EditPizzaOrderPopup = (props: IEditPizzaOrderPopupProps) => {
  const [pizzaOrder, setPizzaOrder] = React.useState<PizzaOrder | undefined>(
    props.pizzaOrder
  );

  const handleToppingChanged = (check: boolean, topping: Topping) => {
    const localPizzaOrder = { ...pizzaOrder } as PizzaOrder;
    if (check) localPizzaOrder.extraToppings.push(topping);
    else
      localPizzaOrder.extraToppings = localPizzaOrder.extraToppings.filter(
        (t) => t.id !== topping.id
      );

    setPizzaOrder(localPizzaOrder);
  };

  return (
    <div className="popup">
      <header>
        <h2>Add Pizza</h2>
      </header>

      <section>
        <p>{props.pizzaOrder?.pizza?.name}</p>

        <h3>Additional Toppings</h3>
        {props.toppingsOptions.map((t) => (
          <Checkbox
            key={t.id}
            label={`${t.name} - ${Utility.formatCurrency(t.price)}`}
            checked={false}
            onChange={handleToppingChanged}
            data={t}
          />
        ))}
      </section>
      <footer>
        <Button label="Cancel" onClick={props.onCancel} />
        <Button label="Add to Order" onClick={props.onAddToOrder} />
      </footer>
    </div>
  );
};
