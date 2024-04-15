/* eslint-disable no-unused-vars */
import React, { useContext, useState } from 'react';
import { CartContext } from '../components/CartContext';
import './Checkout.css';
import Footer from '../components/Footer';

function Checkout() {
  const { cart, removeFromCart } = useContext(CartContext);

  // Calculate total price
  const totalPrice = cart.reduce((total, item) => total + item.curr_rate, 0);

  return (
    <div>
      <div className="checkout-container">
          <div>
            {cart.map((item, index) => (
              <div key={index} className="checkout-item">
                <h2>{item.wifi_name}</h2>
                    <p>Hourly Rate: ${item.curr_rate.toFixed(2)}</p>
                <button onClick={() => removeFromCart(item)}>Remove from Cart</button>
              </div>
            ))}
            <div className="total-price">Total Price: ${totalPrice.toFixed(2)}</div>
          </div>
      </div>
    </div>
  );
}

export default Checkout;