import React, { Component } from 'react';
import classes from './ImageUpload.css';
import axios from 'axios';

class Upload extends Component {

    state = {
        selectedImage: null
    }

    fileSelectedHandler = event => {
        this.setState({
            selectedImage: event.target.files[0]
        })
    }

    submitFormular = () => {
        console.log(this.state.selectedImage);
        const fd = new FormData();
        fd.append('image', this.state.selectedImage);
        axios.post('https://api.imgbb.com/1/upload?expiration=600&key=09c4e6970d9a7d76c9f85ecf10db4403', fd)
        .then(response => {
            var product = {
                Type : 'Television'
            }
            var elements = document.getElementById('details').childNodes;
            for(var i = 0, element; element = elements[i++];){
                if(element.value !== ""){
                    console.log(element.id)
                    product = {
                        ...product,
                        [element.id] : element.value
                    }
                }
            }
            product = {
                ...product,
                ImageURL:  response.data.data.url
            }
            console.log(JSON.stringify(product));
            product = JSON.stringify(product);

            axios({ method: 'post',
                    headers: {'Content-Type': 'application/json'},
                    url:'https://localhost:5200/api/v1/Repository',
                    data: product
                            
            
            }).then(response => {
                console.log('Form successfully added');
            })
            .catch(error => {
                console.log('Something went wrong at sending the form');
            });
            
        })
        .catch(error => {
            console.log('Something went wrong at getting url photo')
        });
        
    }

    // submitFormular = () => {
    // }


    render() {
        return(
            <div id='form' className={classes.containerForm}>
                <div className={classes.TitleForm}>Television</div>
                <div id='details'>
                <input id='Diagonal' type='text' placeholder="Diagonal"></input>
                <input id='Resolution' type='text'placeholder="Resolution"></input>
                <input id='IsSmart' type='text'placeholder="IsSmart"></input>
                <input id='Brand' type='text'placeholder="Brand"></input>
                <input id='Series' type='text'placeholder="Series"></input>
                <input id='Consumption' type='text'placeholder="Consumption"></input>
                <input id='EnergyClass' type='text'placeholder="EnergyClass"></input>
                <input id='Colour' type='text'placeholder="Colour"></input>
                <input id='Weight' type='text'placeholder="Weight"></input>
                </div>
                <input type='file' onChange={ this.fileSelectedHandler }/>
                <button onClick={this.submitFormular} >Upload</button>
            </div>
        );
    }


}

export default Upload;
