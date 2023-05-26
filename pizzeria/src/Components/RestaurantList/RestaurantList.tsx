import { Link } from "react-router-dom";
import { Restaurant } from "../../Models/Restaurant";

export interface IRestaurantListProps {
  restaurants: Restaurant[];
}

export const RestaurantList = (props: IRestaurantListProps) => {
  return (
    <ul>
      {props.restaurants.map((r) => {
        return (
          <li>
            <Link to={`/restaurants/${r.id}`}>{r.name}</Link>
          </li>
        );
      })}
    </ul>
  );
};
