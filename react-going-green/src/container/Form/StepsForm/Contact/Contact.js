import React from "react";
import Container from "@material-ui/core/Container";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import classes from "./Contact.css";

const contact = ( {formData, setForm, navigation} ) => {
 
    const { FirstName, LastName, WorkEmail, Phone, Country, City, Address, PostalCode  } = formData;

    return(
        <Container maxWidth="xs">
            <h2 className={classes.CategoryTitle}>Contact</h2>
            <TextField 
                label="First Name"
                name="FirstName"
                value={FirstName}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
                label="Last Name"
                name="LastName"
                value={LastName}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
                label="Work Email"
                name="WorkEmail"
                value={WorkEmail}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField
                type="number" 
                label="Phone"
                name="Phone"
                value={Phone}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
                label="Country"
                name="Country"
                value={Country}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
                label="City"
                name="City"
                value={City}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField 
                label="Address"
                name="Address"
                value={Address}
                onChange={setForm}
                margin="normal"
                variant="outlined"
                autoComplete="off"
                fullWidth
            />
            <TextField
                type="number"
                label="Postal Code"
                name="PostalCode"
                value={PostalCode}
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
                    style={{ marginTop: "1rem" }} >Submit</Button>
            </div>
        </Container>
    );
}
export default contact;
