import { Pizza } from "../../Models/Pizza";
import { Utility } from "../../Services/Utility";
import "./PizzaListItem.css";

export interface IPizzaListItemProps {
  pizza: Pizza;
}

export const PizzaListItem = (props: IPizzaListItemProps) => {
  return (
    <div className="pizza-list-item">
      <h3>{props.pizza.name}</h3>
      <ul>
        {props.pizza.baseIngredients.map((i) => (
          <li>{i}</li>
        ))}
      </ul>
      <strong className="price">
        {Utility.formatCurrency(props.pizza.basePrice)}
      </strong>
    </div>
  );
};
