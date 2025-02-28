import React from 'react';
import './Footer.css';

const Footer = () => {
  return (
    <footer className="App-footer">
      <p>&copy; {new Date().getFullYear()} TVA Account Management. Licensed under the MIT License.</p>
    </footer>
  );
}

export default Footer;