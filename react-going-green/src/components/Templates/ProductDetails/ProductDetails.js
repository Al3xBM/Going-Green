import React,{useState, useEffect} from 'react';
import axios from 'axios';
import classes from './ProductDetails.css';
import Button from "@material-ui/core/Button";
import Container from "@material-ui/core/Container";
import TextField from "@material-ui/core/TextField";

const Description = (props) => {
    
    const [order, setOrder] = useState(false);
    
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
    
    var orderNow = () => {
        setOrder(true);
    };

    var finishedOrder = () => {

        let contactDetails = document.getElementById("LastName").value +" "+
                            document.getElementById("WorkMail").value +" "+
                            document.getElementById("Country").value +" "+
                            document.getElementById("City").value +" "+
                            document.getElementById("Address").value +" "+
                            document.getElementById("PostalCode").value;
        
        let prodDetils = "";
        keys.map(content => (
             prodDetils += items[content] + " "
    ));
    // console.log(price);
    console.log(prodDetils);
    console.log(contactDetails);
    
    let priceBody = {"Price": items["price"]};
    let prodDetilsBody = {"ProductInfo": prodDetils}
    let clientInfo = {"ClientInfo": contactDetails};
    let Email = {"to": document.getElementById("WorkMail").value};
    // console.log(items);

    axios.post("https://localhost:5101/api/v1/OrderTrackingService/",priceBody, prodDetilsBody, clientInfo)
    .then(response =>{
        axios.post("https://localhost:5101/api/v1/EmailService/Email/",Email, priceBody, prodDetilsBody, clientInfo)
        .then(response => {
            window.location.replace("/order");
        })
    });
}

    

    var isSmart = keys.includes("isSmart");
    items["isSmart"] = isSmart ? "Yes" : "No"; 

    let content = keys.map(content => (
            <p><span>{capitalizeFirstLetter(content)}</span> <span>{items[content]}</span></p>
    ));


    var productSpecs = (
        <div className={classes.displaySpecs}>
            <div className={classes.imgContainer}><img src={items["imageURL"]} /></div>
            <div className={classes.specsDetailed} >{content}
            <div className={classes.buttonContainer}>
                <button onClick={orderNow} >ORDER NOW</button>
            </div>
            </div>
        </div>
        );

    var orderSpecs = (
        <Container className={classes.containerClass} maxWidth="xs">
        <h2 className={classes.CategoryTitle}>Contact</h2>
        <TextField
            id="FirstName"
            label="First Name"
            name="FirstName"
            margin="normal"
            variant="outlined"
            autoComplete="off"
            fullWidth
        />
        <TextField 
            label="Last Name"
            id="LastName"
            name="LastName"
            margin="normal"
            variant="outlined"
            autoComplete="off"
            fullWidth
        />
        <TextField 
            label="Work Email"
            id="WorkMail"
            name="WorkEmail"
            margin="normal"
            variant="outlined"
            autoComplete="off"
            fullWidth
        />
        <TextField
            type="number" 
            id="Phone"
            label="Phone"
            name="Phone"
            margin="normal"
            variant="outlined"
            autoComplete="off"
            fullWidth
        />
        <TextField 
            label="Country"
            id="Country"
            name="Country"
            margin="normal"
            variant="outlined"
            autoComplete="off"
            fullWidth
        />
        <TextField 
            label="City"
            id="City"
            name="City"
            margin="normal"
            variant="outlined"
            autoComplete="off"
            fullWidth
        />
        <TextField 
            label="Address"
            id="Address"
            name="Address"
            margin="normal"
            variant="outlined"
            autoComplete="off"
            fullWidth
        />
        <TextField
            type="number"
            id="PostalCode"
            label="Postal Code"
            name="PostalCode"
            margin="normal"
            variant="outlined"
            autoComplete="off"
            fullWidth
        />

        <Button className={classes.finishButton} 
                            size="large" 
                            variant="contained" 
                            color="secondary" 
                            onClick={finishedOrder}
                            style={{ marginTop: "1rem", marginBottom: "2rem" }} >Finish</Button>

        </Container>
    );

    
    if(order === false){
        return(
            <div>
                {productSpecs}
            </div>
        )
    }
    else{
        return(
            <div>
                {orderSpecs}
            </div>
        )
    }

};


export default Description;