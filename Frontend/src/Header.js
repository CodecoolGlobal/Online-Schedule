import React from 'react';
import { Link } from 'react-router-dom';
import "./App.css";
import { useContext, useState } from 'react';
import DataContext from './dataContext/dataContext';

const Header = () => {

  const {colorTheme, setColorTheme } = useContext(DataContext);
  const clickHandler=()=> {
    if (colorTheme === 'Dark'){
      setColorTheme('Light');
    }else{
      setColorTheme('Dark');
    }
  }

  return (
    <div className={`header ${colorTheme}`}>
      <div className="logo">
        <div className='name'>
          <img className={`${colorTheme}`} src='/SeeSharp_logo.png' width="50" ></img>
        </div>
        <div className='name Space'>Codecool Advanced</div>
      </div>
      <div onClick={ ()=>clickHandler()}>{`${colorTheme}`}</div>
      <div className={`log ${colorTheme}`}><Link className={`log ${colorTheme}`} to="login">login</Link></div>
    </div>
  )
}

export default Header