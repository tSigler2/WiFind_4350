import React from 'react';
import { Link } from 'react-router-dom';
import logo from '../assets/download.png';
function Header() {
    return (
        <header className="header">
            <nav className="navbar-container">
                <div className="navbar__logo">
                    <Link to="/home">
                        <img src={logo} alt="Logo" className='logo'/>
                        <h1>Wifi-Finder and Renter</h1>
                    </Link>
                </div>
                <div className="navbar__links">
                    <a href="/rent">Rent WiFi</a>
                    <a href='/rentyourwifi'>Rent Your Wifi</a>
                    <a href="/contact">Contact</a>
                    <a href="/login">Login</a>
                </div>
            </nav>
        </header>
    );
}

export default Header;
