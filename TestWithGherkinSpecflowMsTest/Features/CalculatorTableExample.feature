Feature: Calculator_Table_Example
This adds numbers using tables.


@calculator_table
Scenario: Add two numbers using table
	Given user keys following numbers in calculator
	| FirstNumber | SecondNumber |
	| 2           | 3            |
	| 5           | 7            |
	| 10          | 12           |
	When two numbers in a row are added
	Then result will be in following table
	| Sum |
	| 5   |
	| 12  |
	| 22  |
