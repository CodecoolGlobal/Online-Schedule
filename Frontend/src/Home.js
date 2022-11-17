import React from 'react'
import { useContext, useState } from 'react';
import DataContext from './dataContext/dataContext';

const Home = () => {

  const {colorTheme} = useContext(DataContext);
  return (
  <>
    <div className={`design ${colorTheme}`}></div>
    <h3>Home</h3>
    </>
  )
}

export default Home