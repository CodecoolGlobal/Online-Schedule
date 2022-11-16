import React from 'react';
import { useState } from 'react';
const NewTeam = () => {
    const [teamName, setTeamName] = useState('');
  return (
  <>
    <h2>New Team</h2>
        <form className="newTeamForm" onSubmit={(e => e.preventDefault())}>
            <label htmlFor="teamName">Name:</label>
            <input
                id="teamName"
                type="text"
                required
                value={teamName}
                onChange={(e) => setTeamName(e.target.value)}
            />
            <button type="submit" onClick={()=> handleNewTeam()}>Create</button>
        </form>
    </>
  )
}

export default NewTeam