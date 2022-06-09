Feature: Employees

As an admin
I can add or remove employees
So that I can manage company
Background: 
Given Admin username is $$randomstring
And Admin password is pass123
When Create admin api is called

@employee @messured
Scenario: Get list of Employees
	When Get Employee list api is called
	Then Status code should be 200

@employee @messured
Scenario: Add Employees
	Given ModelState is correct
	When Add Employee list api is called
	Then Status code should be 201

@employee @messured
Scenario: Get Employee By Id
	When Get Employee By Id api is called(<id>)
	Then Status code should be 200
	Examples: 
| id |
| 44| 
| 899999 |
|49945| 


@employee @messured
Scenario: Delete Employees

	Given ModelState is correct
	When Delete  Employee  api is called(<id>)
	Then Status code should be 201
Examples: 
| id |
| 44|
| 899999 | 
|49945| 

@employee @messured
Scenario: Update Employee
	Given ModelState is correct
	When Update  Employee list api is called(<id>,<employee_name>,<employee_salary>,<employee_age>,<profile_image>)
	Then Status code should be 201 
	And Response should not have Eror

Examples: 
| id | employee_name | employee_salary | employee_age | profile_image |
| 44| Thameera   | 200000          | 23           |             |
| 899999 | Hansima     | 30000           | 34           |             |
|49945| Geetha      | 90000           | 23           |             |