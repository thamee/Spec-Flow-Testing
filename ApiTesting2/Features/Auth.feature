Feature: Auth

As a user,
I can create an admin
so that I can use the auth token for employee apis

@smoke @auth
Scenario: Create Admin
	Given Admin username is $$randomstring
	And Admin password is pass123
	When Create admin api is called
	Then Status code should be 201
	And response should have a valid access_token
	@smoke @auth

Scenario: Create Existing Admin
	Given Admin username is RDF
	And Admin password is pass123
	When Create admin api is called
	Then Status code should be 400

Scenario: Negative-Blank password in Create Admin
	Given Admin username is $$randomstring
	And the password is blank ""
	When Create admin api is called
	Then Status code should be 400

@smoke @auth
Scenario: Negative -Invalid Admin Username
	Given Admin username is NotAnAdmin
	And Admin password is pass123
	When login admin api is called
	Then Status code should be 401

@smoke @auth
Scenario: Negative -Invalid Password
Given Admin username is Shavi
And Admin password is notpass
When login admin api is called
Then Status code should be 401