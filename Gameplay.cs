namespace Gameplay
{
    using Unidades;
    class Juego
    {
        private List<Unidad> unidadesJugador;
        private List<Unidad> unidadesEnemigo;
        private int oroJugador;
        private int oroEnemigo;
        private int turno;

        public Juego()
        {
            unidadesJugador = new List<Unidad>();
            unidadesEnemigo = new List<Unidad>();
            oroJugador = 50; // Oro inicial del jugador
            oroEnemigo = 50; // Oro inicial del enemigo
            turno = 1;
        }

        public void IniciarJuego()
        {
            Console.WriteLine("Bienvenido al juego!");

            // Crear unidades iniciales para el jugador y el enemigo
            unidadesJugador = Unidad.CrearListaUnidades();
            unidadesEnemigo = Unidad.CrearListaUnidades();

            // Mostrar unidades iniciales
            
            Console.WriteLine("Unidades del Jugador:");
            MostrarListaUnidades(unidadesJugador);

            Console.WriteLine("Unidades del Enemigo:");
            MostrarListaUnidades(unidadesEnemigo);


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
            if (unidadesEnemigo.Count == 0)
            {
                Console.WriteLine("El jugador ha ganado!");
            }
            else if (unidadesJugador.Count == 0)
            {
                Console.WriteLine("El enemigo ha ganado!");
            }
            else
            {
                Console.WriteLine("Ambos han sido derrotados, es un empate!");
            }
        }

        public void Combatir()
        {
            
            
            while (unidadesJugador.Count > 0 && unidadesEnemigo.Count > 0)
            {
                // Seleccionar unidades para combatir
                Unidad unidadJugador = unidadesJugador[0];
                Unidad unidadEnemigo = unidadesEnemigo[0];

                Console.WriteLine($"Combate entre {unidadJugador.Nombre} (Jugador) y {unidadEnemigo.Nombre} (Enemigo)");

                // Realizar combate
                unidadEnemigo.Defensa -= unidadJugador.Ataque;
                unidadJugador.Defensa -= unidadEnemigo.Ataque;

                // Verifico si alguna unidad ha sido derrotada
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

            // Mostrar resultado del combate
            if (unidadesJugador.Count > 0)
            {
                Console.WriteLine("El jugador ha ganado!");
            }
            else if (unidadesEnemigo.Count > 0)
            {
                Console.WriteLine("El enemigo ha ganado!");
            }
            else
            {
                Console.WriteLine("Ambos han sido derrotados, es un empate!");
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

        private void TurnoJugador()
        {
            Console.WriteLine("Turno del Jugador:");
            Console.WriteLine("1. Crear unidad normal (10 de oro)");
            Console.WriteLine("2. Crear unidad tanque (15 de oro)");
            Console.WriteLine("3. Crear unidad de daño (20 de oro)");
            Console.WriteLine("4. Saltar turno");

            
            int opcion;
            bool anda = int.TryParse(Console.ReadLine(), out opcion);

            if (anda && opcion < 5 && opcion > 0)
            {
                switch (opcion)
                {
                    case 1:
                        CrearUnidadJugador(Unidad.CrearUnidadNormal());
                        break;
                    case 2:
                        CrearUnidadJugador(Unidad.CrearUnidadTanque());
                        break;
                    case 3:
                        CrearUnidadJugador(Unidad.CrearUnidadDaño());
                        break;
                    case 4:
                        Console.WriteLine("Turno salteado.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opcion invalida. Turno salteado");
            }


        }

        private void TurnoEnemigo()
        {
            Console.WriteLine("Turno del Enemigo:");
            // Crea unidades aleatoriamente si tiene suficiente oro
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
                Console.WriteLine("El enemigo no tiene suficiente oro para crear una unidad.");
            }
        }

    }
}