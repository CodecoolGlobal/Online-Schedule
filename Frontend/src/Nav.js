import {useEffect} from 'react';
import { Link } from 'react-router-dom';
import { useContext, useState } from 'react';
import DataContext from './dataContext/dataContext';


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
const {colorTheme} = useContext(DataContext);
  return ( 
    
    <nav className={`sideNav ${colorTheme}`}>
          <Link to="/"><div className={`navElement ${colorTheme} active`} >Home</div></Link>
          <Link to="teams"><div className={`navElement ${colorTheme}`}>Teams</div></Link>
          <Link to="demos"><div className={`navElement ${colorTheme}`}>Demos</div></Link>
          <Link to="jobhunters"><div className={`navElement ${colorTheme}`}>Job Hunters</div></Link>
          <Link to="interviewprep"><div className={`navElement ${colorTheme}`}>InterviewPrep</div></Link>
          <Link to="about"><div className={`navElement ${colorTheme}`}>About</div></Link>
    </nav>
  )
}

export default Nav