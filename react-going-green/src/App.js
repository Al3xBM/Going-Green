import './App.css';
import NavBar from './components/Navbar/Navbar';
import SideMenu from './components/SideMenu/SideMenu';
import Login from './container/Login/Login';
import { BrowserRouter,Route } from 'react-router-dom';
import Form from './container/Form/Form';
import Homepage from './components/Homepage/Homepage';
import Shop from './components/Shop/Shop';
import Register from './container/Register/Register';



function App() {
  return (
    <BrowserRouter>
    <div className="App">
      <NavBar />
      <SideMenu/>
      <Route exact path='/' component={Homepage} />
      <Route path='/recycle' component={Form} />
      <Route path='/Login' component={Login} />
      <Route path='/shop' component={Shop} />
      <Route path='/Register' component={Register} />
    </div>
    </BrowserRouter>
  );
}
export default App;
