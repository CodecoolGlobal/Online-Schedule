import React from 'react'
import { useParams } from 'react-router';
import useAxiosFetch from './hooks/useAxiosFetch';

const Team = () => {
  const { id } = useParams();
  let url=`https://localhost:7086/api/teams/${id}`
  const { data, fetchError, isLoading } = useAxiosFetch(url);
  console.log(data.students)
  return (
  <>  {isLoading && <p className='statusMsg'>Loading posts...</p>}
      {!isLoading && fetchError && <p className='statusMsg' style={{color: "red"}}>{fetchError}</p>}
      {!isLoading && !fetchError &&<>
              <h1>{data.name}</h1>
            <div>Mentor: {data.mentor}</div>
            <ul>Students: 
                {data.students.forEach(element => {<li>{element.name}</li>})}
            </ul></>}
          </>
  )
}

export default Team