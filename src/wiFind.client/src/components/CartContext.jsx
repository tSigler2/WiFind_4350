import { createContext } from 'react';

export const CartContext = createContext({
  cart: [], // The current state of the cart, initially an empty array
  addToCart: () => {}, // Function to add an item to the cart
  removeFromCart: () => {}, // Function to remove an item from the cart
  clearCart: () => {}, // Function to clear the cart
});