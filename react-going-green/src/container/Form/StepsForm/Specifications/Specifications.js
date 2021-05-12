import React,{ useEffect, useState } from "react";
import Container from "@material-ui/core/Container";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import classes from "./Specifications.css";
import { MenuItem } from "@material-ui/core";
import axios from "axios";

const Specifications = ( {formData, setForm, navigation} ) => {
 
    const [items, setItems] = useState([]);
    const { Diagonal, Resolution, IsSmart, Brand, Series, Consumption, EnergyClass, Colour, Weight  } = formData;
    var specificationDevice = [];

    useEffect(() => {
        
        const request = {"Type": formData["Type"]};
        axios.post("https://localhost:5101/api/v1/FormGenerator/Form", request)
        .then(response =>{
            for( var specification of response["data"]){
                if(specification !== "dateAdded" && specification !== "ImageURL")
                    specificationDevice.push(specification);
            }
            setItems(specificationDevice);
        });
    }, []);
    
    return(
        <Container maxWidth="xs">
            <h2 className={classes.CategoryTitle}>Specifications</h2>
            {
            items.map(content => (
                (content !== "IsSmart" ?
                        <TextField 
                        label={content}
                        name={content}
                        value={formData[content]}
                        onChange={setForm}
                        margin="normal"
                        variant="outlined"
                        autoComplete="off"
                        fullWidth />
                        :
                        <TextField 
                        label="Smart"
                        name= {content}
                        value={IsSmart}
                        onChange={setForm}
                        margin="normal"
                        variant="outlined"
                        autoComplete="off"
                        fullWidth
                        select>

                        <MenuItem value="True">Yes</MenuItem>
                        <MenuItem value="False">No</MenuItem>
                        </TextField> 
            )))
            
            }
            {/* <TextField 
                label="Diagonal"
                name="Diagonal"
                value={Diagonal}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
                label="Resolution"
                name="Resolution"
                value={Resolution}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            /> */}



            {/* <TextField 
                label="Smart"
                name="IsSmart"
                value={IsSmart}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
                select>

                <MenuItem value="True">Yes</MenuItem>
                <MenuItem value="False">No</MenuItem>
            </TextField> */}
            {/* <TextField 
                label="Brand"
                name="Brand"
                value={Brand}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            /> */}
            {/* <TextField 
                label="Series"
                name="Series"
                value={Series}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
                label="Consumption"
                name="Consumption"
                value={Consumption}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
                label="Energy Class"
                name="EnergyClass"
                value={EnergyClass}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
                label="Colour"
                name="Colour"
                value={Colour}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
                label="Weight"
                name="Weight"
                value={Weight}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            /> */}

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
                    onClick={ () => navigation.next()}
                    style={{ marginTop: "1rem" }} >Next</Button>
            </div>
        </Container>
    );
}
export default Specifications;