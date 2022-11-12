using HttpClient client = new();

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Add("User-Agent", "EPAM WEB .NET Mentoring Program");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    var categoriesJson = await client.GetStringAsync(
    "https://localhost:7065/api/Categories/");

    var productsJson = await client.GetStringAsync(
    "https://localhost:7065/api/Products/");

    Console.Write(categoriesJson);
    Console.Write(productsJson);
    Console.ReadLine();
}