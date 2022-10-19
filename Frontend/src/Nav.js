import React from 'react';
import { Link } from 'react-router-dom';

const Nav = () => {
  return ( 
    
    <nav className='sideNav'>
          <div class="navElement active"><Link to="/">Home</Link></div>
          <div class="navElement"><Link to="teams">Teams</Link></div>
          <div class="navElement"><Link to="demos">Demos</Link></div>
          <div class="navElement"><Link to="jobhunters">Job Hunters</Link></div>
          <div class="navElement"><Link to="interviewprep">InterviewPrep</Link></div>
          <div class="navElement"><Link to="about">About</Link></div>
    </nav>
  )
}

function NavBar(){
  var btnContainer = document.getElementsByClassName("sideNav")[0];
  if(btnContainer !== null){
    var btns = btnContainer.getElementsByClassName("navElement");
    for (var i = 0; i < btns.length; i++) {
      btns[i].addEventListener("click", function() {
        var current = document.getElementsByClassName("active");
        current[0].className = current[0].className.replace(" active", "");
        this.className += " active";
      });
    }
  }
  
}

NavBar();

export default Nav