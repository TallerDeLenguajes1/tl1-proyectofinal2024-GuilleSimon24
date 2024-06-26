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

            //Mostrar bases iniciales

            Console.WriteLine("Base del jugador:");
            Console.WriteLine(BaseJugador);
            Console.WriteLine("--------------------");

            Console.WriteLine("Base del enemigo:");
            Console.WriteLine(BaseEnemiga);
            Console.WriteLine("--------------------");


            //Juego un turno "fantasma" para no tener que 
            Console.WriteLine("Crea tu primera unidad: ");
            TurnoJugador();
            Console.WriteLine("El enemigo crea su primera unidad: ");
            TurnoEnemigo();

            // Comenzar el ciclo de turnos
            while (unidadesJugador.Count > 0 && unidadesEnemigo.Count > 0)
            {
                Console.WriteLine($"\n--- Turno {turno} ---");
                JugarTurno();
                turno++;
            }

            // Mostrar resultado del juego
            if (BaseJugador.Salud > 0)
            {
                Console.WriteLine("El jugador ha ganado!");
            }
            else if (BaseEnemiga.Salud > 0)
            {
                Console.WriteLine("El enemigo ha ganado!");
            }
            else
            {
                Console.WriteLine("Ambos han sido derrotados, es un empate!");
            }
        }

        private void JugarTurno()
        {
            // Oro pasivo por turno
            oroJugador += 5;
            oroEnemigo += 5;

            Console.WriteLine($"Oro del Jugador: {oroJugador}");
            Console.WriteLine($"Oro del Enemigo: {oroEnemigo}");

            TurnoJugador();

            TurnoEnemigo();

            // Realizar combate
            Combatir();
        }

        private void TurnoJugador()
        {
            bool turnoValido = false;

            while (!turnoValido)
            {
                Console.WriteLine("Turno del Jugador:");
                Console.WriteLine("1. Crear unidad normal (10 de oro)");
                Console.WriteLine("2. Crear unidad tanque (15 de oro)");
                Console.WriteLine("3. Crear unidad de daño (20 de oro)");
                Console.WriteLine("4. Atacar la base enemiga");
                Console.WriteLine("5. Saltar turno");

                string opCadena = Console.ReadLine();
                int opcion;
                bool anda = int.TryParse(opCadena, out opcion);
                if (anda)
                {

                    if (true)
                    {
                        
                    }
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
                        case 4:
                            if (unidadesEnemigo.Count == 0)
                            {
                                AtacarBaseEnemiga();
                                turnoValido = true;
                            }
                            else
                            {
                                Console.WriteLine("No puedes atacar la base enemiga mientras haya unidades enemigas en el campo de batalla.");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Turno saltado.");
                            turnoValido = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor, elija una opción válida.");
                            break;
                    }
                }
            }
        }

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
        private void TurnoEnemigo()
        {
            Console.WriteLine("Turno del Enemigo:");
            // Lógica simple para el enemigo, crea unidades aleatoriamente si tiene suficiente oro
            int opcion = new Random().Next(1, 4);
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
            }

            if (unidadEnemiga != null && oroEnemigo >= unidadEnemiga.Costo)
            {
                unidadesEnemigo.Add(unidadEnemiga);
                oroEnemigo -= unidadEnemiga.Costo;
                Console.WriteLine($"El enemigo ha creado una unidad {unidadEnemiga.Nombre}.");
            }
            else
            {
                Console.WriteLine("El enemigo no tiene suficiente oro para crear una unidad. Turno salteado");
            }

            // Ataque automático a la base del jugador si no hay unidades del jugador
            if (unidadesJugador.Count == 0 && unidadesEnemigo.Count > 0)
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
                Console.WriteLine($"{unidadAtacante.Nombre} ha atacado la base enemiga!");
                if (unidadAtacante.Ataque <= 0 || unidadAtacante.Defensa <= 0)
                {
                    unidadesJugador.RemoveAt(0);
                    Console.WriteLine($"{unidadAtacante.Nombre} ha sido destruido después del ataque!");
                }
            }
            else
            {
                Console.WriteLine("No hay unidades disponibles para atacar.");
            }
        }

        private void AtacarBaseJugador()
        {
            if (unidadesEnemigo.Count > 0)
            {
                Unidad unidadAtacante = unidadesEnemigo[0];
                BaseJugador.BaseAtacada(unidadAtacante);
                Console.WriteLine($"{unidadAtacante.Nombre} ha atacado tu base!!");
                if (unidadAtacante.Ataque <= 0 || unidadAtacante.Defensa <= 0)
                {
                    unidadesEnemigo.RemoveAt(0);
                    Console.WriteLine($"{unidadAtacante.Nombre} ha sido destruido despues del ataque!");
                }
            }
            else
            {
                Console.WriteLine("El enemigo quiso atacar tu base pero no tenia unidades disponibles. Turno salteado");
            }
        }

        private void Combatir()
        {
            if (unidadesJugador.Count > 0 && unidadesEnemigo.Count > 0)
            {
                // Seleccionar unidades para combatir
                Unidad unidadJugador = unidadesJugador[0];
                Unidad unidadEnemigo = unidadesEnemigo[0];

                Console.WriteLine($"Combate entre {unidadJugador.Nombre} (Jugador) y {unidadEnemigo.Nombre} (Enemigo)");

                // Realizar combate
                unidadEnemigo.Defensa -= unidadJugador.Ataque;
                unidadJugador.Defensa -= unidadEnemigo.Ataque;

                // Verificar si alguna unidad ha sido derrotada
                if (unidadJugador.Defensa <= 0)
                {
                    Console.WriteLine($"{unidadJugador.Nombre} ha sido derrotado!");
                    unidadesJugador.RemoveAt(0);
                }

                if (unidadEnemigo.Defensa <= 0)
                {
                    Console.WriteLine($"{unidadEnemigo.Nombre} ha sido derrotado!");
                    unidadesEnemigo.RemoveAt(0);
                }
            }
        }

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





    }
}