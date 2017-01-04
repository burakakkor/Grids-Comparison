using Newtonsoft.Json;

namespace Grids.Core.Models
{
    public class GridColumn
    {
        public string Field { get; set; }

        public string Title { get; set; }

        public int Width { get; set; }

        [JsonProperty("locked")]
        public bool IsLocked { get; set; }

        [JsonProperty("lockable")]
        public bool IsLockable { get; set; }
    }
}
