import { PizzaOrder } from "../../Models/PizzaOrder";
import { Utility } from "../../Services/Utility";
import { Button } from "../Button/Button";

export interface IOrderSummaryItemProps {
  pizzaOrder: PizzaOrder;
  onRemove: () => void;
}

export const OrderSummaryItem = (props: IOrderSummaryItemProps) => {
  return (
    <div>
      <strong>{props.pizzaOrder.pizza?.name}</strong>
      <span>
        {Utility.formatCurrency(props.pizzaOrder.pizza?.basePrice || 0)}
      </span>
      <Button label="Remove" onClick={props.onRemove} />
    </div>
  );
};
