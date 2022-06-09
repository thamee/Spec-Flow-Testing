Feature: Employees

As an admin
I can add or remove employees
So that I can manage company
Background: 
Given Admin username is $$randomstring
And Admin password is pass123
When Create admin api is called

@employee 
Scenario: Get list of Employees
	When Get Employee list api is called
	Then Status code should be 200

@employee 
Scenario: Add Employees
	Given ModelState is correct
	When Add Employee list api is called
	Then Status code should be 201

@employee 
Scenario: Get Employee By Id
	When Get Employee By Id api is called
	Then Status code should be 200


@employee 
Scenario: Delete Employees
	Given ModelState is correct
	When Delete  Employee  api is called
	Then Status code should be 201 
	And Response should not have Eror


@employee 
Scenario: Update Employee
	Given ModelState is correct
	When Update  Employee list api is called
	Then Status code should be 201 
	And Response should not have Eror