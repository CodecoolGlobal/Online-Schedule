import {useEffect} from 'react';
import { Link } from 'react-router-dom';

const Nav = () => {
  useEffect(()=> {
function NavBar(){
  var btnContainer = document.getElementsByClassName("sideNav")[0];
  if(btnContainer !== undefined){
    var btns = btnContainer.getElementsByClassName("navElement");
    for (var i = 0; i < btns.length; i++) {
      btns[i].addEventListener("click", function() {
        var current = document.getElementsByClassName("active")[0];
        current.className = current.className.replace(" active", "");
        this.className += " active";
      });
    }
  }
  
}

NavBar();
},[])
  return ( 
    
    <nav className='sideNav'>
          <div className='navElement active'><Link to="/">Home</Link></div>
          <div className='navElement'><Link to="teams">Teams</Link></div>
          <div className='navElement'><Link to="demos">Demos</Link></div>
          <div className='navElement'><Link to="jobhunters">Job Hunters</Link></div>
          <div className='navElement'><Link to="interviewprep">InterviewPrep</Link></div>
          <div className='navElement'><Link to="about">About</Link></div>
    </nav>
  )
}

export default Nav