import React from 'react';
import '../App.css';
import { Link, useNavigate } from 'react-router-dom';

function Header() {
    const token = localStorage.getItem("token");
    const navigate = useNavigate(); // Get the navigate function

    const handleLogout = () => {
        localStorage.removeItem("token"); // Remove the token from local storage
        navigate("/login"); // Redirect to the login page
    }

    return (
        <header className="header">
            <nav className="navbar">
                <Link to="/" className='navbar__title'>
                    WiFi Finder & Rentals
                </Link>
                <div className="navbar__links">
                    <Link to="/rent">Rent</Link>
                    <Link to="/list">List</Link>
                    <Link to="/about">About</Link>
                    <Link to="/contact">Contact</Link>
                    {token && token !== '' ? <Link to="/logout" onClick={handleLogout}>Logout</Link> : <Link to="/login">Login</Link>}
                    <Link to="/checkout">Checkout</Link>
                </div>
            </nav>
        </header>
    );
}

export default Header; 