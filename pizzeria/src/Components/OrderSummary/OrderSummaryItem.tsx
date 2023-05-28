import { PizzaOrder } from "../../Models/PizzaOrder";
import { Utility } from "../../Services/Utility";
import { Button } from "../Button/Button";
import "./OrderSummaryItem.css";

export interface IOrderSummaryItemProps {
  pizzaOrder: PizzaOrder;
  onRemove: () => void;
}

export const OrderSummaryItem = (props: IOrderSummaryItemProps) => {
  return (
    <div className="order-summary-item">
      <strong>{props.pizzaOrder.pizza?.name}</strong>
      <div>
        Additional toppings:{" "}
        {props.pizzaOrder.extraToppings?.map((t) => (
          <div>
            <span key={t.id}>{t.name}</span>
            <span>+{Utility.formatCurrency(t.price)}</span>
          </div>
        ))}
      </div>

      <strong>
        Total: {Utility.formatCurrency(props.pizzaOrder.totalCost)}
      </strong>
      <Button label="Remove" onClick={props.onRemove} />
    </div>
  );
};
