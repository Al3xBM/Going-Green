import React, { useEffect, useState } from "react";
import classes from "./Category.css";
import { BsTv } from "react-icons/bs";
import { RiFridgeLine } from "react-icons/ri";
import Button from "@material-ui/core/Button";
import axios from 'axios';

const Category = ( {formData, setForm, navigation} ) => {
    
    const { CategoryField } = formData;
    const [items, setItems] = useState([]);
    let textInput = React.createRef();
    var categoryDevices = [];
    let values = "";
    const Television = (<React.Fragment><BsTv/></React.Fragment>);
    const Fridge = (<React.Fragment><RiFridgeLine/></React.Fragment>)

    useEffect(() => {
        console.log("HERE");
        axios.get("https://localhost:5101/api/v1/FormGenerator/Form")
        .then(response =>{
            for( var category of response["data"]){
                categoryDevices.push(category);
            }
            setItems(categoryDevices);
        });
    }, []);
       

    const clickAction = () => {
       if( document.querySelector('.categoryType:checked') !== null){
            values = document.querySelector('.categoryType:checked').value;
            formData["Type"] = values;
           navigation.next();
       }
    }

    return(
    <div className={classes.formContainer}>
        <h2>Select the category</h2>
        <div className={classes.divInlineList}>
            {items.map(content => (
                <div className={classes.productContainer}>
                    <input className="categoryType" id={content} type="radio" name="myradio" value={content}/>
                    <label htmlFor={content} className={classes.clickable}></label>
                    <p className={classes.product}>{(content == "Television" ? Television : Fridge)}</p>
                    <div className={classes.productName} >{content}</div>
                </div>
            ))}
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

export default Category;