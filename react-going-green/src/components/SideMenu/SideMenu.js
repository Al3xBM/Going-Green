import React, { Component } from 'react';
import { stack as Menu } from 'react-burger-menu';
import classes from './SideMenu.css'

class SideMenu extends Component {

    render() {
        return (
            <div className = {classes.Container}>
            <Menu className = {classes.Menu} customCrossIcon={ false }>
                <a id="home" className={classes.Menu}href="/recycle">Recycle</a>
                <a id="about" className={classes.Menu} href="/">About</a>
                <a id="contact" className={classes.Menu} href="/">Contact</a>
                <a id="upload" className={classes.Menu} href="/shop">Shop</a>
            </Menu>
            </div>
        );
    }

}

export default SideMenu