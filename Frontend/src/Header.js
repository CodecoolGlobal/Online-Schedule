import React from 'react';
import { Link } from 'react-router-dom';
import "./App.css";

const Header = () => {
  return (
    <div className="header"><div className="logo"><img src='../public/logo192.png'></img>Codecool Advanced</div><div className="log"><Link to="login">login</Link></div></div>
  )
}

export default Header