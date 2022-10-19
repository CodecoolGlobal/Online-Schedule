import React from 'react';
import useAxiosFetch from './hooks/useAxiosFetch';

const InterviewPrep = () => {
  let url = 'https://localhost:7086/api/material';
  const { data, fetchError, isLoading } = useAxiosFetch(url);
  console.log(data);
  return (
    <>
      <ul>
        {data?.map((material) => (
          <li key={material.id}>
            {material.name}
            <ul>
              {material.material?.map((submaterial) => (
                <li>
                  <a href={submaterial}>{submaterial}</a>
                </li>
              ))}
            </ul>
          </li>
        ))}
      </ul>
    </>
  );
};

export default InterviewPrep;
