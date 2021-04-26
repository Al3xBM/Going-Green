import React, { Component } from 'react';
import classes from './Login.css';
import axios from 'axios';
import * as actionTypes from '../../store/actions';
import { connect } from 'react-redux';

class Login extends Component {
    constructor(props) {
      super(props);
      this.emailRef = React.createRef();
      this.passRef = React.createRef();  

    };
    
    loginHandler = () => {
        const data = {
            Email: this.emailRef.current.value,
            Password: this.passRef.current.value
        }
            axios.post('https://localhost:5101/api/v1/UserService/Users/authenticate', data)
            .then(response => {
                    localStorage.setItem('isLoggedIn', true)
                    this.props.logIn()
                    console.log("LOGIN")
                    this.props.history.push('/');
                    // console.log(response.data.token);
            });

        };

    shouldComponentUpdate(nextProps, nexState){
        return true;
    }
        render () {
            console.log(this.props.logStatus)
            if (this.props.logStatus === false) {
                return(
                    <div className={classes.LoginContainer}>
                        <h3>Sign in</h3>
                        <div>
                            <p> Your email </p>
                            <input className={classes.LoginInput}  ref={this.emailRef} type='text'></input>
                        </div>
        
                        <div>
                            <p> Your password </p>
                            <input className={classes.LoginInput} ref={this.passRef} type='password'></input>
                        </div>
                        <a className={classes.RegisterLink} href='/register'>Do not have an account? Register now</a>
                        <div>
                            <button onClick={this.loginHandler} className={classes.LoginButton}>LOGIN</button>
                        </div>
                    </div>
                );
             }  
            else if (this.props.logStatus === true) {
                return(null)       
            }
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

export default connect(mapStateToProps, mapDispatchToProps)(Login);