import React from 'react';
import useAxiosFetch from './hooks/useAxiosFetch';
import { Link } from 'react-router-dom';
import { useContext, useState } from 'react';
import DataContext from './dataContext/dataContext';
const Teams = () => {
  let url = 'https://localhost:7086/api/teams';
  const { data, fetchError, isLoading } = useAxiosFetch(url);

  const {colorTheme } = useContext(DataContext);
  return (
    <>
    
      {isLoading && <p className="statusMsg">Loading ...</p>}
      {!isLoading && fetchError && (
        <p className="statusMsg err">
          {fetchError}
        </p>
      )}
      {!isLoading && !fetchError && (
        <>
        <div className='design'></div>
        <div className={`teamContainer ${colorTheme}`}>
        <h2>Teams<div className={`add ${colorTheme}`}><Link to='add'>+</Link></div></h2>
          {data?.map((team) => (
              <Link to={`/teams/${team.id}`}><div key={team.id} className='team' >
                <p>{team.name}</p>
              </div></Link>
          ))}
          </div>
        </>
      )}
    </>
  );
};

export default Teams;
