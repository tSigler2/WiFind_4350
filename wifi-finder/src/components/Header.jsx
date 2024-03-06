import React from 'react';
import '../App.css';

function Header() {
    return (
        <header className="header">
            <nav className="navbar">
                <h1 className="navbar__title">WiFi Finder & Rentals</h1>
                <div className="navbar__links">
                    <a href="/home">Home</a>
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