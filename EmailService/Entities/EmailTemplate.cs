using Microsoft.AspNetCore.Identity;

namespace EmailService.Entities
{
    public class EmailTemplate
    {
        public EmailTemplate() { }

        public string confirmRequestMail(float price)
        {
            string messageBody = "<font>Hello there: </font><br>";
            
            messageBody += "<p>This is a confirmation mail for your request of recycling: </p>";
            messageBody += $"<p>Your product was estimated by our program to be worth <b>{price}</b> RON. This value may change</p>" +
                $"<p>based on our workers' assessment</p>";

            return messageBody; // return HTML Table as string from this function  
        }
    }
}
