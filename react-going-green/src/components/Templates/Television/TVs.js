import React from 'react';
import TV from './TV/TV';
import classes from './TVs.css';
import axios from 'axios';
import { Component } from 'react';

class TVs extends Component {
    
    state = {
        Televisions : []
    };
    render() {
    axios.get("https://localhost:5101/api/v1/FormGenerator/Repository/category/Television")
    .then(response =>{
        var newTelevisions = []
        for( var tv of response["data"]){
            if(tv["type"] !== null && tv["brand"] !== null && tv["series"] !== null && tv["colour"] !== null)
            newTelevisions = [...newTelevisions,
                {
                    "type":tv["type"],
                    "brand":tv["brand"],
                    "series":tv["series"],
                    "colour":tv["colour"],
                    "imageURL":tv["imageURL"]
                }    
            ]
        }
        let finalState = {Televisions:[...newTelevisions]};
        this.setState(finalState);
    });

    return(
    <div className={classes.containerTVs} >
        <ul>
            {this.state.Televisions.map(content => (
                <li><TV
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
}

export default TVs;