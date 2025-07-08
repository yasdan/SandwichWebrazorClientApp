using System.Text.Json;

namespace WebAppRazorClient
{
    public class SandwichService
    {
        public SandwichService()
        {

        }

        public async Task<List<SandwichModel>> GetSandwiches()
        {
            try
            {
                HttpClient client = new HttpClient();

                 await using Stream stream =
                     await client.GetStreamAsync("https://localhost:7250/api/Sandwitche");
                //var data = await client.GetAsync("https://localhost:7250/api/Sandwitche");
                var sandwiches =
                    await JsonSerializer.DeserializeAsync<List<SandwichModel>>(stream);
                 //return sandwiches ?? new();// Initialize a new instance of List<Repository> class
                return sandwiches;                          // which is empty and has default initial capacity.
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}
