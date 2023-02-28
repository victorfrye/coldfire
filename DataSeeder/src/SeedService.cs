using Newtonsoft.Json;

namespace VictorFrye.Coldfire.DataSeeder
{
    public class SeedService
    {

        private static List<TDto> GetDtoData<TDto>(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find {Path.GetFullPath(path)}");
            }

            var dtos = JsonConvert.DeserializeObject<List<TDto>>(File.ReadAllText(path));

            return dtos;
        }
    }
}
