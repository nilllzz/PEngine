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
        public string experienceType;
        public int experienceYield;
        public string[] eggGroups;
        public int eggCycles;
        public int catchRate;
        public decimal wildFleeRate; // 0-1, chance of trying to flee in a wild battle

        public string texture;

        public BaseStats baseStats;
        public MovesetEntryData[] moves;
        public MonsterSpritePalette palette;
        public EvolutionData[] evolutions;

        protected override string GetDefaultFileName(string id) => $"content/{id}.json";

        [JsonIgnore]
        public MonsterGenderNominalRatio GenderRatio => DataHelper.ParseEnum<MonsterGenderNominalRatio>(gender);
        [JsonIgnore]
        public ExperienceType ExperienceType => DataHelper.ParseEnum<ExperienceType>(experienceType);
    }
}
