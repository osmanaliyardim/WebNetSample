using HttpClient client = new();

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Add("User-Agent", "EPAM WEB .NET Mentoring Program");

await ProcessRepositoriesAsync(client);

const string url = "https://localhost:7065/api/";

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    var categoriesJson = await client.GetStringAsync(url + "categories");
    var productsJson = await client.GetStringAsync(url + "products");

    Console.Write(categoriesJson);
    Console.Write(productsJson);
    Console.ReadLine();
}