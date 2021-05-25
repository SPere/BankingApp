# BankingApp
Light-weight Banking App to see the current balance of users. The ability to withdraw and deposit funds. The ability to deposit in many currencies via a call to a public exchange like http://api.exchangeratesapi.io/. Made use of Angular 12, WebAPI .netcore 5 and MSSQL 

To run the website:

1. Open BankingApp.sln in Visual Studio 2019. Please make sure .netcore 5 SDK is installed on your machine. 
i. Run BankingAppDatabase project: this will create the required database, tables and add seed data. 
ii. Run BankingAppWebAPI project: the api swagger should be available at https://localhost:44372/swagger/index.html 

3. Open command prompt, navigate to BankingAppWebUI/ and run the below:
i. npm i : to pull down the node packages, 
ii. npm start : to run ng server and start the server, 
iii. browse to http://localhost:4200/ 
iv. npm run test: to run the tests

Vola!

Few points:

1. The withdraw and deposit make use of https and POST body to secure the userid and the amount being withdrawn or deposited.

2. There are 3 core objects: the user, the currency and their balance. The BankingAppDatabase project can be used to create the desired tables in MSSQL. The tables will get created under BankingApp database. There is even a post script to add seed data. The seed data is 3 users, 3 currencies and their 3 balances. All balances are in EUR due to the limitation, see below.

3. We make use of Entity Framework as an ORM. BankingAppDbContext.cs contains the dbsets

Limitations:

1. Our API is calling a public Exchange Server to get the most recent exchange rates. The free account will only return 'EUR' as the base rate, thus all the balances are in 'EUR'. Either need to upgrade the account to allow other base rates or if not, we need 2 exchange conversions i.e. deposit amount to EUR and then from EUR to balance currency. Although, the later option might not be the best practice in production environments. The exchange Uri can be see in appsettings.json

Improvements:
1. Could do with more tests. Right now there is just enough tests to cover some of the Controllers and important business logic in the Services i.e. we send an error message if the withdrawl is going to cause the balance to go under 0 or the deposit amount is negative

2. WebUI could do with more tests, right now I've only fixed the existing default tests so npm run test will pass 

3. In the WebUI, the withdrawl and deposit click events need to be wired up to the API. The API is functional and can handle withdrawls and deposits, this can be seen via the swagger interface. The error messages need to be exposed and basic validation needs to be added

4. Add a fall back if the public Exchange Server is not available or a timed cache for the exchange rates. Similary in the WebUI, gracefully handle webapi errors, maybe see my other repo 'TemperatureConverter' for a good implementation of this
