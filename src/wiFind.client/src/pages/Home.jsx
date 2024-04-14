/* eslint-disable no-unused-vars */
// Home.jsx
import React from 'react';
import '../App.css';
import HeroSection from '../components/HeroSection.jsx';
import  Footer from '../components/Footer.jsx'
import Feedbacks from '../components/Feedbacks';

function Home() {
    return (
        <div>
            <HeroSection />
            <Footer />
            <Feedbacks />
        </div>
    );
}

export default Home;
