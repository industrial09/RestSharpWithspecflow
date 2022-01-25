Feature: getPost

A short summary of the feature

@tag1
Scenario: Validate Post data
	Given I perform GET operation for "posts/{Id}"
	When I perform operation for post "1"
	Then I should see the expected authorname as "Karthik KK"
