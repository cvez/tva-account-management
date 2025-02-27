import React from 'react';
import { Route, Routes, Link } from 'react-router-dom';
import logo from './logo.png';
import './App.css';
import Home from './components/Home';
import Persons from './components/Persons';
import About from './components/About';
import Contact from './components/Contact';
import PersonDetails from './components/PersonDetails';
import AccountDetails from './components/AccountDetails';
import TransactionDetails from './components/TransactionDetails';

function App() {
  return (
    <div>
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Welcome to the Account Management Application
        </p>
        <a
          className="App-link" 
          href="http://localhost:3000/"
          target="_blank"
          rel="noopener noreferrer"
        >
        Learn our business model here 
        </a>
      </header>
      <nav className="App-nav">
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/persons">Persons</Link></li>
          <li><Link to="/about">About</Link></li>
          <li><Link to="/contact">Contact</Link></li>
        </ul>
      </nav>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/persons" element={<Persons />} />
        <Route path="/about" element={<About />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/persons/:id" element={<PersonDetails />} />
        <Route path="/accounts/:id" element={<AccountDetails />} />
        <Route path="/transactions/:id" element={<TransactionDetails />} />
      </Routes>
    </div>
  );
}

export default App;