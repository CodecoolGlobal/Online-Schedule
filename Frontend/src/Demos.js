import React from 'react';
import useAxiosFetch from './hooks/useAxiosFetch';

const Demos = () => {
  let url = 'https://localhost:7086/api/teams/demos';
  const { data, fetchError, isLoading } = useAxiosFetch(url);
  const demoStart = new Date(
    `${data.demoStart}`
  ).toLocaleTimeString();
  console.log(data);

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
          <h1 className='demoTime'>Demos Start at {demoStart}</h1>
          <table className="DemoTabel">
            <tr>
              <th></th>
              <th>Team Name</th>
              <th>Team Members</th>
              <th>Git</th>
            </tr>
            {data.demoOrder?.map((team, index) => (
              <tr key={team.id}>
                <td>{(index = index + 1)}</td>
                <td>{team.name}</td>
                <td>
                  {team.students?.map((student) => (
                    <>{student.name}, </>
                  ))}
                </td>
                <td>
                  <a href={team.repo}>{team.repo}</a>
                </td>
              </tr>
            ))}
          </table>
        </>
      )}
    </>
  );
};

export default Demos;
