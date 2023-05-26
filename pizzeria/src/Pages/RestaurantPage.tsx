import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Restaurant } from "../Models/Restaurant";
import React from "react";
import { PizzeriaService } from "../Services/PizzeriaService";
import { Pizza } from "../Models/Pizza";



export const RestaurantPage = () => {
    const pizzeriaService = new PizzeriaService();
    const params = useParams();
    const [restaurant, setRestaurant] = React.useState<Restaurant>();
    const [pizzas, setPizzas] = React.useState<Pizza[]>();
    
    useEffect(() => {
        const restaurantId = parseInt(params.id || "0");

        pizzeriaService.GetRestaurant(restaurantId).then(r => {
            setRestaurant(r);
        });

        pizzeriaService.GetRestaurantPizzas(restaurantId).then(r => {
            setPizzas(r);
        });

    }, []);

    const formatCurrency = (amount: number): string => new Intl.NumberFormat('en-AU', { style: 'currency', currency: 'AUD' }).format(amount);

    return (
        <section>
            <h1>{restaurant && restaurant.name}</h1>
            <h2>Pizza Menu</h2>
            <ul>
                {pizzas?.map(p => <li>{p.name} - {formatCurrency(p.basePrice)}</li>)}
            </ul>
        </section>
    );
}