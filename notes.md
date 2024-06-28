# James Coyle Technical Assessment

#### Questions
##### Q1
> What points would you bring up to the junior dev in your review and refactor of stories 1 & 2?
- SOLID not followed particularly well based on how the Get function in the controller is doing all of the work.
- Solution not scalable when more functionality is added later.
- No need to have a public variable when it's only used by one method inside the request scope.
- The response class name doesn't signify its purpose in the system.
	- The Date field is too much of a generic name for other developers to understand what it's value represents.
- Using foreach in this case is redundant
	- DbContext is being made on every iteration potentially using more memory than required.
	- The "database" is being hit twice on every iteration.
- Using an if statement makes it difficult to read, even if it was going to be used, consistent curly braces should be used to promote readability.
- Only one of the 5 unit tests passed due to it using todays date (and the test being ran on a Saturday).
- The tests aren't written in a way consistent to the AAA testing pattern
- Tests don't provide sufficient coverage against acceptance criteria.
#### Q2
> How did you improve these issues? What principles did you use in your solution?
- Added ResponseBase abstract class for response classes to use to add whether the request has been successful and if there were any messages.
- Added null reference and invalid parameter checks before processing request.
- Renamed DispatchDate to DispatchDateResponse to signify its purpose within the system.
- Renamed Date field to EstimatedDispatchDate within DispatchDateResponse.
- Created requests and responses folders to allow the solution to be managable as it scales.
- Changed the orderDate field type to DateTimeOffset to ensure when the API is used overseas timezone differences are kept in mind.
- Added DbContext as injectable service.
- Added a new service called DispatchEstimationService to dependancy injection and moved the primarily functionality to the service.
- Split the original functionality into 2 function calls within the service, each with their own responsibility.
- Added a new service for managing products and another for managing suppliers, and added it to dependency injection.
- Made extension class for DateTimeOffset to avoid the weekend.
- Modified tests to follow AAA testing and to keep to the acceptance criteria.
#### Notes
- These services are designed to be individual and extendable to allow access or modifications to have minimal impact in the future.
- I think the patterns I've used is overkill in this case but I'm just trying to demonstrate best practice.

### Task 3
#### Notes
- Added angular frontend based on the requirements.
- In order to create an in-memory basket, I've added a new property to the DbContext and IDbContext class and interface and instead of injecting it as a Scoped service, I've switched it to Singleton to maintain the variables values whilst running.
- 