import { Order } from "../../Models/Order";
import { Utility } from "../../Services/Utility";
import "./OrderSummary.css";
import { OrderSummaryItem } from "./OrderSummaryItem";

export interface IOrderSummaryProps {
  order?: Order;
  onRemovePizzaOrder: (pizzaOrderId: number) => void;
}

export const OrderSummary = (props: IOrderSummaryProps) => {
  return (
    <div className="order-summary">
      <header>
        <h3>
          Order <span>({props.order?.restaurantId})</span>
        </h3>
      </header>
      <section>
        {props.order?.pizzaOrders?.map((p, i) => (
          <OrderSummaryItem
            key={i}
            pizzaOrder={p}
            onRemove={() => props.onRemovePizzaOrder(p.id)}
          />
        ))}
      </section>
      <footer>
        <div>Total: {Utility.formatCurrency(props.order?.totalCost || 0)}</div>
      </footer>
    </div>
  );
};
