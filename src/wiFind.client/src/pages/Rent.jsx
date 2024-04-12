import React, { useEffect, useState } from "react";
import "../App.css";
import Footer from '../components/Footer';

function Rent() {
    const [rentedWifis, setRentedWifis] = useState([]); // State to store the rented WiFis
    const [listedWifis, setListedWifis] = useState([]); // State to store the listed WiFis
    const [wifiData, setWifiData] = useState({ // State to store the wifi data from the form
        wifi_name: "",
        security: "",
        download_speed: 0,
        upload_speed: 0,
        wifi_latitude: 0,
        wifi_longitude: 0,
        radius: 0,
        wifi_source: "",
        curr_rate: 0,
        max_users: 0
    });

    // These are the wifis that the user is renting out at this time
    useEffect(() => {
        const fetchRentedWifis = async () => {
            try {
                const response = await fetch('https://localhost:7042/api/Rent/getrenterview', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer ' + localStorage.getItem("token"),
                    },
                    body: JSON.stringify({username:localStorage.getItem("username")})
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

    // These are the Wifi's that are actually being rented by the user at this time
    useEffect(() => {
        const fetchListedWifis = async () => {
            try {
                const response = await fetch('https://localhost:7042/api/Rent/getrenteeview', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer ' + localStorage.getItem("token"),
                    },
                    body: JSON.stringify({username:localStorage.getItem("username")})
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

    const handleInputChange = (event) => {
        setWifiData({
            ...wifiData,
            [event.target.name]: event.target.value
        });
    };

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

    return (
        <div>
            <h1>Rent</h1>
            <h2>My Rented Out Wifis</h2>
            {rentedWifis.map(wifi => (
                <div key={wifi.rentID}>
                    <p>Wifi ID: {wifi.wifi_id}</p>
                    <p>Number of Users Renting: {wifi.num_users_renting}</p>
                </div>
            ))}
            <h2>List your Wifi</h2>
            <form onSubmit={handleSubmit}>
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
                <button type="submit">List Wifi</button>
            </form>
            <h2>Wifis I am Renting</h2>
            {listedWifis.map(wifi => (
                <div key={wifi.rentID}>
                    <p>Wifi ID: {wifi.wifiID}</p>
                    <p>Start: {new Date(wifi.start).toLocaleString()}</p>
                    {/*<p>End: {new Date(wifi.end).toLocaleString()}</p>*/}
                    <p>Locked Rate: {wifi.locked_rate}</p>
                    <p>Guest Password: {wifi.guest_password}</p>
                </div>
            ))}
            <Footer /> {/* Include the Footer component */}
        </div>
    );
}

export default Rent;