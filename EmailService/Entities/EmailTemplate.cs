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

            return messageBody;  
        }

        public string confirmOrderMail(float price, string productInfo, string clientInfo)
        {
            string messageBody = "<font>Hello there: </font><br>";

            messageBody += "<p>This is a confirmation mail for the order you just placed: </p>";
            messageBody += $"<p>Your product:</p>";
            messageBody += $"<p>{productInfo}</p>";
            messageBody += $"<p>Will be delivered to:</p>";
            messageBody += $"<p>{clientInfo}</p>";
            messageBody += $"<p>The sum you will need to pay: {price} RON</p>";

            return messageBody; 
        }
    }
}
