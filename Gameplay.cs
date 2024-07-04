namespace Gameplay
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class Juego
    {
        FabricaDeUnidades fabricaDeUnidades;
        AtaqueBases ataqueBases;
        private Jugador jugador;
        private Jugador enemigo;
        private int turno;
        private Combate combate;
        private Pantalla UI;

        public Juego()
        {
            jugador = new Jugador();
            enemigo = new Jugador();
            jugador.BaseDeJugador = new Base();
            enemigo.BaseDeJugador = new Base();
            jugador.Oro = 50;
            enemigo.Oro = 50;
            ataqueBases = new AtaqueBases();
            turno = 1;
            combate = new Combate();
            UI = new Pantalla();
        }

        public async Task IniciarJuego()
        {
            UI.Bienvenido();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingrese un nombre para identificarlo");
            jugador.Nombre = Console.ReadLine();
            await IniciarFabricaDeUnidades();
            IniciarBases();
            Console.ResetColor();


            jugador.Unidades = CrearListaUnidades();

            enemigo.Unidades = CrearListaUnidades();

            jugador.HistorialUnidades = CrearListaUnidades();
            bool peleaLarga = false;
            // Comenzar el ciclo de turnos
            while (!FinDelJuego(jugador, enemigo))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\n--- Turno {turno} ---");
                Console.ResetColor();
                JugarTurno();
                turno++;

                if (turno > 50)     //Por si la pelea se extiende demasiado
                {
                    Complemento.PeleaLarga(jugador, enemigo);
                    peleaLarga = true;
                    break;
                }
            }
            //Resultado del juego
            if (!peleaLarga)
            {
                Complemento.Resultado(jugador, enemigo);
            }

        }

        private void IniciarBases()
        {
            jugador.BaseDeJugador.CrearBasePropia();
            enemigo.BaseDeJugador.CrearBaseEnemiga();
        }

        private async Task IniciarFabricaDeUnidades()
        {

            APINombres API = new APINombres();
            List<string> nombresDisponibles = await API.TraerNombreAPI();
            fabricaDeUnidades = new FabricaDeUnidades(nombresDisponibles);
        }

        private void JugarTurno()
        {

            //Muestro base y oro de jugadores antes de pelear
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Base del jugador: ");
            Complemento.mostrarStats(jugador.BaseDeJugador);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Base del enemigo: ");
            Complemento.mostrarStats(enemigo.BaseDeJugador);
            Console.ResetColor();


            //Muestro todos los turnos el oro de ambos
            //CONSULTAR SI SOLO MUESTRO EL MIO. LA IDEA ES QUE HAYA QUE CALCULAR SEGUN LO QUE HAGA EL OTRO
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Oro del Jugador: {jugador.Oro}");
            Console.WriteLine($"Oro del Enemigo: {enemigo.Oro}");
            Console.ResetColor();
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Unidades del jugador:");
            Complemento.MostrarListaUnidades(jugador.Unidades);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unidades del enemigo: ");
            Complemento.MostrarListaUnidades(enemigo.Unidades);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            TurnoJugador();
            Console.ForegroundColor = ConsoleColor.Red;
            TurnoEnemigo();
            jugador.Oro += 5;
            enemigo.Oro += 5;
            // Realizar combate
            Console.ForegroundColor = ConsoleColor.Green;
            combate.Combatir(jugador, enemigo);
            Console.ResetColor();
        }

        private void TurnoJugador()
        {
            bool turnoValido = false;
            while (!turnoValido)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--------------------");
                Console.WriteLine("Turno del Jugador:");
                Console.WriteLine("1. Crear unidad normal (10 de oro)");
                Console.WriteLine("2. Crear unidad tanque (15 de oro)");
                Console.WriteLine("3. Crear unidad de daño (20 de oro)");
                Console.WriteLine("4. Saltar turno");
                Console.WriteLine("--------------------");
                

                int opcion = 0;
                bool anda = false;
                Console.ForegroundColor = ConsoleColor.Magenta;
                do
                {
                    string opCadena = Console.ReadLine();
                    anda = int.TryParse(opCadena, out opcion);
                    switch (opcion)
                    {
                        case 1:
                            CrearUnidadJugador(fabricaDeUnidades.CrearUnidadNormal(), jugador);
                            turnoValido = true;
                            break;
                        case 2:
                            CrearUnidadJugador(fabricaDeUnidades.CrearUnidadTanque(), jugador);
                            turnoValido = true;
                            break;
                        case 3:
                            CrearUnidadJugador(fabricaDeUnidades.CrearUnidadDaño(), jugador);
                            turnoValido = true;
                            break;
                        case 4:
                            Console.WriteLine("");
                            Console.WriteLine("Turno saltado.");
                            turnoValido = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor, elija una opción válida.");
                            break;
                    }
                } while (anda == false || opcion < 0 || opcion > 4);


                // Ataque automático a la base del Enemigo si no hay unidades en el campo
                if (enemigo.Unidades.Count == 0 && jugador.Unidades.Count > 0 && turno != 1)
                {
                    ataqueBases.AtacarBaseEnemiga(jugador, enemigo);
                }
                Console.ResetColor();
            }
        }
        //Turno aleatorio para el enemigo
        private void TurnoEnemigo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Turno del Enemigo:");
            // Lógica simple para el enemigo, crea unidades aleatoriamente si tiene suficiente oro
            int opcion = new Random().Next(1, 5);
            Unidad unidadEnemiga = null;
            switch (opcion)
            {
                case 1:
                    unidadEnemiga = fabricaDeUnidades.CrearUnidadNormal();
                    break;
                case 2:
                    unidadEnemiga = fabricaDeUnidades.CrearUnidadTanque();
                    break;
                case 3:
                    unidadEnemiga = fabricaDeUnidades.CrearUnidadDaño();
                    break;
                case 4:
                    Console.WriteLine("El enemigo ha salteado su turno");
                    break;
            }

            if (unidadEnemiga != null && enemigo.Oro >= unidadEnemiga.Costo)
            {
                enemigo.Unidades.Add(unidadEnemiga);
                enemigo.Oro -= unidadEnemiga.Costo;

                Console.WriteLine("--------------------");
                Console.WriteLine($"El enemigo ha creado una unidad {unidadEnemiga.Tipo}. Llamada: {unidadEnemiga.Nombre}");

            }
            else
            {
                if (opcion != 4)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("El enemigo no tiene suficiente oro para crear una unidad. Turno salteado");
                    Console.WriteLine("----------------------");
                }
            }
            /*
            if (jugador.Unidades.Count == 0 && enemigo.Unidades.Count > 0 && turno != 1)
                {
                    ataqueBases.AtacarBaseJugador(jugador, enemigo);
                }*/
            Console.ResetColor();
        }

        private List<Unidad> CrearListaUnidades()
        {
            var unidades = new List<Unidad>();

            return unidades;
        }
        private void CrearUnidadJugador(Unidad unidad, Jugador jugador)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (jugador.Oro >= unidad.Costo)
            {
                jugador.Unidades.Add(unidad);
                jugador.Oro -= unidad.Costo;

                Console.WriteLine("----------------------");
                Console.WriteLine($"Unidad {unidad.Tipo} creada. Nombre: {unidad.Nombre}.");
                Console.WriteLine("----------------------");


                Unidad clon = new Unidad();
                clon = unidad;
                jugador.OroGastado += unidad.Costo;
                jugador.HistorialUnidades.Add(clon);

            }
            else
            {
                Console.WriteLine("Oro insuficiente para crear la unidad.");
            }
            Console.ResetColor();
        }
        private bool FinDelJuego(Jugador jugador, Jugador enemigo)
        {
            if (jugador.BaseDeJugador.Salud <= 0 || enemigo.BaseDeJugador.Salud <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void GuardarGanador(Jugador jugador)
        {
            var resultado = new ResultadoJuego
            {
                NombreGanador = jugador.Nombre,
                FechaYHora = DateTime.UtcNow.AddHours(-3),
                OroGastado = jugador.OroGastado,
                BaseGanador = jugador.BaseDeJugador
            };
            mandarAJSON(resultado);
        }

        private static void mandarAJSON(ResultadoJuego resultado)
        {
            JSON nuevo = new JSON();
            string nombreArchivo = "JSON/Ganadores.json";

            nuevo.GenerarJSON(resultado, nombreArchivo);
        }
    }
}