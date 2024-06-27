namespace Gameplay
{
    using Unidades;
    using Bases;
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

        public void IniciarJuego()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Bienvenido al juego!");
            Console.WriteLine("--------------------");

            // Crear unidades iniciales para el jugador y el enemigo
            unidadesJugador = Unidad.CrearListaUnidades();
            unidadesEnemigo = Unidad.CrearListaUnidades();

            // Mostrar unidades iniciales (CONTROL, LUEGO COMENTAR)

            Console.WriteLine("Unidades del Jugador:");
            MostrarListaUnidades(unidadesJugador);

            Console.WriteLine("Unidades del Enemigo:");
            MostrarListaUnidades(unidadesEnemigo);
            Console.WriteLine("--------------------");


            // Comenzar el ciclo de turnos
            while (BaseJugador.Salud > 0 || BaseEnemiga.Salud > 0)
            {
                Console.WriteLine($"\n--- Turno {turno} ---");
                JugarTurno();
                turno++;

                if (turno > 50)
                {
                    Console.WriteLine("--------------");
                    Console.WriteLine("");
                    Console.WriteLine("El combate se extendió demasiado");
                    Console.WriteLine("");
                    Console.WriteLine("El ganador se decidirá en base a las salud de sus bases");
                    Console.WriteLine("");
                    mostrarStats();
                    if (BaseJugador.Salud > BaseEnemiga.Salud)
                    {
                        Console.WriteLine("--------------------");
                        Console.WriteLine("El jugador ha ganado!");
                    }
                    else if (BaseEnemiga.Salud > BaseJugador.Salud)
                    {
                        Console.WriteLine("--------------------");
                        Console.WriteLine("El enemigo ha ganado!");
                    }
                    else
                    {   //Esto viene de una version anterior del programa, preguntar si es necesario
                        Console.WriteLine("--------------------");
                        Console.WriteLine("ES UN EMPATE!");
                    }
                    break;
                }
            }



            // Mostrar resultado del juego
            if (BaseJugador.Salud > 0)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("El jugador ha ganado!");
            }
            else if (BaseEnemiga.Salud > 0)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("El enemigo ha ganado!");
            }
            else
            {   //Esto viene de una version anterior del programa, preguntar si es necesario
                Console.WriteLine("--------------------");
                Console.WriteLine("Ambos han sido derrotados, es un empate!");
            }
        }

        private void JugarTurno()
        {

            //Muestro base y oro de jugadores antes de pelear
            mostrarStats();
            Console.WriteLine($"Oro del Jugador: {oroJugador}");
            Console.WriteLine($"Oro del Enemigo: {oroEnemigo}");

            Console.WriteLine("");
            Console.WriteLine("Unidadesd del jugador:");
            MostrarListaUnidades(unidadesJugador);
            Console.WriteLine("Unidades del enemigo: ");
            MostrarListaUnidades(unidadesEnemigo);


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
                        AtacarBaseEnemiga();
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
                Console.WriteLine($"Unidad {unidad.Nombre} creada.");
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
                Console.WriteLine($"El enemigo ha creado una unidad {unidadEnemiga.Nombre}.");
            }
            else
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("El enemigo no tiene suficiente oro para crear una unidad. Turno salteado");
            }

            // Ataque automático a la base del jugador si no hay unidades del jugador
            if (unidadesJugador.Count == 0 && unidadesEnemigo.Count > 0 && turno != 1)
            {
                AtacarBaseJugador();
            }
        }


        //Si el jugador contrario no tiene unidades en el campo de batalla se permite atacar a la base enemiga
        private void AtacarBaseEnemiga()
        {
            if (unidadesJugador.Count > 0)
            {
                Unidad unidadAtacante = unidadesJugador[0];
                BaseEnemiga.BaseAtacada(unidadAtacante);
                Console.WriteLine("--------------------");
                Console.WriteLine($"{unidadAtacante.Nombre} (La unidad {unidadAtacante.Tipo} del jugador) ha atacado la base enemiga!");
                if (BaseEnemiga.Salud <= 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("La base del enemgio fue destruida!!");
                }
                if (unidadAtacante.Ataque <= 0 || unidadAtacante.Defensa <= 0)
                {
                    unidadesJugador.RemoveAt(0);
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"{unidadAtacante.Nombre} ha sido destruido después del ataque!");
                    Console.WriteLine("El enemigo gano 5 de oro adicional");
                    oroEnemigo += 5;

                }
            }
            else
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("No hay unidades disponibles para atacar.");
            }
        }

        private void AtacarBaseJugador()
        {
            if (unidadesEnemigo.Count > 0)
            {
                Unidad unidadAtacante = unidadesEnemigo[0];
                BaseJugador.BaseAtacada(unidadAtacante);
                Console.WriteLine("--------------------");
                Console.WriteLine($"{unidadAtacante.Nombre} ha atacado tu base!!");
                if (unidadAtacante.Ataque <= 0 || unidadAtacante.Defensa <= 0)
                {
                    unidadesEnemigo.RemoveAt(0);
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"{unidadAtacante.Nombre} ha sido destruido despues del ataque!");
                    Console.WriteLine("Has ganado 5 de oro adicional!");
                    oroEnemigo += 5;
                }
            }
            else
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("El enemigo quiso atacar tu base pero no tenia unidades disponibles. Turno salteado");
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
                Console.WriteLine($"Combate entre {unidadJugador.Nombre} (Jugador) y {unidadEnemigo.Nombre} (Enemigo)");

                // Realizar combate
                unidadEnemigo.Defensa -= unidadJugador.Ataque;
                unidadJugador.Defensa -= unidadEnemigo.Ataque;

                // Verificar si alguna unidad ha sido derrotada
                if (unidadJugador.Defensa <= 0)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"{unidadJugador.Nombre} (Unidad {unidadJugador.Tipo} del jugador) ha sido derrotado!");
                    Console.WriteLine("El enemigo gano 5 de oro adicional!");
                    oroEnemigo += 5;
                    Console.WriteLine("--------------------");
                    unidadesJugador.RemoveAt(0);
                }

                if (unidadEnemigo.Defensa <= 0)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"{unidadEnemigo.Nombre} (Unidad {unidadEnemigo.Tipo} del enemigo) ha sido derrotado!");
                    Console.WriteLine("Has ganado 5 de oro adicional!");
                    oroEnemigo += 5;
                    Console.WriteLine("--------------------");
                    unidadesEnemigo.RemoveAt(0);
                }
            }
        }


        //Funcion para mostrar la lista de las unidades

        public void MostrarListaUnidades(List<Unidad> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else
            {
                foreach (Unidad unidad in lista)
                {
                    Console.WriteLine(unidad);
                }
            }
        }


        public void mostrarStats()
        {
            Console.WriteLine("--------------");
            Console.WriteLine($"Base del jugador: {BaseJugador}");
            Console.WriteLine("--------------");
            Console.WriteLine($"Base del enemigo: {BaseEnemiga}");
            Console.WriteLine("--------------");
        }




    }
}