import React, { useContext } from 'react';
import { CartContext } from '../components/CartContext';
import './Checkout.css'; // Import Checkout page-specific styles
import Footer from '../components/Footer'; 
import PaymentForm from '../components/PaymentForm'; 

function Checkout() {
  const { cart } = useContext(CartContext);

  // Calculate total price
  const totalPrice = cart.reduce((total, item) => total + item.price * item.quantity, 0);

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
                <h2>{item.name}</h2>
                <p>{item.description}</p>
                <p>Price: ${item.price}</p>
                <div className="quantity-selector">
                  Quantity: 
                  <input 
                    type="number" 
                    value={item.quantity} 
                    onChange={(e) => console.log(e.target.value)} // Implement quantity change logic
                    min="1" 
                  />
                </div>
              </div>
            ))}
            <div className="total-price">Total Price: ${totalPrice.toFixed(2)}</div>
            <PaymentForm /> {/* Include the PaymentForm component */}
            <button className="checkout-button">Proceed to Checkout</button>
          </div>
        )}
      </div>
      <Footer /> 
    </div>
  );
}

export default Checkout;
