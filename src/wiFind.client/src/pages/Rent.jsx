import React, { useEffect, useState } from "react";
import "../App.css";
import "./Rent.css";
import HeroSection from "../components/RentHeroSection"; // Import the HeroSection component
import Footer from '../components/Footer';

function Rent() {
    const [rentedWifis, setRentedWifis] = useState([]); // State to store the rented WiFis
    const [listedWifis, setListedWifis] = useState([]); // State to store the listed WiFis
    const [wifiData, setWifiData] = useState({ // State to store the wifi data from the form
        wifi_name: "",
        security: "",
        download_speed: "",
        upload_speed: "",
        wifi_latitude: "",
        wifi_longitude: "",
        radius: "",
        wifi_source: "",
        curr_rate: "",
        max_users: ""
    });

    // Fetch rented WiFis
    useEffect(() => {
        const fetchRentedWifis = async () => {
            try {
                const response = await fetch('https://localhost:7042/api/Rent/getrenterview', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer ' + localStorage.getItem("token"),
                    },
                    body: JSON.stringify({ username: localStorage.getItem("username") })
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

    // Fetch listed WiFis
    useEffect(() => {
        const fetchListedWifis = async () => {
            try {
                const response = await fetch('https://localhost:7042/api/Rent/getrenteeview', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer ' + localStorage.getItem("token"),
                    },
                    body: JSON.stringify({ username: localStorage.getItem("username") })
                });

                if (!response.ok) {
                    throw new Error('Server response was not ok.');
                }

                const data = await response.json();

                if (Array.isArray(data)) {
                    setListedWifis(data);
                } else {
                    console.error('Error: Expected an array but received', data);
                }
            } catch (error) {
                console.error('Error:', error);
            }
        };

        fetchListedWifis();
    }, []);

    // Handle input changes in the form
    const handleInputChange = (event) => {
        setWifiData({
            ...wifiData,
            [event.target.name]: event.target.value
        });
    };

    // Handle form submission
    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await fetch('https://localhost:7042/api/Wifi/addwifi', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + localStorage.getItem("token"),
                },
                body: JSON.stringify(wifiData)
            });

            if (!response.ok) {
                throw new Error('Was the form filled completely?');
            }

        } catch (error) {
            console.error('Error:', error);
        }
    };
    const handleDelete = async (rentID) => {
    try {
        const response = await fetch(`https://localhost:7042/api/Rent/delete/${rentID}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token"),
            },
        });

        if (!response.ok) {
            throw new Error('Failed to delete WiFi.');
        }

        // After successful deletion, update the listedWifis state to reflect the changes
        setListedWifis(prevListedWifis => prevListedWifis.filter(wifi => wifi.rentID !== rentID));
    } catch (error) {
        console.error('Error:', error);
    }
};


    return (
        <div>
            <HeroSection /> {/* Include the HeroSection component */}
            <div className="rent-container">
                <div className="section">
            
                    <h2>Leased Wifis</h2>
                    {rentedWifis.length === 0 ? <h4>No rented out Wifis found.</h4> : rentedWifis.map(wifi => (
                        <div key={wifi.rentID}>
                            <p>Wifi ID: {wifi.wifi_id}</p>
                            <p>Number of Users Renting: {wifi.num_users_renting}</p>
                            <button onClick={() => handleDelete(wifi.rentID)}>Delete</button>
                        </div>
                    ))}
                </div>
                <div className="section">
                    <h2>List Wifi</h2>
                    <form onSubmit={handleSubmit} className="label-container">

                        <label>
                            Wifi Name:
                            <input type="text" name="wifi_name" value={wifiData.wifi_name} onChange={handleInputChange} />
                        </label>
                        <label>
                            Hourly Rate:
                            <input type="number" name="curr_rate" value={wifiData.curr_rate} onChange={handleInputChange} />
                        </label>
                        <label>
                            Security:
                            <input type="text" name="security" value={wifiData.security} onChange={handleInputChange} />
                        </label>
                        <label>
                            Source:
                            <input type="text" name="wifi_source" value={wifiData.wifi_source} onChange={handleInputChange} />
                        </label>
                        <label>
                            Download Speed:
                            <input type="number" name="download_speed" value={wifiData.download_speed} onChange={handleInputChange} />
                        </label>
                        <label>
                            Upload Speed:
                            <input type="number" name="upload_speed" value={wifiData.upload_speed} onChange={handleInputChange} />
                        </label>
                        <label>
                            Max Users:
                            <input type="number" name="max_users" value={wifiData.max_users} onChange={handleInputChange} />
                        </label>
                        <div className="button-container">
                            <button className="list-button" type="submit">List </button>
                            <button className="delete-button" onClick={handleDelete}>Delete</button>
                            </div>
                    </form>

                </div>
                <div className="section">
                    <h2>Active Rentals</h2>
                    {listedWifis.length === 0 ? <h4>No Wifis rented at this time.</h4> : listedWifis.map(wifi => (
                        <div key={wifi.rentID}>
                            <p>Wifi ID: {wifi.wifiID}</p>
                            <p>Start: {new Date(wifi.start).toLocaleString()}</p>
                            {/*<p>End: {new Date(wifi.end).toLocaleString()}</p>*/}
                            <p>Locked Rate: {wifi.locked_rate}</p>
                            <p>Guest Password: {wifi.guest_password}</p>
                            <button onClick={() => handleDelete(wifi.rentID)}>Delete</button>
                        </div>
                    ))}
                </div>
            </div>
            <Footer /> {/* Include the Footer component */}
        </div>
    );
}

export default Rent;

