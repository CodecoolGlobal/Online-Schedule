import React from 'react';
import { useEffect } from 'react';
import { useState } from 'react';
import api from './hooks/api';

const TEAM_REGEX = /^[A-z][A-z0-9-_]{3,23}$/;
const URL_REGEX = new RegExp(
  '(https?://)?([\\da-z.-]+)\\.([a-z.]{2,6})[/\\w .-]*/?'
);

const NewTeam = () => {
  const [teamName, setTeamName] = useState('');
  const [validName, setValidName] = useState(false);

  const [teamRepo, setTeamRepo] = useState('');
  const [validRepo, setValidRepo] = useState(false);

  useEffect(() => {
    const result = TEAM_REGEX.test(teamName);
    setValidName(result);
  });

  useEffect(() => {
    const result = URL_REGEX.test(teamRepo);
    console.log(teamRepo);
    console.log(validRepo);
    setValidRepo(result);
  });

  const handleNewTeam = async () => {
    const studentID = 1; // ez majd le kell csrélni ha be tudtunk jelentkezni!!
    try {
      const response =
        await api.post(`teams?studentId=${studentID}&name=${teamName}&repo=${teamRepo}
    `);
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
  return (
    <>
      <h2>New Team</h2>
      <form
        className="newTeamForm"
        onSubmit={(e) => e.preventDefault()}
      >
        <label htmlFor="teamName">Name:</label>
        <input
          id="teamName"
          type="text"
          required
          value={teamName}
          onChange={(e) => setTeamName(e.target.value)}
        />


        <label htmlFor="teamRepo">Repo Link:</label>
        <input
          id="teamRepo"
          type="text"
          required
          value={teamRepo}
          onChange={(e) => setTeamRepo(e.target.value)}
        />
        <button
          disabled={!validName || !validRepo ? true : false}

          className="regbutton"
          type="submit"
          onClick={() => handleNewTeam()}
        >
          Create
        </button>
      </form>
    </>
  );
};

export default NewTeam;
