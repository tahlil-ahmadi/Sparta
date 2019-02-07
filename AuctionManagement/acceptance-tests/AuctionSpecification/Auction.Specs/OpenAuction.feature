Feature: OpenAuction
	In order to sell my product with best possible price
	As a seller
	I want to be able to open an auction


Scenario: Opening an auction
	When I request to open an auction with following information
	 | StartingPrice | Product     | EndDateTime |
	 | 20000         | Black Shoes | 2020-01-01  |
	 Then I should be able to see it in the list of open auctions
