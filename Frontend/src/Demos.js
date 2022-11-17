import React from 'react';
import useAxiosFetch from './hooks/useAxiosFetch';
import { useContext, useState } from 'react';
import DataContext from './dataContext/dataContext';


const Demos = () => {
  let url = 'https://localhost:7086/api/teams/demos';
  const { data, fetchError, isLoading } = useAxiosFetch(url);
  const demoStart = new Date(
    `${data.demoStart}`
  ).toLocaleTimeString();
  const {colorTheme} = useContext(DataContext);

  return (
    <>
      {isLoading && <p className="statusMsg">Loading ...</p>}
      {!isLoading && fetchError && (
        <p className="statusMsg err">{fetchError}</p>
      )}
      {!isLoading && !fetchError && (
        <>
        <div className={`design ${colorTheme}`}></div>
          <h1 className="demoTime">Demos Start at 9:30</h1>
          <table className="DemoTabel">
            <tr>
              <th></th>
              <th>Team Name</th>
              <th>Team Members</th>
              <th>Git</th>
            </tr>
            {data.demoOrder?.map((team, index) => (
              <tr key={team.id} className={colorTheme}>
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
