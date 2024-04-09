// Footer.jsx
import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFacebook, faInstagram, faTwitter } from '@fortawesome/free-brands-svg-icons';
import './Footer.css'; // Import Footer-specific styles

function Footer() {
    return (
        <footer className="footer-container">
            <div className="social-icons">
                <a href="https://www.facebook.com/example" target="_blank" rel="noopener noreferrer">
                    <FontAwesomeIcon icon={faFacebook} className="social-icon" />
                </a>
                <a href="https://www.instagram.com/example" target="_blank" rel="noopener noreferrer">
                    <FontAwesomeIcon icon={faInstagram} className="social-icon" />
                </a>
                <a href="https://twitter.com/example" target="_blank" rel="noopener noreferrer">
                    <FontAwesomeIcon icon={faTwitter} className="social-icon" />
                </a>
            </div>
            <div className="copyright">
                <p>&copy; 2024 WiFinder & Rentals. All rights reserved.</p>
            </div>
        </footer>
    );
}

export default Footer;
