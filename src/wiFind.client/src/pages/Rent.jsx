import React, { useEffect, useState } from "react";
import "../App.css";
import Footer from '../components/Footer';

function Rent() {
    const [rentedWifis, setRentedWifis] = useState([]); // State to store the rented WiFis

    useEffect(() => {
        const fetchRentedWifis = async () => {
            try {
                const response = await fetch(`https://localhost:7042/api/Rent/getrenterview?username=${localStorage.getItem("username")}`, {
                    method: 'GET',
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem("token"),
                    }
                });
    
                if (!response.ok) {
                    throw new Error('Server response was not ok.');
                }
    
                const data = await response.json();
    
                if (Array.isArray(data)) {
                    setRentedWifis(data);
                } else {
                    console.error('Error: Expected an array but received', data);
                }
            } catch (error) {
                console.error('Error:', error);
            }
        };
    
        fetchRentedWifis();
    }, []);
    return (
        <div>
            <h1>Rent</h1>
            <p>Rent Wifi</p>
            {rentedWifis.map(wifi => ( // Map over the rented WiFis and display them
                <div key={wifi.rentID}>
                    <p>Wifi ID: {wifi.wifiID}</p>
                    <p>Start: {new Date(wifi.start).toLocaleString()}</p>
                    <p>End: {new Date(wifi.end).toLocaleString()}</p>
                    <p>Locked Rate: {wifi.locked_rate}</p>
                    <p>Guest Password: {wifi.guest_password}</p>
                </div>
            ))}
            <Footer /> {/* Include the Footer component */}
        </div>
    );
}

export default Rent;