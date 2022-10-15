using System.Text.Json.Serialization;

namespace D4APIClient.Dtos
{
    public partial class D4SpaceDto
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("spaces")]
        public Spaces Spaces { get; set; }
    }

    public partial class Node
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("points")]
        public Spaces Points { get; set; }
    }

    public partial class Edge
    {
        [JsonPropertyName("node")]
        public Node Node { get; set; }
    }

    public partial class Spaces
    {
        [JsonPropertyName("edges")]
        public Edge[] Edges { get; set; }
    }
}
