using Microsoft.Azure.Cosmos;
using UserRegistration.Models;

namespace UserRegistration.Repository
{
    public class QuestionAnswerRepositoryImp : IQuestionAnswerRepository
    {
        private readonly string _containerName = "QuestionAnswer";
        private readonly string _partitionKeyPath = "/id";
        private readonly string _endpointUri = "https://localhost:8081/";
        private readonly string _primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private readonly CosmosClient _cosmosClient;

        public QuestionAnswerRepositoryImp()
        {
            _cosmosClient = new CosmosClient(_endpointUri, _primaryKey);
        }

        public  async Task<QuestionAnswer> InsertAnswersForQuestion(QuestionAnswer questionAnswer)
        {
            Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync("PersonRegistration");

            // Create container properties
            ContainerProperties containerProperties = new ContainerProperties(id: _containerName, partitionKeyPath: _partitionKeyPath);

            // Create or get the container
            Container container = await database.CreateContainerIfNotExistsAsync(containerProperties);

            // Insert item into the container
            ItemResponse<QuestionAnswer> response = await container.CreateItemAsync(questionAnswer);

            return response;
        }
    }
}
