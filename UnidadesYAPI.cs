namespace Unidades
{

    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    public class Unidad
    {
        //AQUI INICIA MANEJO DE API, LUEGO ESTA LA CLASE UNIDAD

        public class Name
        {
            [JsonProperty("first")]
            public string First { get; set; }

            [JsonProperty("last")]
            public string Last { get; set; }
        }

        public class Result
        {
            [JsonProperty("name")]
            public Name Name { get; set; }
        }

        public class ApiResponse
        {
            [JsonProperty("results")]
            public List<Result> Results { get; set; }
        }

        public static List<string> nombresDisponibles = new List<string>();

        public static async Task TraerNombreAPI()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://randomuser.me/api/?results=150");     //Traigo 150 nombres
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);             //Deserializamos

            foreach (var result in apiResponse.Results)                                             //Guardamos en una lista
            {
                nombresDisponibles.Add($"{result.Name.First}");
            }
        }

        public static string ObtenerNombreAleatorio()
        {
            if (nombresDisponibles.Count == 0)
            {
                throw new InvalidOperationException("No hay nombres disponibles.");
            }

            var random = new Random();
            int index = random.Next(nombresDisponibles.Count);  //Para sacar por indice
            var nombre = nombresDisponibles[index];
            nombresDisponibles.RemoveAt(index); // Elimina el nombre para que no se repita
            return nombre;
        }


        //AQUI TERMINA USO DE API

        //----------------------------------------------------------------------------------------------------------

        //COMIENZA CLASE UNIDADES
        private string nombre;
        private int ataque;
        private int defensa;
        private TipoUnidad tipo;
        private int costo;
        public enum TipoUnidad
        {
            comun,
            tanque,
            daño
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Ataque { get => ataque; set => ataque = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        public TipoUnidad Tipo { get => tipo; set => tipo = value; }
        public int Costo { get => costo; set => costo = value; }

        public Unidad(string nombre, int ataque, int defensa, TipoUnidad tipo, int costo)
        {
            this.nombre = nombre;
            this.ataque = ataque;
            this.defensa = defensa;
            this.tipo = tipo;

            this.costo = costo;

        }



        public Unidad()
        {

        }

        public void bajandoStats()
        {
            Ataque = Ataque / 2;
            Defensa = Defensa / 2;
            if (Ataque == 0)
            {
                Ataque = 1;
            }
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Ataque: {Ataque}, Defensa: {Defensa}, Tipo: {Tipo}";
        }
        public static Unidad CrearUnidadNormal()
        {
            Unidad objeto = new Unidad(ObtenerNombreAleatorio(), 4, 3, TipoUnidad.comun, 10);
            return objeto;
        }
        public static Unidad CrearUnidadTanque()
        {
            Unidad objeto = new Unidad(ObtenerNombreAleatorio(), 4, 9, TipoUnidad.tanque, 15);
            return objeto;
        }
        public static Unidad CrearUnidadDaño()
        {
            Unidad objeto = new Unidad(ObtenerNombreAleatorio(), 8, 4, TipoUnidad.daño, 20);
            return objeto;
        }

        public static List<Unidad> CrearListaUnidades()
        {
            var unidades = new List<Unidad>();

            return unidades;
        }
        //Funcion para crear la unidad jugador y listarla en la lista de unidades del jugador
        public static void CrearUnidadJugador(Unidad unidad, int oroJugador, List<Unidad> unidadesJugador)
        {
            if (oroJugador >= unidad.Costo)
            {
                unidadesJugador.Add(unidad);
                oroJugador -= unidad.Costo;
                Console.WriteLine($"Unidad {unidad.Tipo} creada. Nombre: {unidad.Nombre}.");
            }
            else
            {
                Console.WriteLine("Oro insuficiente para crear la unidad.");
            }
        }



    }
}