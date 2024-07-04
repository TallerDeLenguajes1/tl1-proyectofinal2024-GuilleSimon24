using System.Text.Json;
class JSON
{
    public JSON()
    {
    }

    public List<ResultadoJuego> TraerDeJson(string nombreArchivo)
    {
        try
        {
            if (!File.Exists(nombreArchivo))
            {
                Console.WriteLine("No existen ganadores todavía");
                return new List<ResultadoJuego>();
            }

            string jsonString = File.ReadAllText(nombreArchivo);
            List<ResultadoJuego> traidoDeJson = JsonSerializer.Deserialize<List<ResultadoJuego>>(jsonString);
            return traidoDeJson;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al traer los datos del archivo JSON: {ex.Message}");
            return new List<ResultadoJuego>();
        }
    }

    public void TraerDeJsonYMostrar(string nombreArchivo)
    {
        try
        {
            if (!File.Exists(nombreArchivo))
            {
                Console.WriteLine("No existen ganadores todavía");
            }
            
            string jsonString = File.ReadAllText(nombreArchivo);
            List<ResultadoJuego> traidoDeJson = JsonSerializer.Deserialize<List<ResultadoJuego>>(jsonString);
            foreach (ResultadoJuego unidad in traidoDeJson)
            {
                Console.WriteLine("- - - - - - - - - - - - - ");
                Console.WriteLine($"Nombre: {unidad.NombreGanador}");
                Complemento.mostrarStats(unidad.BaseGanador);
                Console.WriteLine($"Oro gastado: {unidad.OroGastado}");
                Console.WriteLine($"Fecha y hora de la hazaña: {unidad.FechaYHora}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al traer los datos del archivo JSON: {ex.Message}");
        }
    }

    public void GenerarJSON(ResultadoJuego resultado, string nombreArchivo)
    {
        var opciones = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Para evitar los acentos
            WriteIndented = true
        };

        List<ResultadoJuego> ganadores = new List<ResultadoJuego>();

        if (File.Exists(nombreArchivo))
        {
            ganadores = TraerDeJson(nombreArchivo);
        }

        ganadores.Add(resultado);
        string jsonString = JsonSerializer.Serialize(ganadores, opciones);

        // Guardo el JSON en el archivo
        File.WriteAllText(nombreArchivo, jsonString);
    }


}