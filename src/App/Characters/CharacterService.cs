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

/*            return new Character(
                id: 583,
                name: "Jon Snow",
                gender: "Male",
                culture: "Northmen",
                born: "In 283 AC",
                died: null,
                titles: new List<string> { "Lord Commander of the Night's Watch" },
                aliases: new List<string>
                {
                    "Lord Snow",
                    "Ned Stark's Bastard",
                    "The Snow of Winterfell",
                    "The Crow-Come-Over",
                    "The 998th Lord Commander of the Night's Watch",
                    "The Bastard of Winterfell",
                    "The Black Bastard of the Wall",
                    "Lord Crow"
                },
                father: null,
                mother: null,
                spouse: null,
                allegiances: new List<string>(),
                books: new List<string>(),
                povBooks: new List<string>(),
                tvSeries: new List<string>
                {
                    "Season 1",
                    "Season 2",
                    "Season 3",
                    "Season 4",
                    "Season 5",
                    "Season 6"
                },
                playedBy: new List<string> { "Kit Harington" });*/
        }
    }
}
