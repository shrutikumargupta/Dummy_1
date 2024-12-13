Feature: DummyTest

Login and adding items to shopping cart

@Testers
Scenario Outline: Login with invalid credentials
	Given open the browser and enter url
	When I entered userid <username> and paswrd <password>
	And Click on login button
	Then Verify the credentials
	Examples:
	| username  | password |
	| test12345 | pwd123   |

	Scenario Outline: Login with valid credentials
	Given open the browser and enter url
	When I entered userid <username> and paswrd <password>
	And Click on login button
	Then Verify the credentials
	Examples:
	| username      | password    |
	| standard_user | secret_sauce|

	Scenario Outline: Add 4 cheapest items to cart and remove items when total more than 50
	Given open the browser and enter url
	When I entered userid <username> and paswrd <password>
	And Click on login button
	Then Verify the credentials
	And Sort items for price to see cheapest items
	And Add <number> items to cart
	And remove items if amount is more than <maxamount>
	
	Examples:
	| username      | password     | number | maxamount |
	| standard_user | secret_sauce | 4      | 48        |


	#Testcases for AddtoCart

	# Given I have logged in to application with valid credentials
	# And I am on Home Page
	# And Click on Cart icon to open cart without adding any items to cart
	# Then Verify Page title should be Your Cart 
	# And Verify CONTINUE SHOPPING and CHECKOUT buttons should be displayed
	# And Verify cart should be empty and no items displayed
	# count over cart icon should be blank


	# Given I have logged in to application with valid credentials
	# And I am on Home Page
	# And Sort products with Name (A to Z)
	# And click on Add to cart for first item
	# And click on cart icon
	# Then Verify count over Cart icon should be 1
	# And Verify system should display Qty as 1 and description same as product added in cart
	# And verify system should display amount of product added in cart below description of product
	# And verify system should display Remove button for the added product



	# Given I have logged in to application with valid credentials
	# And I am on Home Page
	# And Sort products with Price (High to Low)
	# And click on Add to cart for 'n' number of items
	# And click on cart icon
	# Then Verify system should display count of items in cart over cart icon same as 'n' number of items added
	# And Verify system should display Qty as 1 for each item and description for each added product
	# And verify system should display amount of product added in cart below description of product for each added product
	# And verify system should display Remove button for each added product
	# And verify system should display items under Your Cart in the same order as items are added



	# Given I have logged in to application with valid credentials
	# And I am on Home Page
	# And Sort products with Price (High to Low)
	# And click on Add to cart for 'n' number of items
	# And click on cart icon
	# And click on Remove button for 's' number of items
	# Then Verify system should remove that item from Your Cart page 
	# And Verify count in cart is decreased with number of items removed from cart



	# Given I have logged in to application with valid credentials
	# And I am on Home Page
	# And Sort products with Price (High to Low)
	# And click on Add to cart for 'n' number of items
	# And click on cart icon
	# And click on Remove button for all items in the cart one by one
	# Then Verify system should remove all items from Your Cart page 
	# And Verify count in cart is blank as all items removed from cart



	# Given I have logged in to application with valid credentials
	# And I am on Home Page
	# And Sort products with Price (High to Low)
	# And click on Add to cart for 1 item
	# And click on cart icon
	# And click on Continue Shopping button
	# Then Verify system should navigate user back to Products Page.
	# And add more items to Cart
	# And click on Cart icon
	# Then Verify system should update cart and count in cart with more items added


	# Given I have logged in to application with valid credentials
	# And I am on Home Page
	# And Sort products with Price (High to Low)
	# And click on Add to cart for all items under Products
	# And click on cart icon
	# And click on Checkout button
	# Then Verify system should navigate user to Checkout: Your information Page.


