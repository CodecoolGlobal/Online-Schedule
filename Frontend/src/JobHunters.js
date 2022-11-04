import React from 'react';
import { useContext, useState } from 'react';
import DataContext from './dataContext/dataContext';

const JobHunters = () => {
  const {colorTheme} = useContext(DataContext);
  return (
    
    <>
      <div className={`design ${colorTheme}`}></div>
      <h3>JobHunters</h3>
    </>
  )
}

export default JobHunters