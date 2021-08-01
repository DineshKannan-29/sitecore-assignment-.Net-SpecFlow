Feature: SiteCore Assignment
Login into Amazon Application, search for laptop and check if the first product is greater than 100$

@Assignment
Scenario Outline: Goto Aamzon.com to search "laptop" and check the is the first product is more than 100$ from product details window
	Given Setup '<BrowserName>' browser
	When GoTo URL '<URL>'
	And Search for the keyword '<KeyWord>'
    Then Select product number : '<ProductNumber>'
    And Check if the price is greater than '<Amount>' USD
    And Close the browser

	Examples: 
	| BrowserName | URL                     | KeyWord | ProductNumber | Amount |
    | Chrome      | https://www.amazon.com/ | laptop  | 1             | 100    |
