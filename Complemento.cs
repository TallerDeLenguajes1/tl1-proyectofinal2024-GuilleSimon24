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
        Pantalla UI = new Pantalla();
        if (jugador.BaseDeJugador.Salud > 0)
        {
            UI.GanoElJugador();
            Gameplay.Juego.GuardarGanador(jugador);
        }
        else if (enemigo.BaseDeJugador.Salud > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            UI.GanoElEnemigo();
            Console.ResetColor();
        }
        else
        {
            UI.Empate();
        }
    }

    public static void PeleaLarga(Jugador jugador, Jugador enemigo)
    {
        Pantalla UI = new Pantalla();
        Console.WriteLine("--------------");
        Console.WriteLine("");
        Console.WriteLine("El combate se extendió demasiado");
        Console.WriteLine("");
        Console.WriteLine("El ganador se decidirá en base a las salud de sus bases");
        Console.WriteLine("");

        //MUESTRO BASES FINALES
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Base del jugador: ");
        Complemento.mostrarStats(jugador.BaseDeJugador);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Base del enemigo: ");
        Complemento.mostrarStats(enemigo.BaseDeJugador);
        Console.ResetColor();

        if (jugador.BaseDeJugador.Salud > enemigo.BaseDeJugador.Salud)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            UI.GanoElJugador();
            Gameplay.Juego.GuardarGanador(jugador);
            Console.ResetColor();
        }
        else if (enemigo.BaseDeJugador.Salud > jugador.BaseDeJugador.Salud)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            UI.GanoElEnemigo();
            Console.ResetColor();
        }
        else
        {
            UI.Empate();
        }
    }


}


