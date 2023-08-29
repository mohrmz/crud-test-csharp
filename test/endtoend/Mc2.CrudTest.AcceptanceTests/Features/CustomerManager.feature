Feature: CustomerManager
	As a customer management system (CMS) 
	I want to store customer contact information included firstname, lastname, dateofbirth, email, bankaccountnumber and phonenumber validated with LibPhoneNumber and a valid email and a bank account number with unique Email and a customer with unique Firstname, Lastname and DateOfBirth in database
	So that i have an accurate information from customers and have simple crud customer model
	

Background:
	Given The Valid Customer Has Following Information
		| FirstName | LastName | DateOfBirth | PhoneNumber   | Email                       | BankAccountNumber                    |
		| Mohammad  | Ramezani | 1995-05-05  | +441174960123 | mohammad0ramezani@gmail.com | DE12345678901234567890               |

@createapi
Scenario: 1) Create A New Valid Customer
	When I Want To Register A New Valid Customer In CMS
	Then The Customer With Correct Information Should Be Added In DB

@createapi
Scenario: 2) Create A New Customer With Invalid Phone Number
	Given The Invalid Phone Number Customer Has Following Information
	    | FirstName | LastName | DateOfBirth | PhoneNumber   | Email                       | BankAccountNumber                    |
		| MohammadPhon  | Ramezani | 1995-05-05  | 1174960123    | mohammadramezani@gmail.com | DE12345678901234567890               |
	When I Want To Register A New Customer With Invalid Phone Number In CMS
	Then The Invalid Phone Number Customer Should Not Be Added In DB And Raise Error

@createapi
Scenario: 3) Create A New Customer With Invalid Email 
	Given The Invalid Email Customer Has Following Information
	    | FirstName | LastName | DateOfBirth | PhoneNumber      | Email                       | BankAccountNumber                    |
		| Mohammadma  | Ramezani | 1995-05-05  | +441174960123    | mohammad0ramezani           | DE12345678901234567890               |
	When I Want To Register A New Customer With Invalid Email In CMS
	Then The Invalid Email Customer Customer Should Not Be Added In DB And Raise Error

@createapi
Scenario: 4) Create A New Customer With Invalid Bank Account Number 
	Given The Invalid Bank Account Number  Customer Has Following Information
	    | FirstName | LastName | DateOfBirth | PhoneNumber      | Email                                 | BankAccountNumber  |
		| Mohammadban  | Ramezani | 1995-05-05  | +441174960123    | mohammad12ramezani@gmail.com           | 213                |
	When I Want To Register A New Customer With Invalid Bank Account Number In CMS
	Then The Invalid Bank Account Number Customer Should Not Be Added In DB And Raise Error

@readapi
Scenario: 5) Read Customer
	When I Want To Manage Customers
	Then The Customers Should Be Loaded From DB

@updateapi
Scenario: 6) Update Customer
	Given The Customer Information Update To the Following Information
		| FirstName    | LastName | DateOfBirth | PhoneNumber   | Email                      | BankAccountNumber                    |
		| MohammadTest | Ramezani | 1995-05-05  | +441174960123 | mohammadramezani@gmail.com | DE12345678901234567890               |
	When I Want To update Customer Information In CMS
	Then The Customer Information Should Be Updated In DB

@deleteapi
Scenario: 7) Delete Customer
	When I Want To Delete Customer Information In CMS
	Then The Customer Information Should Be Deleted From DB And Load Empty