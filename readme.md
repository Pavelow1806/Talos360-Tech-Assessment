# Engineering recruitment test instructions

Welcome to the backend engineering test. 

There is no time limit to this test. All the information required to complete this
test is in this file. Read through this file carefully and submit us your best code
and your answers to the questions in a single zip file. Send this zip file directly
to your recruiter and they will pass it on to us.

At the bottom of the instructions are the acceptance criteria we expect the code to work for. 
But please feel free to make any changes you want to the solution and refactor in any
way you see fit.

This test consists of a programming exercise where you have 4 user stories to complete, and some feedback
to provide to the junior dev that wrote the initial code.

2 of the stories have been done by a junior developer but there are problems with the
code and they need refactoring.
Story 3 has not yet been attempted.
Story 4 has been started but the developer working on it needs your assistance.

The instructions on completing the stories are contained in the Tasks section.
The questions regarding the feedback to the junior developer are contained in the Questions section.



## Stories 

We require a service that calculates the estimated dispatch dates of 
customers' orders. 

An order consists of an order date and a collection of products that a 
customer has added to their shopping basket. 

As soon as an order is received by a supplier, the supplier will start 
processing the order. The supplier has an agreed lead time in which to 
process the order before delivering it to a central warehouse for dispatch.

Once the warehouse has received all products in an order it is 
dispatched to the customer.

**Assumptions**:

1. Suppliers start processing an order on the same day that the order is 
	received. For example, a supplier with a lead time of one day, receiving
	an order today will send it to the warehouse tomorrow.


2.  There is no cutoff time, so if a supplier has a lead time of 1 day 
    then an order received any time on Tuesday would arrive at
	the warehouse on the Wednesday.

3. Once all products for an order have arrived at the warehouse 
	they will be dispatched to the customer on the same day.

### Story 1 

When the /api/DispatchDate endpoint is hit return the dispatch date of that 
order.

### Story 2

We are getting complaints from customers expecting 
packages to be delivered on the weekend but the warehouse
is shut over the weekend. Packages received into the warehouse on a weekend 
will be dispatched the following Monday.

Modify the existing code to ensure that weekend orders are dispatched
on the following Monday.

### Story 3

Add a basic UI to the application. The UI should allow the user to multi-select from a list of products, and add them to a basket. It should also allow them to remove items from the basket.
As the items in the basket changes it will show them the new estimated delivery date (as calculated by the backend api they have just fixed).
Ideally the UI should be constructed using angular.

---

## Tasks

### Task 1
Stories 1 & 2 have already been completed by a junior dev in the DispatchDateController. Review
the code, and document the problems you find, and refactor into
what you would consider quality code. 

### Task 2
Once this is done implement the requirements listed in story 3.

Note, the provided DbContext is a stubbed class which provides test 
data. Use this in your implementation but keep in mind that it 
would be switched for a real DBContext backed by a real database in live code.

### Task 3
Review the code in the spike controller, and complete it using the information
contained in Story 4.

## Questions

Q1. What points would you bring up to the junior dev in your review and refactor of stories 1 & 2?

Q2. How did you improve these issues? What principles did you use in your solution?


## Request and Response Examples

### Request

~~~~ 
GET /api/dispatchDate?ProductIds={product_id}&orderDate={order_date} 
~~~~

e.g.

~~~~ 
GET /api/dispatchDate?ProductIds=1&orderDate=2024-01-29T00:00:00
GET /api/dispatchDate?ProductIds=2&ProductIds=3&orderDate=2024-01-29T00:00:00 
~~~~

### Response

A JSON object with a date property 

~~~~ 
{
    "date" : "2018-01-30T00:00:00"
}
~~~~ 

## Acceptance Criteria

### Lead time added to dispatch date  

**Given** an order contains a product from a supplier with a lead time of 1 day  
**And** the order is place on a Monday - 01/01/2024  
**When** the dispatch date is calculated  
**Then** the dispatch date is Tuesday - 02/01/2024  

**Given** an order contains a product from a supplier with a lead time of 2 days  
**And** the order is place on a Monday - 01/01/2024  
**When** the dispatch date is calculated  
**Then** the dispatch date is Wednesday - 03/01/2024  

### Supplier with longest lead time is used for calculation

**Given** an order contains a product from a supplier with a lead time of 1 day  
**And** the order also contains a product from a different supplier with a lead time of 2 days  
**And** the order is place on a Monday - 01/01/2024  
**When** the dispatch date is calculated  
**Then** the dispatch date is Wednesday - 03/01/2024  

### Lead time is not counted over a weekend

**Given** an order contains a product from a supplier with a lead time of 1 day  
**And** the order is place on a Friday - 05/01/2024  
**When** the dispatch date is calculated  
**Then** the dispatch date is Monday - 08/01/2024  

**Given** an order contains a product from a supplier with a lead time of 1 day  
**And** the order is place on a Saturday - 06/01/2024  
**When** the dispatch date is calculated  
**Then** the dispatch date is Tuesday - 09/01/2024  

**Given** an order contains a product from a supplier with a lead time of 1 days  
**And** the order is place on a Sunday - 07/01/2024  
**When** the dispatch date is calculated  
**Then** the dispatch date is Tuesday - 09/01/2024  

### Lead time over multiple weeks

**Given** an order contains a product from a supplier with a lead time of 6 days  
**And** the order is place on a Friday - 05/01/2024  
**When** the dispatch date is calculated  
**Then** the dispatch date is Monday - 15/01/2024  

**Given** an order contains a product from a supplier with a lead time of 11 days  
**And** the order is place on a Friday - 05/01/2024  
**When** the dispatch date is calculated  
**Then** the dispatch date is Monday - 22/01/2024