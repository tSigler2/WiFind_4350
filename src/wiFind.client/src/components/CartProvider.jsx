import React, { useState } from 'react';
import { CartContext } from './CartContext';

export function CartProvider({ children }) {
  const [cart, setCart] = useState([]);

  function addToCart(item) {
      setCart(prevCart => [...prevCart, item]);
  }

  function removeFromCart(itemToRemove) {
    setCart(prevCart => prevCart.filter(item => item.wifi_name !== itemToRemove.wifi_name));
  }
  function clearCart() {
    setCart([]);
  }

  return (
    <CartContext.Provider value={{ cart, addToCart, removeFromCart, clearCart }}>
      {children}
    </CartContext.Provider>
  );
}