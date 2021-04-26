import React, { Component } from 'react';
import classes from './Register.css';
import axios from 'axios';

class Register extends Component {
    constructor(props) {
        super(props);
        this.firstRef = React.createRef();
        this.lastRef = React.createRef();
        this.emailRef = React.createRef();
        this.passRef = React.createRef();
        this.passConfirmRef = React.createRef();    
  
      };

    registerHandler = () => {
        if( this.passRef.current.value === this.passConfirmRef.current.value ){
                const data = {
                    FirstName: this.firstRef.current.value,
                    LastName: this.lastRef.current.value,
                    Email: this.emailRef.current.value,
                    Password: this.passRef.current.value,
                }
                    axios.post('https://localhost:5101/api/v1/UserService/Users/register', data)
                    .then(response => {
                            this.props.history.push('/Login');
                            console.log(response);
                    });
            }
        else {
            console.log("Password confirmation is wrong");
        }                
    };

    render(){
    
    return(
        <div className={classes.RegisterContainer}>
            <h3>Register</h3>
            <div>
                <p>Email</p>
                <input className={classes.RegisterInput} ref={this.emailRef} type='text'></input>
            </div>
            <div className={classes.NameContainer} >
                <div>
                    <p> First Name </p>
                    <input className={classes.RegisterInput}  ref={this.firstRef} type='text'></input>
                </div>
                <div>
                    <p> Last Name </p>
                    <input className={classes.RegisterInput}  ref={this.lastRef} type='text'></input>
                </div>
            </div>
            <div className={classes.NameContainer}>
            <div>
                <p>Password</p>
                <input className={classes.RegisterInput} ref={this.passRef} type='password'></input>
            </div>
            <div>
                <p>Password confirmation</p>
                <input className={classes.RegisterInput} ref={this.passConfirmRef} type='password'></input>
            </div>
            </div>
            <div>
                <button onClick={this.registerHandler} className={classes.RegisterButton}>SIGN UP</button>
            </div>
        </div>
    )}};


export default Register;