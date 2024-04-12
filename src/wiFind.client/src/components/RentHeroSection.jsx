import React from 'react';
import './RentHeroSection.css';
import backgroundImage1 from '../images/Wifiphoto.jpg';


function HeroSection() {
    return (
        <div className="hero-container">
            {/* Background image with text */}
            <div className="hero-section" style={{ backgroundImage: `url(${backgroundImage1})` }}>
                <h1>Rent WIFI Portal</h1>
                <p>Find and list WiFi networks for rent easily</p>
            </div>
        </div>
    );
}

export default HeroSection;
