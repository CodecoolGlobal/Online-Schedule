import React from 'react'
import { useParams } from 'react-router';

const Team = () => {
  const { id } = useParams();
  console.log(id);
  return (
    <div>Team</div>
  )
}

export default Team