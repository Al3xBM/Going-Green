
import classes from "./Form.css";
import { BsTv } from "react-icons/bs";
import { RiFridgeLine } from "react-icons/ri";
import { AiOutlineMobile } from "react-icons/ai";
{/* <span className={classes.checkedBox}>&#10004;</span> */}
const form = () => (

<div className={classes.divInlineList}>
    <div className={classes.productContainer}>
        <input id="prod1" type="radio" name="myradio"/>
        <label htmlFor="prod1" className={classes.clickable}></label>
        <p className={classes.product}><BsTv/></p>
    </div>
    <div className={classes.productContainer}>
        <input id="prod2" type="radio" name="myradio"/>
        <label htmlFor="prod2" className={classes.clickable}></label>
        <p className={classes.product}><RiFridgeLine/></p>
    </div>
    <div className={classes.productContainer}>
        <input id="prod3" type="radio" name="myradio"/>
        <label htmlFor="prod3" className={classes.clickable}></label>
        <p className={classes.product}><AiOutlineMobile/></p>
    </div>
</div>
);


export default form;