using Microsoft.Azure.Cosmos;
using UserRegistration.Models;

namespace UserRegistration.Repository
{
    public class QuestionRepositoryImp : IQuestionRepository
    {
        private readonly string _containerName = "Question";
        private readonly string _partitionKeyPath = "/id";
        private readonly string _endpointUri = "https://localhost:8081/";
        private readonly string _primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private readonly CosmosClient _cosmosClient;

        public QuestionRepositoryImp()
        {
            _cosmosClient = new CosmosClient(_endpointUri, _primaryKey);
        }

        public async Task<bool> DeleteQuestionAsync(string id)
        {
            Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync("PersonRegistration");

            // Create container properties
            ContainerProperties containerProperties = new ContainerProperties(id: _containerName, partitionKeyPath: _partitionKeyPath);

            // Create or get the container
            Container container = await database.CreateContainerIfNotExistsAsync(containerProperties);



            // Insert item into the container
            ItemResponse<dynamic> response = await container.DeleteItemAsync<dynamic>(id,new PartitionKey(id));

            return true;

        }

        public async Task<Question> GetQuestionById(string id)
        {
            Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync("PersonRegistration");

            // Create container properties
            ContainerProperties containerProperties = new ContainerProperties(id: _containerName, partitionKeyPath: _partitionKeyPath);

            // Create or get the container
            Container container = await database.CreateContainerIfNotExistsAsync(containerProperties);



            // Insert item into the container
            Question response = await container.ReadItemAsync<Question>(id, new PartitionKey(id));
            return response;
        }

        public async Task<Question> InsertQuestionAsync(Question question)
        {
            // Create or get the database
            Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync("PersonRegistration");

            // Create container properties
            ContainerProperties containerProperties = new ContainerProperties(id: _containerName, partitionKeyPath: _partitionKeyPath);

            // Create or get the container
            Container container = await database.CreateContainerIfNotExistsAsync(containerProperties);



            // Insert item into the container
            ItemResponse<Question> response = await container.CreateItemAsync(question);

            return response;
        }
    }
}
