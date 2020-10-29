Problem description: Point Of Sale Code Kata.txt

Implementation.
Source code: https://github.com/andtkach/PointOfSaleCodeKata
Demo: https://youtu.be/RtE9XtojoGA

There are 3 price calculation strategies:
1. Simple. Where not discounts applied
2. Replace. Where we replace items in the bucket with a single set of items with discount
3. Divide. Where we update the price in the bucket with price with the discount

Problems:
1. Bucket is not threading safe
2. No exception handling
3. No input parameters validation

Improvements:
1. There is only one price with a discount. Probably it is better to have a list of discounts.
	Single product costs $1.25
	Get 3 producrs for $3.1
	Get 6 products for $5.9

2. Compound discounts where product cost is applied if there are other products in the bucket.
	Single product A costs $1.25
	Get product B and product A will cost $1.1
	
3. There are no tests to check failed behavior or expected failures.
