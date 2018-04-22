Feature: RegisterNewAccount
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SystemTests
Scenario: I can Register a new account in microsoft Edge
	Given Iam in the registration Page in "Chrome" browser
	And I have generated a random registration data
	When I sned data to registration Page
	Then I can register
