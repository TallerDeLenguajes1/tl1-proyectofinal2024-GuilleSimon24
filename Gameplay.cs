namespace Gameplay
{   
    using Unidades;
    class Gameplay
    {
         private List<Unidad> unidadesJugador;
        private List<Unidad> unidadesEnemigo;

        public Gameplay()
        {
            unidadesJugador = new List<Unidad>();
            unidadesEnemigo = new List<Unidad>();
        }

        public void IniciarJuego()
        {
            Console.WriteLine("Bienvenido al juego!");

            // Crear unidades para el jugador y el enemigo
            unidadesJugador = Unidad.CrearListaUnidades();
            unidadesEnemigo = Unidad.CrearListaUnidades();

            // Mostrar unidades iniciales
            Console.WriteLine("Unidades del Jugador:");
            MostrarListaUnidades(unidadesJugador);

            Console.WriteLine("Unidades del Enemigo:");
            MostrarListaUnidades(unidadesEnemigo);

            // Comenzar el combate
            Combatir();
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

    }
}