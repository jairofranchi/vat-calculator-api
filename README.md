# VATCalculatorAPI

# Requirements
- .Net 7.0 - https://dotnet.microsoft.com/en-us/download

# Steps to Run Application

Clone the repository and from the command line go to VATCalculatorAPI/ and run the commands below

- dotnet build
- dotnet run
- open the Swagger URL from: https://localhost:5178/swagger/index.html

# VATCalculatorAPI Methods

- Calculate VAT for purchase in Austria: https://localhost:8080/api/VATCalculator/calculate-vat-austria
    
    Parameter in body:
      
        ### Request Body
        {
            "grossAmount": 2555,
            "vatRate": 0.2
        }

        ### Json Response
        {
            "grossAmount": 2555,
            "netAmount": 2129.17,
            "vatAmount": 425.83
        }
  - Just one of the amounts that can be sent in the request body: netAmount, grossAmount or vatAmount.
  - From the amount sent, the other two will be calculated. Like the example above, sending the grossAmount in the request, netAmount and vatAmount will be calculated
