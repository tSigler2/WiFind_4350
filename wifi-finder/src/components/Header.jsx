import React from 'react';
import '../App.css';
import { Link } from 'react-router-dom';
function Header() {
    return (
        <header className="header">
            <nav className="navbar">
                <Link to="/" className='navbar__title'>
                    WiFi Finder & Rentals
                </Link>
                <div className="navbar__links">
                    <Link to="/rent">Rent WiFi</Link>
                    <Link to="/list">List WiFi</Link>
                    <Link to="/about">About</Link>
                    <Link to="/contact">Contact</Link>
                    <Link to="/login">Login</Link>
                </div>
            </nav>
        </header>
    );
}

export default Header;