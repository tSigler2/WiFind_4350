/* eslint-disable no-unused-vars */
import * as React from 'react';
import CardCarousel from './CardCarousel.jsx'
function Feedbacks() {
    return (
        <div style={{ position: 'fixed', left: '50px', bottom: '65px', width: '300px' }}>
            <div style={{ maxWidth: '600px'}}>
                <CardCarousel></CardCarousel>
            </div>
        </div>
    );
}

export default Feedbacks;