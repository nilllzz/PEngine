using Newtonsoft.Json;

namespace PEngine.Common.Data.Monsters
{
    public class MonsterSpritePalette
    {
        public int[][] normal;
        public int[][] shiny;

        public static MonsterSpritePalette FromString(string json)
        {
            return JsonConvert.DeserializeObject<MonsterSpritePalette>(json);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
