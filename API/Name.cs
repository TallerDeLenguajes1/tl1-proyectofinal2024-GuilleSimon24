using Newtonsoft.Json;

public class Name
{
    [JsonProperty("first")]
    public string First { get; set; }

    [JsonProperty("last")]
    public string Last { get; set; }
}
