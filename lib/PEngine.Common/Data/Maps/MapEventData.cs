using Newtonsoft.Json;

namespace PEngine.Common.Data.Maps
{
    public class MapEventData : Dataset
    {
        public string type;
        public int[] pos;
        public string name;
        public string target; // either map file id for warp or script file id for script

        [JsonIgnore]
        public MapEventType EventType => DataHelper.ParseEnum<MapEventType>(type);

        [JsonIgnore]
        public DatasetEntry WarpPositionData
        {
            get => GetData("warppos");
            set => SetData(value.value, "warppos");
        }

        [JsonIgnore]
        public DatasetEntry WarpRotationData
        {
            get => GetData("warprot");
            set => SetData(value.value, "warprot");
        }

        public bool Equals(MapEventData other)
        {
            return other != null &&
                other.EventType == EventType &&
                other.pos[0] == pos[0] &&
                other.pos[1] == pos[1];
        }
    }
}
