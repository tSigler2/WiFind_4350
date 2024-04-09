import React, { useEffect, useState } from "react";
import { useContext } from "react";
import { CartContext } from "../components/CartContext.jsx";
import { useNavigate } from "react-router-dom";
import "./List.css"; // Import List page-specific styles
import Footer from '../components/Footer'; 

function List() {
    const [wifiListings, setWifiListings] = useState();
    const { addToCart } = useContext(CartContext);
    const navigate = useNavigate();

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
            navigate("/login"); // Redirect to login for token
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();
        console.log(data); 
        setWifiListings(data);
    }

    const contents = wifiListings === undefined
        ? <p><em>Loading...</em></p>
        : wifiListings.map(listing => (
            <div key={listing.wifi_name} className="list-card">
                <div className="list-card-content">
                    <h3 className="list-card-title">{listing.wifi_name}</h3>
                    <p className="list-card-description">Rate: {listing.curr_rate}</p>
                    <p className="list-card-description">Security: {listing.security}</p>
                    <p className="list-card-description">Source: {listing.wifi_source}</p>
                    <p className="list-card-description">Download Speed: {listing.download_speed}</p>
                    <p className="list-card-description">Upload Speed: {listing.upload_speed}</p>
                    <p className="list-card-description">Listed by: {listing.owned_by}</p>
                    <p className="list-card-description">Max users: {listing.max_users}</p>
                    <p className="list-card-description">Source: {listing.time_listed}</p>
                    <button className="list-card-button" onClick={() => addToCart(listing)}>Add to Cart</button>
                </div>
            </div>
        ));

    return (
        <div>
            <div className="list-container">
                <h1 className="list-title">Find Your Plan</h1>
                <div className="list-row">
                    {contents}
                </div>
            </div>
            <Footer /> {/* Include the Footer component */}
        </div>
    );
}

export default List;
