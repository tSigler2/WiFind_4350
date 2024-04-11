/* eslint-disable no-unused-vars */
import React, { useContext, useState } from 'react';
import { CartContext } from '../components/CartContext';
import { useNavigate } from 'react-router-dom';
import './Checkout.css';
import Footer from '../components/Footer';
import PaymentForm from '../components/PaymentForm';

function Checkout() {
  const { cart, removeFromCart } = useContext(CartContext);
  const navigate = useNavigate();
  const [showPaymentForm, setShowPaymentForm] = useState(false);

  // Calculate total price
  const totalPrice = cart.reduce((total, item) => total + item.curr_rate, 0);

  return (
    <div>
      <div className="checkout-container">
        <h1>Checkout</h1>
        {cart.length === 0 ? (
          <p>Your cart is empty.</p>
        ) : (
          <div>
            {cart.map((item, index) => (
              <div key={index} className="checkout-item">
                <h2>{item.wifi_name}</h2>
                    <p>Hourly Rate: ${item.curr_rate.toFixed(2)}</p>
                <button onClick={() => removeFromCart(item)}>Remove from Cart</button>
              </div>
            ))}
            <div className="total-price">Total Price: ${totalPrice.toFixed(2)}</div>
            <button className="checkout-button" onClick={() => setShowPaymentForm(true)}>Proceed to Checkout</button>
            {showPaymentForm && <PaymentForm />}
          </div>
        )}
      </div>
      <Footer />
    </div>
  );
}

export default Checkout;