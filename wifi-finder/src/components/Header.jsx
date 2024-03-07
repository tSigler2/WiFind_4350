import React from 'react';
import '../App.css';
import { Link } from 'react-router-dom';
function Header() {
    return (
        <header className="header">
            <nav className="navbar">
            <Link to="/home">
                        <h1 className="navbar__title">WiFi Finder & Rentals</h1>
                    </Link>
                <div className="navbar__links">
                    <a href="/rent">Rent WiFi</a>
                    <a href="/sell">Sell WiFi</a>
                    <a href="/about">About</a>
                    <a href="/contact">Contact</a>
                    <a href="/login">Login</a>
                </div>
            </nav>
        </header>
    );
}

export default Header;