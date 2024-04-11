/* eslint-disable no-unused-vars */
import React from 'react';
import backgroundImage from '../images/wifi1.jpg'; // Import the image

function HeroSection() {
  return (
    <div className="hero-section" style={{ backgroundImage: `url(${backgroundImage})` }}>
      <h1>Connect Anywhere, Anytime</h1>
      <button className="hero-button">Shop Now</button> 
    </div>
  );
}

export default HeroSection;
