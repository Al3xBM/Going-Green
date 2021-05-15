import React, {useEffect, useState} from 'react';
import TV from './TV/TV';
import classes from './TVs.css';
import axios from 'axios';


const TVs = () => {
    
    const [items, setItems] = useState([]);
    useEffect(() => {
        
        axios.get("https://localhost:5101/api/v1/FormGenerator/Repository")
        .then(response =>{
            var devices = [];
            for( var dev of response["data"]){
                if(dev["type"] !== null && dev["brand"] !== null && dev["series"] !== null && dev["colour"] !== null)
                devices = [...devices,
                    {
                        "id":dev["id"],
                        "type":dev["type"],
                        "brand":dev["brand"],
                        "series":dev["series"],
                        "colour":dev["colour"],
                        "imageURL":dev["imageURL"]
                    }    
                ]
            }
            setItems(devices);
        });
    }, []);
    return(
    <div className={classes.containerTVs} >
        <ul>
            {items.map(content => (
                <li><TV
                    Id = {content.id}
                    Image= {content.imageURL}
                    Type= {content.type}
                    Brand= {content.brand}
                    Series= {content.series}
                    Color= {content.colour} />
                </li>
            ))}
        </ul>
    </div>
)};


export default TVs;