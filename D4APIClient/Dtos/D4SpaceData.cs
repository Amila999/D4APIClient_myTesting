using System.Text.Json.Serialization;

namespace D4APIClient.Dtos
{
    public partial class D4SpaceData
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("launches")]
        public D4SpaceDto[] D4Spaces { get; set; }
    }
}
