import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

function Profile() {
    const [user, setUser] = useState(null);
    const [rentedWifi, setRentedWifi] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        // Fetch the user data and rented Wi-Fi when the component mounts
        /*
        fetch('/api/user', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
        .then(response => response.json())
        .then(data => setUser(data));

        fetch('/api/rentedWifi', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
        .then(response => response.json())
        .then(data => setRentedWifi(data));
        */
    }, []);

    const handleUpdateAccount = (newData) => {
        // Update the user data
        /*
        fetch('/api/user', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            },
            body: JSON.stringify(newData)
        })
        .then(response => response.json())
        .then(data => setUser(data));
        */
    };

    const handleLogout = () => {
        // Clear the token and navigate to the login page
        localStorage.removeItem('token');
        navigate('/login');
    };

    if (!user || !rentedWifi) {
        // If the data hasn't loaded yet, render a loading message
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h1>Profile</h1>
            <h2>Your Account</h2>
            <AccountForm user={user} onUpdate={handleUpdateAccount} />
            <h2>Your Rented Wi-Fi</h2>
            <WifiList wifi={rentedWifi} />
            <button onClick={handleLogout}>Logout</button>
        </div>
    );
}

export default Profile;