import React from "react";
import data from "../rentOptions.json";
import { useContext } from "react";
import { CartContext } from "../components/CartContext.jsx";
import "./Rent.css"; // Import Rent page-specific styles

function Rent() {
    const rentOptions = data.options;
    const { addToCart } = useContext(CartContext);

    // Divide rent options into different categories
    const standardOptions = rentOptions.filter(option => option.name === "Standard Wi-Fi Rental");
    const businessOptions = rentOptions.filter(option => option.name === "Business Wi-Fi Rental");
    const premiumOptions = rentOptions.filter(option => option.name === "Premium Wi-Fi Rental");
    const secureOptions = rentOptions.filter(option => option.name === "Secure Wi-Fi Rental");
    const flexibleOptions = rentOptions.filter(option => option.name === "Flexible Wi-Fi Rental");
    const customOptions = rentOptions.filter(option => option.name === "Custom Wi-Fi Rental");
    const familyOptions = rentOptions.filter(option => option.name === "Family Wi-Fi Plan");
    const eventOptions = rentOptions.filter(option => option.name === "Event Wi-Fi Rental");
    const travelOptions = rentOptions.filter(option => option.name === "Traveler's Wi-Fi Pass");
    const emergencyOptions = rentOptions.filter(option => option.name === "Emergency Wi-Fi Backup");

    return (
        <div className="rent-container">
            <h1 className="rent-title">Find Your Plan</h1>
            <div className="rent-row">
                <div className="rent-options">
                    {renderRentOptions(standardOptions, addToCart)}
                </div>
                <div className="rent-options">
                    {renderRentOptions(businessOptions, addToCart, "business")}
                </div>
                <div className="rent-options">
                    {renderRentOptions(premiumOptions, addToCart)}
                </div>
            </div>
            <div className="rent-row">
                <div className="rent-options">
                    {renderRentOptions(secureOptions, addToCart)}
                </div>
                <div className="rent-options">
                    {renderRentOptions(flexibleOptions, addToCart)}
                </div>
                <div className="rent-options">
                    {renderRentOptions(customOptions, addToCart, "custom")}
                </div>
            </div>
            <div className="rent-row">
                <div className="rent-options">
                    {renderRentOptions(familyOptions, addToCart)}
                </div>
                <div className="rent-options">
                    {renderRentOptions(eventOptions, addToCart)}
                </div>
            </div>
            <div className="rent-row">
                <div className="rent-options">
                    {renderRentOptions(travelOptions, addToCart)}
                </div>
                <div className="rent-options">
                    {renderRentOptions(emergencyOptions, addToCart)}
                </div>
            </div>
        </div>
    );
}

// Function to render rent options
function renderRentOptions(rentOptions, addToCart, customClass) {
    return rentOptions.map((option) => (
        <div key={option.name} className={`rent-card ${customClass ? customClass : ""}`}>
            <div className="rent-card-content">
                <h3 className="rent-card-title">{option.name}</h3>
                <p className="rent-card-price">{renderPrice(option.price)}</p>
                <p className="rent-card-description">{option.description}</p>
                <ul className="rent-card-features">
                    {option.features.map((feature, index) => (
                        <li key={index}>{feature}</li>
                    ))}
                </ul>
                <button className="rent-card-button" onClick={() => addToCart(option)}>Add to Cart</button>
            </div>
        </div>
    ));
}

// Function to render price
function renderPrice(price) {
    return price === 'Varies' || price === 'Contact for quote' ? price : `$${price.toFixed(2)}`;
}

export default Rent;
