public static class Complemento
{

    public static void MostrarListaUnidades(List<Unidad> lista)
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

    //Funcion para mostrar las stats generales
    public static void mostrarStats(Base Base)
    {
        Console.WriteLine("--------------");
        Console.WriteLine($"Base: {Base}");
        Console.WriteLine("--------------");
    }

    public static void Resultado(Jugador jugador, Jugador enemigo)
    {
        if (jugador.BaseDeJugador.Salud > 0)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("El jugador ha ganado!");
            Gameplay.Juego.GuardarGanador(jugador);
        }
        else if (enemigo.BaseDeJugador.Salud > 0)
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

    public static void PeleaLarga(Jugador jugador, Jugador enemigo)
    {
        Console.WriteLine("--------------");
        Console.WriteLine("");
        Console.WriteLine("El combate se extendió demasiado");
        Console.WriteLine("");
        Console.WriteLine("El ganador se decidirá en base a las salud de sus bases");
        Console.WriteLine("");

        //MUESTRO BASES FINALES
        Console.WriteLine("Base del jugador: ");
        Complemento.mostrarStats(jugador.BaseDeJugador);
        Console.WriteLine("Base del enemigo: ");
        Complemento.mostrarStats(enemigo.BaseDeJugador);

        if (jugador.BaseDeJugador.Salud > enemigo.BaseDeJugador.Salud)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("El jugador ha ganado!");
            Gameplay.Juego.GuardarGanador(jugador);

        }
        else if (enemigo.BaseDeJugador.Salud > jugador.BaseDeJugador.Salud)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("El enemigo ha ganado!");
        }
        else
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("ES UN EMPATE!");
        }
    }

    
}


