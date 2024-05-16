using Microsoft.Azure.Cosmos;
using UserRegistration.Models;

namespace UserRegistration.Repository
{
    public class PersonRepositoryImp :  IPersonRepository
    {
        private readonly string _containerName = "Person";
        private readonly string _partitionKeyPath = "/id";
        private readonly string _endpointUri = "https://localhost:8081/";
        private readonly string _primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private readonly CosmosClient _cosmosClient;

        public PersonRepositoryImp() {
            _cosmosClient = new CosmosClient(_endpointUri, _primaryKey);
        }

        public async Task<Person> InsertPersonInformationAsync(Person person)
        {
            Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync("PersonRegistration");

            // Create container properties
            ContainerProperties containerProperties = new ContainerProperties(id: _containerName, partitionKeyPath: _partitionKeyPath);

            // Create or get the container
            Container container = await database.CreateContainerIfNotExistsAsync(containerProperties);



            // Insert item into the container
            ItemResponse<Person> response = await container.CreateItemAsync(person);

            return response;
        }
    }
}
