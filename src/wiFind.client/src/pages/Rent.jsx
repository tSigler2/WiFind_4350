import React, { useEffect, useState } from "react";
import { useContext } from "react";
import { CartContext } from "../components/CartContext.jsx";
import "./Rent.css"; // Import Rent page-specific styles

function Rent() {
    const [wifiListings, setWifiListings] = useState();
    const { addToCart } = useContext(CartContext);

    useEffect(() => {
        populateWifiListings();
    }, []);

    async function populateWifiListings() {
        const token = localStorage.getItem('token');
        const response = await fetch('https://localhost:7042/api/Wifi/wifilistings', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();
        console.log(data);
        setWifiListings(data);
    }

    const contents = wifiListings === undefined
        ? <p><em>Loading...</em></p>
        : wifiListings.map(listing => (
            <div key={listing.wifi_name} className="rent-card">
                <div className="rent-card-content">
                    <h3 className="rent-card-title">{listing.wifi_name}</h3>
                    <p className="rent-card-description">Rate: {listing.curr_rate}</p>
                    <p className="rent-card-description">Security: {listing.security}</p>
                    <p className="rent-card-description">Source: {listing.wifi_source}</p>
                    <p className="rent-card-description">Download Speed: {listing.download_speed}</p>
                    <p className="rent-card-description">Upload Speed: {listing.upload_speed}</p>
                    <p className="rent-card-description">Listed by: {listing.owned_by}</p>
                    <p className="rent-card-description">Max users: {listing.max_users}</p>
                    <p className="rent-card-description">Source: {listing.time_listed}</p>
                    <button className="rent-card-button" onClick={() => addToCart(listing)}>Add to Cart</button>
                </div>
            </div>
        ));

    return (
        <div className="rent-container">
            <h1 className="rent-title">Find Your Plan</h1>
            <div className="rent-row">
                {contents}
            </div>
        </div>
    );
}

export default Rent;