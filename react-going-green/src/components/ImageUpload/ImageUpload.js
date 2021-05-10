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
        console.log(this.state);
    }

    submitFormular = () => {
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
            product = JSON.stringify(product);

            console.log(product);

            axios({ method: 'post',
                    headers: {'Content-Type': 'application/json'},
                    url:'https://localhost:5200/api/v1/Repository',
                    data: product
                            
            
            }).then(response => {
                const fd = new FormData();
                fd.append("price", response);
                fd.append("to","ali.balan16@gmail.com");
                axios.post('https://localhost:5200/api/v1/EmailService/Email',fd)
                .then(response => {
                    console.log('Mail successfully sended');
            })
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
