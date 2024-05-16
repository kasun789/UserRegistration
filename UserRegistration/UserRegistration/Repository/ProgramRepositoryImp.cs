using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;
using UserRegistration.Models;

namespace UserRegistration.Repository
{
    public class ProgramRepositoryImp : IProgramRepository
    {
        private readonly string _containerName = "Program";
        private readonly string _partitionKeyPath = "/id";
        private readonly string _endpointUri = "https://localhost:8081/";
        private readonly string _primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private readonly CosmosClient _cosmosClient;

        public ProgramRepositoryImp()
        {
            _cosmosClient = new CosmosClient(_endpointUri, _primaryKey);
        }

        public async Task<Programs> InsertProgramDetailAsync(Programs program)
        {
            // Create or get the database
            Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync("PersonRegistration");

            // Create container properties
            ContainerProperties containerProperties = new ContainerProperties(id: _containerName, partitionKeyPath: _partitionKeyPath);

            // Create or get the container
            Container container = await database.CreateContainerIfNotExistsAsync(containerProperties);



            // Insert item into the container
            ItemResponse<Programs> response = await container.CreateItemAsync(program);

            return response;
        }
    }
}
