import React,{useState, useEffect} from 'react';
import axios from 'axios';
import classes from './ProductDetails.css';

const Description = () => {
    
    
    let url = window.location.pathname.toString();
    var idArray = url.split("/");
    var id = idArray[idArray.length - 1];
    var type = idArray[idArray.length - 2];
    
    const [items, setItems] = useState([]);
    useEffect(() => {
        
        axios.get("https://localhost:5101/api/v1/FormGenerator/"+ type + "/" + id)
            .then(response =>{
                var specs = {};
                specs = {...response.data};
                setItems(specs);
            });
    }, []);


    let keys = Object.keys(items);
    var idIndex = keys.indexOf("id");
    keys.splice(idIndex, 1);
    idIndex = keys.indexOf("imageURL");
    keys.splice(idIndex,1);
    idIndex = keys.indexOf("dateAdded");
    keys.splice(idIndex,1);

    function capitalizeFirstLetter(string) {
        if ( string.includes("_") ) {
            string = string.split("_")[1];
        }
        return (string.charAt(0).toUpperCase() + string.slice(1)).split(/(?=[A-Z])/).join(" ");
      }

    var isSmart = keys.includes("isSmart");
    items["isSmart"] = isSmart ? "Yes" : "No"; 

    let content = keys.map(content => (
            <p><span>{capitalizeFirstLetter(content)}</span> <span>{items[content]}</span></p>
    ));

    return(
    <div className={classes.displaySpecs}>
        <div className={classes.imgContainer}><img src={items["imageURL"]} /></div>
        <div className={classes.specsDetailed} >{content}</div>
    </div>
)};


export default Description;