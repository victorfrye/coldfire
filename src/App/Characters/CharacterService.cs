using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.App.Characters
{
    public class CharacterService : IService<Character>
    {
        public CharacterService() { }

        public Character Find(int id)
        {
            return new Character(
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
                playedBy: new List<string> { "Kit Harington" });
        }
    }
}
