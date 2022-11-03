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
          <Link to="/"><div className='navElement active' >Home</div></Link>
          <Link to="teams"><div className='navElement'>Teams</div></Link>
          <Link to="demos"><div className='navElement'>Demos</div></Link>
          <Link to="jobhunters"><div className='navElement'>Job Hunters</div></Link>
          <Link to="interviewprep"><div className='navElement'>InterviewPrep</div></Link>
          <Link to="about"><div className='navElement'>About</div></Link>
    </nav>
  )
}

export default Nav