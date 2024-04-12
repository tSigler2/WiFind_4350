/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from "react";
import { useContext } from "react";
import { CartContext } from "../components/CartContext.jsx";
import { useNavigate } from "react-router-dom";
import "./List.css"; // Import List page-specific styles
import Footer from '../components/Footer'; 
import * as Placeholders from '../placeholders/placeholders.jsx'

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
        //let data = Placeholders.wifilistings;
        const data = await response.json();
        //console.log(data); 
        setWifiListings(data);
    }

    const contents = wifiListings === undefined
        ? <p><em>Loading...</em></p>
        : wifiListings.map(listing => (
            <div key={listing.wifi_name} className="list-card">
                <div className="list-card-content">
                    <h3 className="list-card-title">{listing.wifi_name}</h3>
                    <p className="list-card-description">Hourly Rate: ${listing.curr_rate.toFixed(2)}</p>
                    <p className="list-card-description">Security: {listing.security}</p>
                    <p className="list-card-description">Source: {listing.wifi_source}</p>
                    <p className="list-card-description">Download: {listing.download_speed} Mbps</p>
                    <p className="list-card-description">Upload: {listing.upload_speed} Mbps</p>
                    <p className="list-card-description">Listed by: {listing.owned_by}</p>
                    <p className="list-card-description">Max Users: {listing.max_users}</p>
                    <p className="list-card-description">Listed On: {(listing.time_listed+"").substring(0, (listing.time_listed+"").indexOf("T"))}</p>
                    <button className="list-card-button" onClick={() => { addToCart(listing); alert(listing.wifi_name+"added to cart.") } }>Add to Cart</button>
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
