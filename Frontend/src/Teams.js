import React from 'react';
import useAxiosFetch from './hooks/useAxiosFetch';
import { Link } from 'react-router-dom';
const Teams = () => {
  let url = 'https://localhost:7086/api/teams';
  const { data, fetchError, isLoading } = useAxiosFetch(url);

  console.log(data);
  return (
    <>
    <h2>Teams<div className='add'><Link to='add'>+</Link></div></h2>
      {isLoading && <p className="statusMsg">Loading ...</p>}
      {!isLoading && fetchError && (
        <p className="statusMsg err">
          {fetchError}
        </p>
      )}
      {!isLoading && !fetchError && (
        <>
        <div className='allTeams'>
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
