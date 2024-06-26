/* eslint-disable no-unused-vars */
import React, {useContext} from 'react';
import '../App.css';
import { Link, useNavigate } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons'; 
import logo from '../images/logo-transparent.png';
import { CartContext } from './CartContext';

function Header() {
    const token = localStorage.getItem("token");
    const userrole = localStorage.getItem("user_role");
    const navigate = useNavigate(); // Get the navigate function
    const {clearCart} = useContext(CartContext); // Get the clearCart function from the CartContext
    const handleLogout = (event) => {
        event.preventDefault(); // Prevent the default action (the page reload)
        clearCart(); // Clear the cart
        localStorage.clear(); // Clear local storage
        navigate("/login"); // Redirect to the login page
    }

    return (
        <header className="header">
        <nav className="navbar"> 
            <Link to="/" className='navbar__title'>
            <img src={logo} alt="Logo" className="logo" />
            </Link>
                <div className="navbar__links">
                {token && token !== '' && userrole && userrole.includes('Admin') ? <Link to="/admin">Admin</Link> : null}
                {token && token !== '' ? <Link to="/rent">Rent</Link> : null} {/* Only show the Rent link if the user is logged in */}
                <Link to="/list">List</Link>
                <Link to="/Ticketsupport">Ticket Support</Link>
                {token && token !== '' ? <Link to="/profile">Profile</Link> : null} {/* Only show the Profile link if the user is logged in */}
                {token && token !== '' ? <a href="/logout" onClick={handleLogout}>Logout</a> : <Link to="/login">Login</Link>}
                {token && token !== '' ? <Link to="/checkout">
                <FontAwesomeIcon icon={faShoppingCart} /> {/* Display the cart icon */}
                </Link> : null} {/* Only show the Profile link if the user is logged in */}
            </div>
        </nav>
    </header>
    );
}

export default Header;