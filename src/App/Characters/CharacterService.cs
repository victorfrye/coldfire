using System.Diagnostics;
using System.Text.Json;
using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.App.Characters
{
    public class CharacterService : RestService<Character>
    {
        public CharacterService() : base(new Uri(string.Concat(
                DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7246" : "https://localhost:7246",
                "/api/characters"))) { }

        public override async Task<Character> SendGet(int id)
        {
            Character character = null;

            try
            {
                var response = await _client.GetAsync($"{_baseUri}/{id}");
                if (!response.IsSuccessStatusCode) { return character; }

                character = JsonSerializer.Deserialize<Character>(await response.Content.ReadAsStringAsync(), _serializerOptions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return character;
        }
    }
}
