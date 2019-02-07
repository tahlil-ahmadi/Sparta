Feature: PlacingBid
	In order to buy a product
	As a customer
	I want to be able to place bid on auction

Background: 
	Given There is an open auction with following information
	 | Seller | Product | EndDateTime | StartingPrice |
	 | Jack   | PS4     | 2020-01-01  | 4000       |

Scenario: Placing Bid Successfully
	When I place a bid with '4100'
	Then My bid should be set as current Winning bid

Scenario Outline: Placing bid with invalid amount
	When I place a bid with '<Amount>'
	Then I should get an error saying that amount is invalid
	Examples: 
		| Amount |
		| 4000   |
		| 3900   |