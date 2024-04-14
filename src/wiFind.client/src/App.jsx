/* eslint-disable no-unused-vars */
// App.js
import React from 'react';
import Header from './components/Header.jsx';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import Home from './pages/Home.jsx';
import TicketSupport from './pages/Ticketsupport.jsx';
import Rent from './pages/Rent.jsx';
import List from './pages/List.jsx';
import Login from './pages/Login.jsx';
import CreateAccount from './pages/CreateAccount.jsx';
import Checkout from './pages/Checkout.jsx';
import { CartProvider } from './components/CartProvider';
import Profile from './pages/Profile.jsx';
import Admin from './pages/Admin.jsx';

function App() {
  return (
    <div className="App">
      <div style={{ borderWidth: '1px', borderStyle: 'solid', borderColor: 'transparent', padding: '10px', textAlign: 'center' }}>
      <Router>
        <Header />
        <CartProvider>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/Ticketsupport" element={<TicketSupport />} />
          <Route path="/rent" element={<Rent />} />
          <Route path="/list" element={<List />} />
          <Route path="/login" element={<Login />} />
          <Route path="/create-account" element={<CreateAccount />} />
          <Route path="/checkout" element={<Checkout />} />
          <Route path="/profile" element={<Profile />} />
          <Route path="/admin" element={<Admin />}>
          </Route>
        </Routes>
        </CartProvider>
      </Router>
      </div>
    </div>
  );
}

export default App;



