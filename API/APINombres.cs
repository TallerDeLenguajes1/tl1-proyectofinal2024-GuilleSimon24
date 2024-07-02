using Newtonsoft.Json;
class APINombres
{
    private const string RequestUri = "https://randomuser.me/api/?results=150";

    public async Task<List<string>> TraerNombreAPI()
    {
        List<string> nombresDisponibles = new List<string>();

        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(RequestUri);     //Traigo 150 nombres
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);             //Deserializamos

        foreach (var result in apiResponse.Results)                                             //Guardamos en una lista
        {
            nombresDisponibles.Add($"{result.Name.First}");
        }

        return nombresDisponibles;
    }


}
