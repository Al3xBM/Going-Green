import React from "react";
import Container from "@material-ui/core/Container";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import classes from "./Specifications.css";
import { MenuItem } from "@material-ui/core";

const specifications = ( {formData, setForm, navigation} ) => {
 
    const { Diagonal, Resolution, IsSmart, Brand, Series, EnergyClass, Weight  } = formData;
    console.log(formData);
    return(
        <Container maxWidth="xs">
            <h2 className={classes.CategoryTitle}>Specifications</h2>
            <TextField 
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
            />
            <TextField 
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
            </TextField>
            <TextField 
                label="Brand"
                name="Brand"
                value={Brand}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
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
                label="Weight"
                name="Weight"
                value={Weight}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
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
                    onClick={ () => navigation.next()}
                    style={{ marginTop: "1rem" }} >Next</Button>
            </div>
        </Container>
    );
}
export default specifications;
