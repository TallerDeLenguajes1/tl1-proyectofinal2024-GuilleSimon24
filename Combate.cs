namespace Combate
{
    using Unidades;
    using Bases;
    public static class Combate
    {
        public static void Combatir(List<Unidad> unidadesJugador, List<Unidad> unidadesEnemigo, int oroJugador, int oroEnemigo)
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