import React from 'react'
import { useParams } from 'react-router';
import useAxiosFetch from './hooks/useAxiosFetch';

const Team = () => {
  const { id } = useParams();
  let url=`https://localhost:7086/api/teams/${id}`
  const { data, fetchError, isLoading } = useAxiosFetch(url);
  console.log(data)

  return (
  <>  {isLoading && <p className='statusMsg'>Loading ...</p>}
      {!isLoading && fetchError && <p className='statusMsg' style={{color: "red"}}>{fetchError}</p>}
      {!isLoading && !fetchError && <>
              <h1>{data.name}</h1>
            <div>Mentor: {data.mentor}</div>
            <ul>Students: 
                {data.students?.map(student=> 
                  <li key={student.id}>{student.name}</li>)}
            </ul></>}
          </>
  )
}

export default Team