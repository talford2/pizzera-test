import { Order } from "../../Models/Order";
import { Topping } from "../../Models/Topping";
import { Utility } from "../../Services/Utility";
import "./OrderSummary.css";

export interface IOrderSummaryProps {
  order?: Order;
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
          <div key={i}>
            <strong>{p.pizza?.name}</strong>
            <span>{Utility.formatCurrency(p.pizza?.basePrice || 0)}</span>

            {/* <div>
              <p>Extra toppings</p>
              {p.toppings && p.toppings.length && (
                <ul>
                  {p.toppings.map(t => <li>{t.name} - {Utility.formatCurrency(t.price)}</li>)}
                </ul>
              )}
            </div> */}
          </div>
        ))}
      </section>
      <footer>
        <div>Total: {Utility.formatCurrency(props.order?.totalCost || 0)}</div>
      </footer>
    </div>
  );
};
