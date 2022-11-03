import React from 'react';
import { Link } from 'react-router-dom';
import "./App.css";

const Header = () => {
  return (
    <div className="header">
      <div className="logo">
        <div className='name'>
          <img src='/SeeSharp_logo.png' width="50" ></img>
        </div>
        <div className='name Space'>Codecool Advanced</div>
      </div>
      <div className="log"><Link to="login">login</Link></div>
    </div>
  )
}

export default Header