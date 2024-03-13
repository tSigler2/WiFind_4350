// App.js
import React from 'react';
import Header from './components/Header.jsx';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import Home from './pages/Home.jsx';
import About from './pages/About.jsx';
import Contact from './pages/Contact.jsx';
import Rent from './pages/Rent.jsx';
import List from './pages/List.jsx';
import Login from './pages/Login.jsx';
import CreateAccount from './pages/CreateAccount.jsx';
function App() {
  return (
  
    <div className="App">
      
 
      <div style={{ borderWidth: '1px', borderStyle: 'solid', borderColor: 'transparent', padding: '10px', textAlign: 'center' }}>
      <Router>
        <Header />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/contact" element={<Contact />} />
          <Route path="/rent" element={<Rent />} />
          <Route path="/list" element={<List />} />
          <Route path="/login" element={<Login />} />
          <Route path="/create-account" element={<CreateAccount />} />
          
        </Routes>
      </Router>
      </div>

    </div>
  );
}

export default App;



