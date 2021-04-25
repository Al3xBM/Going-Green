import React from "react";
import Container from "@material-ui/core/Container";
import Accordion from "@material-ui/core/Accordion";
import AccordionSummary from "@material-ui/core/AccordionSummary";
import AccordionDetail from "@material-ui/core/AccordionDetails";


const review = ({ formData }) => {
 
    const {
        // defaultdata...
    } = formData;

return(
    <Container>
        <h3> Review </h3>
        <RenderAccordion summary="Category" details={[
        {}
        ]}/>
    </Container>    

    );
}

const RenderAccordion = ({ summary }) => (
    <Accordion>
        <AccordionSummary>{ summary }</AccordionSummary>
        <AccordionDetail>
            <div>

            </div>
        </AccordionDetail>
    </Accordion>
)

export default review;