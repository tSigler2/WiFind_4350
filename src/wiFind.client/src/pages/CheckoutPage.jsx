/* eslint-disable no-unused-vars */
import React, { useContext, useState } from 'react';
import Checkout from './Checkout';
import PaymentForm from '../components/PaymentForm';
import { CartContext } from '../components/CartContext';
import Footer from '../components/Footer';

const CheckoutPage = () => {
    const { cart } = useContext(CartContext);
    const [showPaymentForm, setShowPaymentForm] = useState(false);

    return (
        <div style={{ display: 'block' }}>
            <div style={{ display: 'inline-block' }}>
                <h1>Checkout</h1>
                {cart.length === 0 ? (<p>Your cart is empty.</p>) : (<Checkout></Checkout>) }
            </div>
            <div style={{ display: 'block', paddingBottom: '20%'}}>
                {cart.length === 0 ? (null) :
                    (<button className="checkout-button" onClick={() => setShowPaymentForm(!showPaymentForm)}>Proceed to Checkout</button>)}
                    {showPaymentForm && <div><PaymentForm /> </div>}
            </div>
            <Footer></Footer>
        </div>
        
    );
}

export default CheckoutPage;