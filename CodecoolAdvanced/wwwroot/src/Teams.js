import React from 'react'
import useAxiosFetch from './hooks/useAxiosFetch'
import { Link } from 'react-router-dom';
const Teams = () => {
  let url='https://localhost:7086/api/teams'
  const { data, fetchError, isLoading } = useAxiosFetch(url);
  
  console.log(data)
  return (
    <>
    {isLoading && <p className='statusMsg'>Loading ...</p>}
      {!isLoading && fetchError && <p className='statusMsg' style={{color: "red"}}>{fetchError}</p>}
      {!isLoading && !fetchError && <>
    {data?.map(team => <div key={team.id} ><Link to={`/teams/${team.id}`}>{team.name}</Link></div>)

    }
    </>}
    </>
  )
}

export default Teams