import React from 'react';
import { Link } from 'react-router-dom';

const Nav = () => {
  return ( 
    
    <nav className='nav'>
        <ul>
            <li><Link to="/">Home</Link></li>
            <li><Link to="teams">Teams</Link></li>
            <li><Link to="demos">Demos</Link></li>
            <li><Link to="jobhunters">Job Hunters</Link></li>
            <li><Link to="interviewprep">InterviewPrep</Link></li>
            <li><Link to="about">About</Link></li>
        </ul>
    </nav>
  )
}

export default Nav