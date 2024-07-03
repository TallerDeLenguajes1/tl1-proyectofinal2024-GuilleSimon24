public class Combate
{
    public Combate()
    {
    }

    public void Combatir(Jugador jugador, Jugador enemigo)
    {
        if (jugador.Unidades.Count > 0 && enemigo.Unidades.Count > 0)
        {
            // Seleccionar unidades para combatir
            Unidad unidadJugador = jugador.Unidades[0];
            Unidad unidadEnemigo = enemigo.Unidades[0];
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
                enemigo.Oro += 7;
                Console.WriteLine("--------------------");
                jugador.Unidades.RemoveAt(0);
            }

            if (unidadEnemigo.Defensa <= 0)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine($"{unidadEnemigo.Nombre} (Unidad {unidadEnemigo.Tipo} del enemigo) ha sido derrotado!");
                Console.WriteLine("Has ganado 7 de oro adicional!");
                jugador.Oro += 7;
                Console.WriteLine("--------------------");
                enemigo.Unidades.RemoveAt(0);
            }
        }
    }
}
