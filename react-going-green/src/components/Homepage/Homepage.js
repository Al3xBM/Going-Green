import classes from "./HomePage.css";
import tenor from '../../assets/GoingGreen.mp4';
import React from 'react';
const homepage = () => (
    <div className={classes.container}>
        <div className={classes.Text}>
            <h4 className={classes.wordCarousel}>
                <div>
                    <ul className={classes.flip4}>
                        <li>Recycling conserves resources</li>
                        <li>Recycling saves energy</li>
                        <li className={classes.smaller}>Recycling helps protect the environment</li>
                        <li>Start recycling now</li>
                    </ul>
                </div>
            </h4>
        </div>
        <video muted loop autoPlay src = {tenor}></video>
    </div>
    
);


export default homepage;