using Newtonsoft.Json;

class APINombres
{
    private List<string> nombresPorDefecto = new List<string>
        {
            "Juan", "María", "Pedro", "Ana", "Luis", "Carmen", "José", "Laura", "Carlos", "Elena",
            "Miguel", "Lucía", "Javier", "Sara", "Antonio", "Isabel", "David", "Paula", "Manuel", "Marta",
            "Francisco", "Patricia", "Raúl", "Adriana", "Diego", "Sofía", "Rafael", "Andrea", "Álvaro", "Claudia",
            "Hugo", "Nuria", "Daniel", "Rosa", "Fernando", "Victoria", "Enrique", "Silvia", "Alejandro", "Beatriz",
            "Ricardo", "Sandra", "Pablo", "Verónica", "Alberto", "Cristina", "Sergio", "Irene", "Roberto", "Mónica",
            "Joaquín", "Esther", "Arturo", "Eva", "Mario", "Julia", "Vicente", "Natalia", "Héctor", "Ángela",
            "Emilio", "Rocío", "Andrés", "Marina", "Oscar", "Lorena", "Ramón", "Alicia", "Martín", "Clara",
            "Gonzalo", "Noelia", "Félix", "Teresa", "Ignacio", "Gloria", "Hernán", "Raquel", "Luis", "Inés",
            "Tomás", "Belén", "Iván", "Leandro", "Lidia", "Federico", "Celia", "Gregorio", "Cristina", "Bernardo",
            "Sonia", "Julio", "María José", "Santiago", "Susana", "Ana Belén", "Marcos", "Ángel", "Gustavo", "Simón",
            "Nicolás", "Olga", "Valentín", "Aurora", "Bruno", "Elisa", "Teodoro", "Rosario", "Jorge", "Ángeles",
            "Marcelo", "Pilar", "Adrián", "Margarita", "Rubén", "Virginia", "Israel", "Consuelo", "Leonardo", "Amparo",
            "Ariel", "Cristian", "Miriam", "Sebastián", "Antonia", "Mauricio", "Estela", "Ramiro", "Magdalena", "Saúl",
            "Aitana", "Darío", "África", "Lourdes", "Jesús", "Antonia", "Raúl", "Esteban", "Maribel", "Rafaela",
            "José Luis", "Begoña", "Ricardo", "Lorenzo", "Montserrat", "Guillermo", "Elvira", "Emilia", "Teresa",
            "Pascual", "Águeda", "José Manuel", "Filomena", "Gregorio", "Salvador"
        };

    private Result result;
    private const string RequestUri = "https://randomuser.me/api/?results=150";
    public Result Result { get => result; set => result = value; }

    public async Task<List<string>> TraerNombreAPI()
    {
        try
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
        catch(HttpRequestException e)
        {
            Console.WriteLine($"No se pudo conectar con la API. Usando una lista de nombres por defecto. Detalles del error: {e.Message}");
            return nombresPorDefecto;
        }
    }
}
