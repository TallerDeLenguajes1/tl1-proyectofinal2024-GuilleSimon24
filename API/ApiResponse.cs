using Newtonsoft.Json;
public class ApiResponse
{
    [JsonProperty("results")]
    public List<Result> Results { get; set; }
}
