using Newtonsoft.Json;

namespace PEngine.Common.Data.Monsters
{
    public class MonsterData : Resource<MonsterData>
    {
        public int number;
        public string name;
        public string gender;
        public string type1;
        public string type2;
        public int[] baseStats; // 0 => HP, 1 => ATK, 2 => DEF, 3 => SPCDEF, 4 => SPCATK, 5 => SPD
        public string experienceType;
        public int experienceYield;
        public string[] eggGroups;
        public int eggCycles;
        public int catchRate;
        public double wildFleeRate; // 0-1, chance of trying to flee in a wild battle

        public string texture;

        public MovesetEntryData[] moves;
        public MonsterSpritePalette palette;
        public EvolutionData[] evolutions;
        public DexData dex;

        protected override string GetDefaultFileName(string id) => $"content/{id}.json";

        [JsonIgnore]
        public MonsterGenderNominalRatio GenderRatio => DataHelper.ParseEnum<MonsterGenderNominalRatio>(gender);
        [JsonIgnore]
        public ExperienceType ExperienceType => DataHelper.ParseEnum<ExperienceType>(experienceType);
    }
}
