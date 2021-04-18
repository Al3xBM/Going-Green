import { Component } from 'react';
import { connect } from 'react-redux';
import classes from './Navbar.css';
import * as actionTypes from '../../store/actions';
import Logo from '../../assets/logo.png';

class Toolbar extends Component {
  constructor(props){
    super(props);
    this.logText = 'login';
    if(localStorage.getItem('isLoggedIn') === 'true'){
      this.props.logIn();
    }
    else if(localStorage.getItem('isLoggedIn') === 'false'){
      this.props.logOut();
    }
  }
  
  logoutHandler = () => {
    if(this.props.logStatus){
        localStorage.setItem('isLoggedIn', false)
        this.props.logOut()
    }
  };
  
  render(){
    const logStatus = this.props.logStatus;
    console.log(this.props.logStatus);
    if(logStatus){
    this.logText = 'logout'
  }
  else{
    this.logText = 'login'
  }
    return(
      <header className = {classes.Toolbar}>
          <div className = {classes.Menu}> ||| </div>
          <div className = {classes.Title}> <a href='/'> <img src={Logo} alt='logo'/> </a></div>
          <div className = {classes.Login}> <a href='/Login' onClick={this.logoutHandler}>{this.logText}</a></div>
      </header>
    );
  }
}
const mapStateToProps = state => {
  return {
      logStatus: state.isLoggedIn
  };
};

const mapDispatchToProps = dispatch => {
  return {
      logIn: () => dispatch({type: actionTypes.LOG_IN}),
      logOut: () => dispatch({type: actionTypes.LOG_OUT})
  }
};


export default connect(mapStateToProps, mapDispatchToProps)(Toolbar);