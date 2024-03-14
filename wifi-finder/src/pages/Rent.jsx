import React from "react";
import "../App.css";
import data from "../rentOptions.json";
import { useContext } from "react";
import { CartContext } from "../components/CartContext.jsx";
function Rent() {
    const rentOptions = data.options; // Access the "options" property of the imported data
    const { addToCart } = useContext(CartContext); // Get the addToCart function from the CartContext
    return (
        <div>
            <h1>Rent</h1>
            {rentOptions.map((option) => (
                <div key={option.name} className="card">
                    <h2>{option.name}</h2>
                    <p>{option.description}</p>
                    <p>Price: {option.price}</p>
                    <ul>
                        {option.features.map((feature) => (
                            <li key={feature}>{feature}</li>
                        ))}
                    </ul>
                    <button onClick={() => addToCart(option)}>Add to Cart</button>
                </div>
            ))}
        </div>
    );
}

export default Rent;