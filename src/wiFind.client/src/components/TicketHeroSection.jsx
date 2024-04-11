/* eslint-disable no-unused-vars */
/* eslint-disable react/no-unescaped-entities */
import React from 'react';
import backgroundImage from '../images/wifi2.jpg'; 

function TicketHeroSection() {
  return (
    <div className="hero-section" style={{ backgroundImage: `url(${backgroundImage})` }}>
      <h1>Contact Us for Assistance</h1>
      <p>Have a question or need support? Reach out to our team and we'll be happy to help</p>
    </div>
  );
}

export default TicketHeroSection;
