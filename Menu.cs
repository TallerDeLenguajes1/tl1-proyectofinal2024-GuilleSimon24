using Gameplay;

class Menu
{

    public Menu()
    {

    }
    public async Task MostrarMenu()
    {
        Pantalla UI = new Pantalla();
        UI.Menu();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nMenú Principal:");
        Console.WriteLine("1. Nuevo Juego");
        Console.WriteLine("2. Ver Lista de Ganadores");
        Console.WriteLine("3. Salir");
        Console.ResetColor();
        bool valido = false;
        int opcion;
        do
        {
            string opCadena = Console.ReadLine();
            bool anda = int.TryParse(opCadena, out opcion);
            switch (opcion)
            {
                case 1:
                    Juego iniciar = new Juego();
                    await iniciar.IniciarJuego();
                    break;
                case 2:
                    JSON ganadores = new JSON();
                    var Lista = new List<ResultadoJuego>();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ganadores Historicos");
                    Console.ResetColor();
                    ganadores.TraerDeJsonYMostrar("JSON/Ganadores.json");
                    await MostrarMenu();
                    break;
                case 3:
                    Console.WriteLine("- - - - Hasta pronto - - - -");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                    Console.ResetColor();
                    break;
            }
        } while (valido == false || opcion < 0 || opcion > 3);
    }
    public async Task InciarAPP()
    {
        await MostrarMenu();
    }
    
}