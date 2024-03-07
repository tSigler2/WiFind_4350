// App.js
import React from 'react';
import Header from './components/Header.jsx';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';

function App() {
  return (
    <div className="App">
     <Router>
        <Header />
        <Routes>
          <Route path="/" exact  /> // Replace 'Home' with your desired component
        </Routes>
      </Router>
    </div>
  );
}

export default App;