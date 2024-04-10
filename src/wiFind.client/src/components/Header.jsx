import React from 'react';
import '../App.css';
import { Link, useNavigate } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons'; 
import logo from '../images/logo-transparent.png';


function Header() {
    const token = localStorage.getItem("token");
    const navigate = useNavigate(); // Get the navigate function

    const handleLogout = (event) => {
        event.preventDefault(); // Prevent the default action
        localStorage.removeItem("token"); // Remove the token from local storage
        localStorage.removeItem("username");
        localStorage.removeItem("user_role");
        navigate("/login"); // Redirect to the home page
    }

    return (
        <header className="header">
        <nav className="navbar"> 
            <Link to="/" className='navbar__title'>
            <img src={logo} alt="Logo" className="logo" />
            </Link>
            <div className="navbar__links">
                <Link to="/rent">Rent</Link>
                <Link to="/list">List</Link>
                <Link to="/Ticketsupport">Ticket Support</Link>
                {token && token !== '' ? <Link to="/profile">Profile</Link> : null} {/* Only show the Profile link if the user is logged in */}
                {token && token !== '' ? <a href="/logout" onClick={handleLogout}>Logout</a> : <Link to="/login">Login</Link>}
                 <Link to="/checkout">
                    <FontAwesomeIcon icon={faShoppingCart} /> {/* Display the cart icon */}
                </Link>
            </div>
        </nav>
    </header>
    );
}

export default Header;