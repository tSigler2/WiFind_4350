import React from 'react';
import backgroundImage from '../images/wifi1.jpg'; // Import the image

function HeroSection() {
  return (
    <div className="hero-section" style={{ backgroundImage: `url(${backgroundImage})` }}>
      <h1>Welcome to WiFi Finder & Rentals</h1>
      <button>View Rental Listings</button>
    </div>
  );
}

export default HeroSection;