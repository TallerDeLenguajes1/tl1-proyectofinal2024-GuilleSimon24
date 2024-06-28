namespace Gameplay
{
    using Unidades;
    using Bases;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Complemento;
    using Combate;
    using Pantalla;

    class Juego
    {
        private List<Unidad> unidadesJugador;
        private List<Unidad> unidadesEnemigo;
        private Base BaseJugador;
        private Base BaseEnemiga;
        private int oroJugador;
        private int oroEnemigo;
        private int turno;

        public Juego()
        {
            unidadesJugador = new List<Unidad>();
            unidadesEnemigo = new List<Unidad>();
            BaseJugador = Base.CrearBase();
            BaseEnemiga = Base.CrearBaseEnemiga();
            oroJugador = 50;
            oroEnemigo = 50;
            turno = 1;
        }

        public async Task IniciarJuego()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Bienvenido al juego!");
            Console.WriteLine("--------------------");

            await Unidad.TraerNombreAPI();  //Cargo en la lista los nombres traidos de la API

            unidadesJugador = Unidad.CrearListaUnidades();
            unidadesEnemigo = Unidad.CrearListaUnidades();
            // Comenzar el ciclo de turnos
            while (BaseJugador.Salud > 0 || BaseEnemiga.Salud > 0)
            {
                Console.WriteLine($"\n--- Turno {turno} ---");
                JugarTurno();
                turno++;

                if (turno > 50)     //Por si la pelea se extiende demasiado
                {
                    Complemento.PeleaLarga(BaseJugador, BaseEnemiga);
                    break;
                }
            }

            //Resultado del juego
            Complemento.Resultado(BaseJugador, BaseEnemiga);

        }

        private void JugarTurno()
        {

            //Muestro base y oro de jugadores antes de pelear
            Console.WriteLine("Base del jugador: ");
            Complemento.mostrarStats(BaseJugador);
            Console.WriteLine("Base del enemigo: ");
            Complemento.mostrarStats(BaseEnemiga);


            //Muestro todos los turnos el oro de ambos
            //CONSULTAR SI SOLO MUESTRO EL MIO. LA IDEA ES QUE HAYA QUE CALCULAR SEGUN LO QUE HAGA EL OTRO
            Console.WriteLine($"Oro del Jugador: {oroJugador}");
            Console.WriteLine($"Oro del Enemigo: {oroEnemigo}");
            Console.WriteLine("");
            Console.WriteLine("Unidades del jugador:");
            Complemento.MostrarListaUnidades(unidadesJugador);
            Console.WriteLine("Unidades del enemigo: ");
            Complemento.MostrarListaUnidades(unidadesEnemigo);

            TurnoJugador();
            TurnoEnemigo();
            oroJugador += 5;
            oroEnemigo += 5;
            // Realizar combate
            Combate.Combatir(unidadesJugador, unidadesEnemigo, oroJugador, oroEnemigo);
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

                string opCadena = Console.ReadLine();
                int opcion;
                bool anda = int.TryParse(opCadena, out opcion);
                if (anda)
                {
                    switch (opcion)
                    {
                        case 1:
                            Unidad.CrearUnidadJugador(Unidad.CrearUnidadNormal(), oroJugador, unidadesJugador);
                            turnoValido = true;
                            break;
                        case 2:
                            Unidad.CrearUnidadJugador(Unidad.CrearUnidadTanque(), oroJugador, unidadesJugador);
                            turnoValido = true;
                            break;
                        case 3:
                            Unidad.CrearUnidadJugador(Unidad.CrearUnidadDaño(), oroJugador, unidadesJugador);
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
                    if (unidadesEnemigo.Count == 0 && unidadesJugador.Count > 0 && turno != 1)
                    {
                        Base.AtacarBaseEnemiga(unidadesEnemigo, oroEnemigo, BaseEnemiga);
                    }
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
                    unidadEnemiga = Unidad.CrearUnidadNormal();
                    break;
                case 2:
                    unidadEnemiga = Unidad.CrearUnidadTanque();
                    break;
                case 3:
                    unidadEnemiga = Unidad.CrearUnidadDaño();
                    break;
                case 4:
                    Console.WriteLine("El enemigo ha salteado su turno");
                    break;
            }

            if (unidadEnemiga != null && oroEnemigo >= unidadEnemiga.Costo)
            {
                unidadesEnemigo.Add(unidadEnemiga);
                oroEnemigo -= unidadEnemiga.Costo;
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
            // Ataque automático a la base del jugador si no hay unidades del jugador
            if (unidadesJugador.Count == 0 && unidadesEnemigo.Count > 0 && turno != 1)
            {
                Base.AtacarBaseJugador(unidadesEnemigo, oroJugador, BaseJugador);
            }
        }
    }
}