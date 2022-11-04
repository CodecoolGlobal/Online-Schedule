import React from 'react';
import { useContext, useState } from 'react';
import DataContext from './dataContext/dataContext';

const Missing = () => {
  const {colorTheme} = useContext(DataContext);
  
  return (
    <>
    <div className={`design ${colorTheme}`}></div>
    <h3>Missing</h3>
    </>
  )
}

export default Missing