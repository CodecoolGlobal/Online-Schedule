import { useEffect } from 'react';
import { Link } from 'react-router-dom';
import { useContext, useState } from 'react';
import DataContext from './dataContext/dataContext';


const Nav = () => {
<<<<<<< HEAD
  useEffect(() => {
    function NavBar() {
      var btnContainer =
        document.getElementsByClassName('sideNav')[0];
      if (btnContainer !== undefined) {
        var btns = btnContainer.getElementsByClassName('navElement');
        for (var i = 0; i < btns.length; i++) {
          btns[i].addEventListener('click', function () {
            var current =
              document.getElementsByClassName('active')[0];
            current.className = current.className.replace(
              ' active',
              ''
            );
            this.className += ' active';
          });
        }
      }
=======


  
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
>>>>>>> development
    }

<<<<<<< HEAD
    NavBar();
  }, []);
  return (
    <nav className="sideNav">
      <div className="navElement active">
        <Link to="/">Home</Link>
      </div>
      <div className="navElement">
        <Link to="teams">Teams</Link>
      </div>
      <div className="navElement">
        <Link to="demos">Demos</Link>
      </div>
      <div className="navElement">
        <Link to="jobhunters">Job Hunters</Link>
      </div>
      <div className="navElement">
        <Link to="interviewprep">InterviewPrep</Link>
      </div>
      <div className="navElement">
        <Link to="about">About</Link>
      </div>
      <div className="navElement">
        <Link to="Register">Register</Link>
      </div>
=======
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
>>>>>>> development
    </nav>
  );
};

export default Nav;
