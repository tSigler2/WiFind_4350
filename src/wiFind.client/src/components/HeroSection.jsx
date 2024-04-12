/* eslint-disable no-unused-vars */
import React from 'react';
import backgroundImage from '../images/wifi1.jpg'; // Import the image
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function HeroSection() {
    const notify = () => toast("Click 'List' to View",
        {
            position: "top-center",
            autoClose: 2000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: false,
            progress: undefined,
            theme: "dark",
        });
  return (
    <div className="hero-section" style={{ backgroundImage: `url(${backgroundImage})` }}>
      <h1>Connect Anywhere, Anytime</h1>
          <button className="hero-button" onClick={notify}>Shop Now</button> 
    </div>
  );
}

export default HeroSection;
