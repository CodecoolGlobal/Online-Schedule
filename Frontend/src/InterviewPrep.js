import React from 'react';
import useAxiosFetch from './hooks/useAxiosFetch';

const InterviewPrep = () => {
  let url = 'https://localhost:7086/api/material';
  const { data, fetchError, isLoading } = useAxiosFetch(url);
  console.log(data);
  return (
    <>
      {isLoading && <p className="statusMsg">Loading ...</p>}
      {!isLoading && fetchError && (
        <p className="statusMsg err" style={{ color: 'red' }}>
          {fetchError}
        </p>
      )}
      {!isLoading && !fetchError && (
        <>
        <div className='listContainer'>
          <h2 className='interview'>Interview Preparation</h2>
          <ul>
            {data?.map((material) => (
              <li key={material.id}>
                {material.name}
                <ul>
                  {material.material?.map((submaterial) => (
                    <li key={submaterial}>
                      <a className='educationLink' href={submaterial}>{submaterial}</a>
                    </li>
                  ))}
                </ul>
              </li>
            ))}
          </ul>
          </div>
        </>
      )}
    </>
  );
};

export default InterviewPrep;
