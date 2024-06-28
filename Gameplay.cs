namespace Gameplay
{
    using Unidades;
    using Bases;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Complemento;
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
            //Declaro las listas para guardar las unidades generadas
            unidadesJugador = new List<Unidad>();
            unidadesEnemigo = new List<Unidad>();
            //Creo las bases de los jugadores
            BaseJugador = Base.CrearBase();
            BaseEnemiga = Base.CrearBaseEnemiga();
            //Le doy oro inicial a cada jugador e inicializo los turnos en 1
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

            // Crear listas de unidades para el jugador y el enemigo
            unidadesJugador = Unidad.CrearListaUnidades();
            unidadesEnemigo = Unidad.CrearListaUnidades();

            // Mostrar unidades iniciales (CONTROL, LUEGO COMENTAR)

            Console.WriteLine("Unidades del Jugador:");
            Complemento.MostrarListaUnidades(unidadesJugador);

            Console.WriteLine("Unidades del Enemigo:");
            Complemento.MostrarListaUnidades(unidadesEnemigo);
            Console.WriteLine("--------------------");


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

            // Mostrar resultado del juego
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

            // Oro pasivo por turno
            oroJugador += 5;
            oroEnemigo += 5;

            // Realizar combate
            Combatir();


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
                            CrearUnidadJugador(Unidad.CrearUnidadNormal());
                            turnoValido = true;
                            break;
                        case 2:
                            CrearUnidadJugador(Unidad.CrearUnidadTanque());
                            turnoValido = true;
                            break;
                        case 3:
                            CrearUnidadJugador(Unidad.CrearUnidadDaño());
                            turnoValido = true;
                            break;
                        //SUJETO A REVISION DEL PROFE
                        /*Este modulo de codigo era para que el jugador gaste un turno atacando a la base enemiga
                        Mientras que el enemigo hacia un autoatack a la base propia
                        Lo que desbalanceaba mucho el juego teniendo en cuenta que el enemigo podia hacer 2 jugadas
                        En el mismo turno si el jugador no tenia unidades en el campo */
                        /*case 4:
                            if (unidadesEnemigo.Count == 0)
                            {
                                AtacarBaseEnemiga();
                                turnoValido = true;
                            }
                            else    //Por las dudas aún asi insista en atacar la base enemiga sin cumplir con las condiciones
                            {
                                Console.WriteLine("No puedes atacar la base enemiga mientras haya unidades enemigas en el campo de batalla.");
                            }
                            break;*/ //Elimine esto por que estaba muy desbalanceado el juego
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


        //Funcion para crear la unidad jugador y listarla en la lista de unidades del jugador
        private void CrearUnidadJugador(Unidad unidad)
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

        //Combate entre las primeras unidades de la lista
        private void Combatir()
        {
            if (unidadesJugador.Count > 0 && unidadesEnemigo.Count > 0)
            {
                // Seleccionar unidades para combatir
                Unidad unidadJugador = unidadesJugador[0];
                Unidad unidadEnemigo = unidadesEnemigo[0];
                Console.WriteLine("");
                Console.WriteLine("-----------------------");
                Console.WriteLine($"Combate entre:");
                Console.WriteLine($"{unidadJugador.Nombre} (Unidad tipo {unidadJugador.Tipo} del JUGADOR)");
                Console.WriteLine($"        VS           ");
                Console.WriteLine($"{unidadEnemigo.Nombre} (Unidad tipo {unidadEnemigo.Tipo} del ENEMIGO)");

                // Realizar combate
                unidadEnemigo.Defensa -= unidadJugador.Ataque;
                unidadJugador.Defensa -= unidadEnemigo.Ataque;

                // Verificar si alguna unidad ha sido derrotada
                if (unidadJugador.Defensa <= 0)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"{unidadJugador.Nombre} (Unidad {unidadJugador.Tipo} del jugador) ha sido derrotado!");
                    Console.WriteLine("El enemigo gano 7 de oro adicional!");
                    oroEnemigo += 7;
                    Console.WriteLine("--------------------");
                    unidadesJugador.RemoveAt(0);
                }

                if (unidadEnemigo.Defensa <= 0)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"{unidadEnemigo.Nombre} (Unidad {unidadEnemigo.Tipo} del enemigo) ha sido derrotado!");
                    Console.WriteLine("Has ganado 7 de oro adicional!");
                    oroEnemigo += 7;
                    Console.WriteLine("--------------------");
                    unidadesEnemigo.RemoveAt(0);
                }
            }
        }
    }
}