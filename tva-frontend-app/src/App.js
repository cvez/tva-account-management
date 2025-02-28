import React from 'react';
import { Route, Routes, Link } from 'react-router-dom';
import './App.css';
import Home from './components/Home';
import Persons from './components/Persons';
import About from './components/About';
import Contact from './components/Contact';
import PersonDetails from './components/PersonDetails';
import AccountDetails from './components/AccountDetails';
import TransactionDetails from './components/TransactionDetails';
import Principles from './components/Principles';

function App() {
  return (
    <div>
      <header className="App-header">
        <div className="language-selector">
          <label htmlFor="language">Language:</label>
          <select id="language" name="language">
            <option value="en">English</option>
            <option value="es">Spanish</option>
          </select>
        </div>
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
        <Route path="/" element={
          <>
            <Home />
            <Principles />
          </>
        } />
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