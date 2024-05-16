using Microsoft.Azure.Cosmos;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

using CosmosClient client = new(
    accountEndpoint: "https://localhost:8081/",
    authKeyOrResourceToken: "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="
);

Database database = await client.CreateDatabaseIfNotExistsAsync(
    id: "PersonRegistration",
    throughput: 400
);

Microsoft.Azure.Cosmos.Container person = await database.CreateContainerIfNotExistsAsync(
    id: "Person",
    partitionKeyPath: "/id"
);

Microsoft.Azure.Cosmos.Container program = await database.CreateContainerIfNotExistsAsync(
    id: "Program",
    partitionKeyPath: "/id"
);

Microsoft.Azure.Cosmos.Container question = await database.CreateContainerIfNotExistsAsync(
    id: "Question",
    partitionKeyPath: "/id"
);

var item = new
{
    id = "68719518371",
    title = "Summer Internship Program",
    description = "You can provide all information about the program here. Please make sure to set the expectation and keep it clear",
};

await program.UpsertItemAsync(item);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
