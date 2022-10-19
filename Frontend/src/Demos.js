import React from 'react';
import useAxiosFetch from './hooks/useAxiosFetch';

const Demos = () => {
  let url = 'https://localhost:7086/api/teams/actual';
  const { data, fetchError, isLoading } = useAxiosFetch(url);
  console.log(data);

  return (
    <>
      {isLoading && <p className="statusMsg">Loading ...</p>}
      {!isLoading && fetchError && (
        <p className="statusMsg" style={{ color: 'red' }}>
          {fetchError}
        </p>
      )}
      {!isLoading && !fetchError && (
        <>
          <table>
            <tr>
              <th>Team Name</th>
              <th>Team Members</th>
              <th>Git</th>
              <th>Start</th>
            </tr>
            {data?.map((team) => (
              <tr key={team.id}>
                <td>{team.name}</td>
                <td>
                  {team.students?.map((student) => (
                    <>{student.name}, </>
                  ))}
                </td>
                <td>{team.repo}</td>
              </tr>
            ))}
          </table>
        </>
      )}
    </>
  );
};

export default Demos;
