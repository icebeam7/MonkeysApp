using MonkeysApp.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace MonkeysApp.Services
{
    public class MonkeyService
    {
        HttpClient httpClient;
        public MonkeyService()
        {
            this.httpClient = new HttpClient();
        }

        List<Monkey> monkeyList;
        public async Task<List<Monkey>> GetOnlineMonkeys()
        {
            var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");

            if (response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }

            return monkeyList;
        }

        public async Task<List<Monkey>> GetOfflineMonkeys()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);
            return monkeyList;
        }
    }
}
