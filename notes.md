# James Coyle Notes

## Tasks

### Task 1 & 2
#### Problems found
- SOLID not followed particularly well based on how the Get function in the controller is doing all of the work.
- Solution not scalable when more functionality is added later.
- No need to have a public variable when it's only used by one method inside the request scope.
- Using foreach in this case is redundant
	- DbContext is being made on every iteration potentially using more memory than required.
	- The "database" is being hit twice on every iteration.
- Using an if statement makes it difficult to read, even if it was going to be used, consistent curly braces should be used to promote readability.
#### Notes
- Made controller Get function asynchronous and added the cancellation token.
- Added ResponseBase abstract class for response classes to use to add whether the request has been successful and if there were any messages.
- Added null reference and invalid parameter checks before processing request.
- Changed the input request variables into a request class and changed the controller function definition to a HttpPost.
- Created requests and responses folders to allow the solution to be managable as it scales.
- Renamed DispatchDate to DispatchDateResponse to signify what its purpose is.
- Changed the orderDate field type to DateTimeOffset to ensure when the API is used overseas timezone differences are kept in mind.
- Added DbContext as injectable service.
- Created the DispatchEstimationService using dependancy injection and code reuse.
- Moved primary responsibility to the new service.
- Split the original functionality into 2 function calls each with their own responsibility.
- Added service for managing products, and added it to dependency injection.
- Added service for managing suppliers, and added it to dependency injection.
- Made extension class for DateTimeOffset to add the required amount of days.
- These services are designed to be individual and extendable to allow access or modifications to have minimal impact in the future.
- I think the patterns I've used is overkill in this case but I'm just trying to demonstrate best practice.


### Task 3
- I've made the db context a singleton, which would never be the case in the real world but with the absense of a real database this was the easiest thing to do to create a basket in memory.