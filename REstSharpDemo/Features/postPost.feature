Feature: ValidatePostPostData

A short summary of the feature

@tag1
Scenario Outline: Validate Post Data with post Request
	Given I perform POST operation for "posts/"
	When I perform operation for post having <id>, <title> and <author>
	Then I should see the expected author name as <author>
Examples: 
	| id| title		| author|
	|100	|Harry Pother|Anyone|

