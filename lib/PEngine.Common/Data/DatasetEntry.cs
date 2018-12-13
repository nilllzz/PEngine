using Newtonsoft.Json;
using System.Linq;

namespace PEngine.Common.Data
{
    public class DatasetEntry
    {
        public string id;
        public string value;

        [JsonIgnore]
        public int[] IntArr
        {
            get => value.Split('|').Select(p => int.Parse(p)).ToArray();
            set => this.value = string.Join("|", value);
        }

        [JsonIgnore]
        public bool Bool
        {
            get => value == "1";
            set => this.value = value ? "1" : "0";
        }
    }
}
