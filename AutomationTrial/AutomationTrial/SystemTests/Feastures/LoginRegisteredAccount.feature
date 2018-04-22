Feature: LoginRegisteredAccount
	In order to check I am registered	
	I want to be able to login

@SystemTests
Scenario: I can login with registered account
	Given I have valid registered account
	And I click and go to login page in "Chrome" browser
	When I put my details
	Then I can login to the system successfully