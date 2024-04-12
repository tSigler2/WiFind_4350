/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from "react";
import { useContext } from "react";
import { CartContext } from "../components/CartContext.jsx";
import { useNavigate } from "react-router-dom";
import "./List.css"; // Import List page-specific styles
import Footer from '../components/Footer'; 
import * as Placeholders from '../placeholders/placeholders.jsx'
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faWifi } from '@fortawesome/free-solid-svg-icons';

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
                <FontAwesomeIcon icon={faWifi} className="wifi-icon" style={{ fontWeight: "bold" }} />
                    <h3 className="list-card-title">{listing.wifi_name}</h3>
                    <span>
                    <p className="list-card-description"><span className="list-card-label">Hourly Rate:</span> ${listing.curr_rate.toFixed(2)}</p>
                    <p className="list-card-description"><span className="list-card-label">Security:</span> {listing.security}</p>
                    <p className="list-card-description"><span className="list-card-label">Source:</span> {listing.wifi_source}</p>
                    <p className="list-card-description"><span className="list-card-label">Download:</span> {listing.download_speed} Mbps</p>
                    <p className="list-card-description"><span className="list-card-label">Upload:</span> {listing.upload_speed} Mbps</p>
                    <p className="list-card-description"><span className="list-card-label">Listed by:</span> {listing.owned_by}</p>
                    <p className="list-card-description"><span className="list-card-label">Max Users:</span> {listing.max_users}</p>
                    <p className="list-card-description"><span className="list-card-label">Listed On:</span> {(listing.time_listed+"").substring(0, (listing.time_listed+"").indexOf("T"))}</p>
                    </span>
                    <button className="list-card-button" onClick={ () => { addToCart(listing) } }>Add to Cart</button>
                    <ToastContainer />
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