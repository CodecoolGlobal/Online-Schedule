import useAxiosFetch from './hooks/useAxiosFetch';
import api from './hooks/api';
import { useState, useEffect } from 'react';

const Demos = () => {
  let url = 'https://localhost:7086/api/teams/demos';
  let { data, fetchError, isLoading } = useAxiosFetch(url);
  if (!isLoading) {
    let time = new Date(data.demoStart);
    console.log(time.toISOString());
    //console.log(time.toISOString());
    console.log(`${time.getHours()}:${time.getMinutes()}`);
    //console.log(time);

    const setDemoStart = async (value) => {
      console.log(value);
      time.setHours(value.slice(0, 2));
      time.setMinutes(value.slice(3));
      //time = Date.parse(`${value}`);
      console.log(`${time.toISOString()}`);
      value.preventDefault();
      try {
        const response = await api.put(`demos/${time.toISOString()}`);
      } catch (err) {
        if (err.response) {
          console.log(err.response.data);
          console.log(err.response.status);
          console.log(err.response.headers);
        } else {
          console.log(`Error: ${err.message}`);
        }
      }
    };

    //const testtime = new Date();
    //console.log(`testdate: ${testtime}`);

    //testdate.setHours('20');
    return (
      <>
        {isLoading && <p className="statusMsg">Loading ...</p>}
        {!isLoading && fetchError && (
          <p className="statusMsg err">{fetchError}</p>
        )}
        {!isLoading && !fetchError && (
          <>
            <h1 className="demoTime">
              Demos Start at
              <input
                id="demoStart"
                type="time"
                required
                value={`${time.getHours()}:${time.getMinutes()}`}
                onChange={(e) => setDemoStart(e.target.value)}
              />
            </h1>
            <table className="DemoTabel">
              <tbody>
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
                    <td key={team.id}>
                      {team.students?.map((student) => (
                        <span key={student.id}>{student.name}, </span>
                      ))}
                    </td>
                    <td>
                      <a href={team.repo}>{team.repo}</a>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </>
        )}
      </>
    );
  }
};

export default Demos;
