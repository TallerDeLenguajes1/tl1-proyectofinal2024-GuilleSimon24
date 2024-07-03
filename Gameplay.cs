namespace Gameplay
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Pantalla;

    class Juego
    {
        FabricaDeUnidades fabricaDeUnidades;

        AtaqueBases ataqueBases;

        private Jugador jugador;
        private Jugador enemigo;
        private int turno;
        private Combate combate;

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
        }

        public async Task IniciarJuego()
        {   

            Console.WriteLine("--------------------");
            Console.WriteLine("Bienvenido al juego!");
            Console.WriteLine("--------------------");

            await IniciarFabricaDeUnidades();
            IniciarBases();


            jugador.Unidades = CrearListaUnidades();
            enemigo.Unidades = CrearListaUnidades();
            jugador.HistorialUnidades = CrearListaUnidades();
            // Comenzar el ciclo de turnos
            while (!FinDelJuego(jugador, enemigo))
            {
                Console.WriteLine($"\n--- Turno {turno} ---");
                JugarTurno();
                turno++;

                if (turno > 50)     //Por si la pelea se extiende demasiado
                {
                    Complemento.PeleaLarga(jugador.BaseDeJugador, enemigo.BaseDeJugador);
                    break;
                }
            }

            //Resultado del juego
            Complemento.Resultado(jugador.BaseDeJugador, enemigo.BaseDeJugador);

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
            Console.WriteLine("Base del jugador: ");
            Complemento.mostrarStats(jugador.BaseDeJugador);
            Console.WriteLine("Base del enemigo: ");
            Complemento.mostrarStats(enemigo.BaseDeJugador);


            //Muestro todos los turnos el oro de ambos
            //CONSULTAR SI SOLO MUESTRO EL MIO. LA IDEA ES QUE HAYA QUE CALCULAR SEGUN LO QUE HAGA EL OTRO
            Console.WriteLine($"Oro del Jugador: {jugador.Oro}");
            Console.WriteLine($"Oro del Enemigo: {enemigo.Oro}");
            Console.WriteLine("");
            Console.WriteLine("Unidades del jugador:");
            Complemento.MostrarListaUnidades(jugador.Unidades);
            Console.WriteLine("Unidades del enemigo: ");
            Complemento.MostrarListaUnidades(enemigo.Unidades);

            TurnoJugador();
            TurnoEnemigo();
            jugador.Oro += 5;
            enemigo.Oro += 5;
            // Realizar combate

            combate.Combatir(jugador, enemigo);
        }

        private void TurnoJugador()
        {
            bool turnoValido = false;
            while (!turnoValido)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Turno del Jugador:");
                Console.WriteLine("1. Crear unidad normal (10 de oro)");
                Console.WriteLine("2. Crear unidad tanque (15 de oro)");
                Console.WriteLine("3. Crear unidad de daño (20 de oro)");
                Console.WriteLine("4. Saltar turno");
                Console.WriteLine("--------------------");

                int opcion = 0;
                bool anda = false;
                do
                {
                    string opCadena = Console.ReadLine();
                    anda = int.TryParse(opCadena, out opcion);
                } while (anda == false || opcion < 0 || opcion > 4);

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
                // Ataque automático a la base del Enemigo si no hay unidades en el campo
                if (enemigo.Unidades.Count == 0 && jugador.Unidades.Count > 0 && turno != 1)
                {
                    ataqueBases.AtacarBaseEnemiga(jugador, enemigo);
                }

            }
        }
        //Turno aleatorio para el enemigo
        private void TurnoEnemigo()
        {
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
                }
            }

        }

        private List<Unidad> CrearListaUnidades()
        {
            var unidades = new List<Unidad>();

            return unidades;
        }
        private void CrearUnidadJugador(Unidad unidad, Jugador jugador)
        {
            if (jugador.Oro >= unidad.Costo)
            {
                jugador.Unidades.Add(unidad);
                jugador.Oro -= unidad.Costo;
                Console.WriteLine($"Unidad {unidad.Tipo} creada. Nombre: {unidad.Nombre}.");

                Unidad clon = new Unidad();
                clon = unidad;
                jugador.OroGastado += unidad.Costo;
                jugador.HistorialUnidades.Add(clon);

            }
            else
            {
                Console.WriteLine("Oro insuficiente para crear la unidad.");
            }
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


    }
}