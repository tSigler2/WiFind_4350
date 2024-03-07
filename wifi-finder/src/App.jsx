// App.js
import React from 'react';
import Header from './components/Header.jsx';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';


function App() {
  return (
  
    <div className="App">
      <div style={{ borderWidth: '1px', borderStyle: 'solid', borderColor: '#2e8b57', padding: '10px', textAlign: 'center' }}>
      <Router>
        <Header />
        <Routes>
          <Route path="/" exact  /> // Replace 'Home' with your desired component
        </Routes>
      </Router>
      </div>

    </div>
  );
}

export default App;



