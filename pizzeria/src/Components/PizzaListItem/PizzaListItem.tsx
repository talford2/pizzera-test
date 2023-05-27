import { Pizza } from "../../Models/Pizza";
import { Utility } from "../../Services/Utility";
import { Button } from "../Button/Button";
import "./PizzaListItem.css";

export interface IPizzaListItemProps {
  pizza: Pizza;
  onAddToOrder: (pizza: Pizza) => void
}

export const PizzaListItem = (props: IPizzaListItemProps) => {
  return (
    <div className="pizza-list-item">
      <h3>{props.pizza.name}</h3>
      <ul>
        {props.pizza.baseIngredients.map((i) => (
          <li key={i}>{i}</li>
        ))}
      </ul>
      <strong className="price">
        {Utility.formatCurrency(props.pizza.basePrice)}
      </strong>
      <Button label="Add to Order" onClick={() => props.onAddToOrder(props.pizza)} />
    </div>
  );
};
