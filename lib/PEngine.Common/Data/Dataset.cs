using System.Linq;

namespace PEngine.Common.Data
{
    public abstract class Dataset
    {
        public DatasetEntry[] data;

        protected DatasetEntry GetData(string id)
        {
            if (data == null || data.FirstOrDefault(d => d.id == id) == null)
            {
                SetData(id, "");
            }
            return data.FirstOrDefault(d => d.id == id);
        }

        protected void SetData(string id, string value)
        {
            var entry = new DatasetEntry { id = id, value = value };
            if (data == null)
            {
                data = new[] { entry };
            }
            else
            {
                var existingData = data.FirstOrDefault(d => d.id == id);
                if (existingData != null)
                {
                    existingData.value = entry.value;
                }
                else
                {
                    var dataList = data.ToList();
                    dataList.Add(entry);
                    data = dataList.ToArray();
                }
            }
        }
    }
}
