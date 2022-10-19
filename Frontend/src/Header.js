import React from 'react';
import { Link } from 'react-router-dom';
import "./App.css";

const Header = () => {
  return (
    <div class="header"><div class="logo">Codecool Advanced</div><div class="log"><Link to="login">login</Link></div></div>
  )
}

export default Header