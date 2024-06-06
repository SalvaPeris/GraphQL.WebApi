<p align="center">
  <img src="https://github.com/SalvaPeris/GraphQL.WebApi/assets/79948536/3c750118-03ba-41aa-b5c2-4371915eb8bb" width="300" />
  <img src="https://github.com/SalvaPeris/GraphQL.WebApi/assets/79948536/419afb93-ccc1-4167-b4bf-b0f843e53443" width="300" />
</p>


### Repository for Movie Reviews with GraphQL

#### Overview
In a GraphQL API, the repository pattern is used to manage data access logic. The repository encapsulates the operations of retrieving and storing data, making it easier to manage and test the data layer separately from the business logic.

#### Step 1: Define the Repository Interface
First, an interface for the repository is defined. This interface declares methods for handling data operations, such as fetching all movies.

#### Step 2: Implement the Repository
Next, the repository interface is implemented. This implementation contains the actual logic for data retrieval and storage. For example, it may include methods to fetch all movies from an in-memory list, a database, or an external API.

#### Benefits
1. **Separation of Concerns**: By using a repository, the data access logic is separated from the business logic, making the codebase easier to maintain and extend.
2. **Testability**: The repository pattern makes it easier to write unit tests for the data access layer. Mock repositories can be used to simulate data operations during testing.
3. **Flexibility**: The repository can be easily swapped out for different data sources, such as switching from an in-memory database to a SQL database, without changing the business logic.

#### Example Usage in a GraphQL API
1. Navigate to: 
  https://localhost:7007/ui/altair
![image](https://github.com/SalvaPeris/GraphQL.WebApi/assets/79948536/2b7010d8-127a-4595-8a10-527d23996c0c)
3. Play with GraphQL API!
