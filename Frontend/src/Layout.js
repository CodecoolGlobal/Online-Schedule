import Header from './Header';
import Nav from './Nav';
import { Outlet } from 'react-router-dom';

const Layout = () => {
    return (
        <div className="App">
            <Header title="nasaApi"
            />
            <Nav  />
            <div className='mainPart'><Outlet /></div>
        </div>
    )
}

export default Layout