import React from "react";
import classes from "./Category.css";
import { BsTv } from "react-icons/bs";
import { RiFridgeLine } from "react-icons/ri";
import Button from "@material-ui/core/Button";

const category = ( {formData, setForm, navigation} ) => {
    
    const { CategoryField } = formData;

    let textInput = React.createRef();
    let values = "";

    const clickAction = () => {
       if( document.querySelector('.categoryType:checked') !== null){
            values = document.querySelector('.categoryType:checked').value;
            // document.getElementById('inputvalue').value = values;
                     
            // document.getElementById('inputvalue').onchange();
           navigation.next();
        // console.log(formData);
       }
    }

    return(
    <div className={classes.formContainer}>
        <h2>Select the category</h2>
        <div className={classes.divInlineList}>
        {/* <input
                id ="inputvalue"
                ref={textInput}
                label="Category Field"
                name="CategoryField"
                onChange={ setForm }
            /> */}
            {/* <input ref={textInput} name="CategoryField" className="CategoryField" onChange={setForm} style={{display:'hidden'}} /> */}
            <div className={classes.productContainer}>
                <input className="categoryType" id="prod1" type="radio" name="myradio" value="TV"/>
                <label htmlFor="prod1" className={classes.clickable}></label>
                <p className={classes.product}><BsTv/></p>
            </div>
            {/* <div className={classes.productContainer}>
                <input className="categoryType" id="prod2" type="radio" name="myradio" value="Fridge"/>
                <label htmlFor="prod2" className={classes.clickable}></label>
                <p className={classes.product}><RiFridgeLine/></p>
            </div> */}
        </div>
        <div className={classes.ButtonContainer}>
            <Button className={classes.NextButton} 
                    size="large" 
                    variant="contained" 
                    color="primary" 
                    onClick={ clickAction }
                    style={{ marginTop: "1rem" }} >Next</Button>
        </div>
    </div>
)};

export default category;