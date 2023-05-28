import { Order } from "../../Models/Order";
import { Utility } from "../../Services/Utility";
import { Button } from "../Button/Button";
import "./OrderSummary.css";
import { OrderSummaryItem } from "./OrderSummaryItem";

export interface IOrderSummaryProps {
  order?: Order;
  onRemovePizzaOrder: (pizzaOrderId: number) => void;
  onCloseOrderSummary: () => void;
  onClearOrder: () => void;
}

export const OrderSummary = (props: IOrderSummaryProps) => {
  return (
    <div className="order-summary">
      <header>
        <h3>
          Order <span>({props.order?.restaurant?.name})</span>
        </h3>
        <Button label="Close" onClick={props.onCloseOrderSummary} />
        <Button label="Clear" onClick={props.onClearOrder} />
      </header>
      <section>
        {(props.order?.pizzaOrders?.length || 0 > 0) &&
          props.order?.pizzaOrders?.map((p, i) => (
            <OrderSummaryItem
              key={i}
              pizzaOrder={p}
              onRemove={() => props.onRemovePizzaOrder(p.id)}
            />
          ))}
        {props.order?.pizzaOrders?.length === 0 && (
          <p>There are not items in your order.</p>
        )}
      </section>
      <footer>
        <div>
          <span>Total</span>
          <strong>{Utility.formatCurrency(props.order?.totalCost || 0)}</strong>
        </div>
      </footer>
    </div>
  );
};
