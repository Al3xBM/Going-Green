
import classes from "./Form.css";
import { useForm, useStep } from "react-hooks-helper";
import  Category from "./StepsForm/Category/Category";
import  Specifications from "./StepsForm/Specifications/Specifications";
import  Contact from "./StepsForm/Contact/Contact";
import  Review from "./StepsForm/Review/Review";
import  Submit from "./StepsForm/Submit/Submit";
import UploadPhoto from "./StepsForm/UploadPhoto/UploadPhoto";

const defaultData = {
    Type : "Television",
    Diagonal : "",
    Resolution : "",
    IsSmart : "",
    Brand : "",
    Series : "",
    EnergyClass: "",
    Weight : "",
    FirstName : "",
    LastName : "",
    WorkEmail : "",
    Phone : "",
    Country : "",
    City : "",
    Address: "",
    PostalCode: ""
}

const steps = [
    {id: 'category' },
    {id: 'specification' },
    {id: 'contact' },
    // {id: 'review' },
    {id: 'photo'},
    {id: 'submit' }
]


const Form = () => {
    const [formData, setForm] = useForm(defaultData);
    const {step, navigation } = useStep({
        steps, 
        initialStep: 0
    });
    
    const props = { formData, setForm, navigation }
    
    switch (step.id) {
        case "category":
            return <Category { ...props }/>
        case "specification":
            return <Specifications { ...props } />
        case "contact":
            return <Contact { ...props } />
        // case "review":
        //     return <Review { ...props } />
        case "photo":
            return <UploadPhoto { ...props } />
        case "submit":
            return <Submit { ...props } />
    }

    return (
        <div>Salut</div>
        );
}

export default Form;

