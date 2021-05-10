import React from 'react';
import classes from './TV.css';
import tvPhoto from '../../../../assets/TVDefault.png';


const TV = (props) => (
    <div className={classes.tvContainer} >

        <div className={classes.image} >
            <img src={props.Image}  onError={(e)=>{e.target.onerror = null; e.target.src=tvPhoto}}/>
        </div>

        <div className ={classes.specifications}>
            <div>{props.Type}</div>
            <div>{props.Brand}</div>
            <div>{props.Series}</div>
            <div>{props.Color}</div>
        </div>
    </div>
);


export default TV;