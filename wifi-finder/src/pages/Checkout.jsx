import React, { useContext } from 'react';
import { CartContext } from '../components/CartContext';

function Checkout() {
  const { cart } = useContext(CartContext);

  return (
    <div>
      <h1>Checkout</h1>
      {cart.map((item, index) => (
        <div key={index}>
          <h2>{item.name}</h2>
          <p>{item.description}</p>
          <p>Price: {item.price}</p>
        </div>
      ))}
    </div>
  );
}

export default Checkout;