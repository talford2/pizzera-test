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
      <div className="item-title">
        <strong>{props.pizzaOrder.pizza?.name}</strong>
        <Button label="Remove" onClick={props.onRemove} />
      </div>

      {props.pizzaOrder.extraToppings.length > 0 && (
        <div className="extra-topping">
          <strong>Additional toppings</strong>
          {props.pizzaOrder.extraToppings?.map((t) => (
            <div key={t.id}>
              <span className="topping-name">{t.name}</span>
              <span className="topping-cost">
                +{Utility.formatCurrency(t.price)}
              </span>
            </div>
          ))}
        </div>
      )}
      <div className="item-total">
        <span>Cost</span>
        <span className="cost">
          {Utility.formatCurrency(props.pizzaOrder.totalCost)}
        </span>
      </div>
    </div>
  );
};
