import React from "react";
import classes from "./UploadPhoto.css";
import { DropzoneArea } from 'material-ui-dropzone';
import Button from "@material-ui/core/Button";
import Container from "@material-ui/core/Container";
import axios from 'axios';


const uploadPhoto = ({ formData, setForm, navigation }) => {
    
    var photoURL = "";

    var submitFormular = () => {
        const fd = new FormData();
        fd.append('image', photoURL[0]);
        axios.post('https://api.imgbb.com/1/upload?expiration=600&key=09c4e6970d9a7d76c9f85ecf10db4403', fd)
        .then(response => {
            console.log(response);
            var product = {
                "ImageURL": response.data.data.url,
                "Type": formData["Type"],
                "Diagonal": formData["Diagonal"],
                "Resolution": formData["Resolution"],
                "IsSmart": formData["IsSmart"],
                "Brand": formData["Brand"],
                "Series": formData["Series"],
                "Consumption": formData["Consumption"],
                "EnergyClass": formData["EnergyClass"],
                "Colour": formData["Colour"],
                "Weight": formData["Weight"], 
            }
            
            console.log(product);

            product = JSON.stringify(product);
    
            axios({ method: 'post',
                    headers: {'Content-Type': 'application/json'},
                    url:'https://localhost:5101/api/v1/FormGenerator/Repository',
                    data: product
                            
            
            }).then(response => {
                console.log('Form successfully added');
                var request = {"to":formData["WorkEmail"],
                            "price": response["data"].toString()}
                console.log(request);
                axios.post('https://localhost:5101/api/v1/EmailService/Email', request)
                .then(respones => {
                    navigation.next();
                })
            })
            .catch(error => {
                console.log('Something went wrong at sending the form');
            });
            
        })
        .catch(error => {
            console.log('Something went wrong at getting url photo')
        });
        
    }

    var checkForm = () => {
        console.log(formData);
    };


    return(
    <Container maxWidth="md">
        <h3 className={classes.CategoryTitle}>Upload a photo</h3>
    <DropzoneArea
    acceptedFiles={['image/*']}
    dropzoneText={"Drag and drop an image here or click"}
    filesLimit={20}
    maxFileSize={500000000}
    onChange={(photo) => photoURL = photo}
    />
    <div className={classes.ButtonsContainer}>
        <Button className={classes.BackButton} 
                size="large" 
                variant="contained" 
                color="secondary" 
                onClick={ () => navigation.previous()}
                style={{ marginTop: "1rem" }} >Back</Button>
                

        <Button className={classes.NextButton} 
                size="large" 
                variant="contained" 
                color="primary" 
                onClick={ submitFormular }
                style={{ marginTop: "1rem" }} >Submit</Button>
    </div>
    </Container>
)
};

export default uploadPhoto;