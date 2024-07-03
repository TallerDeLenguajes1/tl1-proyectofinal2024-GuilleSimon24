class AtaqueBases
{
    public AtaqueBases()
    {
    }

    public void AtacarBaseJugador(Jugador jugador, Jugador enemigo)
    {
        if (enemigo.Unidades.Count > 0)
        {
            Unidad unidadAtacante = enemigo.Unidades[0];
            jugador.BaseDeJugador.BaseAtacada(unidadAtacante);
            Console.WriteLine("--------------------");
            Console.WriteLine($"{unidadAtacante.Nombre} ha atacado tu base!!");
            if (unidadAtacante.Ataque <= 0 || unidadAtacante.Defensa <= 0)
            {
                enemigo.Unidades.RemoveAt(0);
                Console.WriteLine("--------------------");
                Console.WriteLine($"{unidadAtacante.Nombre} ha sido destruido despues del ataque!");
                Console.WriteLine("Has ganado 5 de oro adicional!");
                enemigo.Oro += 5;
            }
        }
        else
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("El enemigo quiso atacar tu base pero no tenia unidades disponibles. Turno salteado");
        }
    }

    public void AtacarBaseEnemiga(Jugador jugador, Jugador enemigo)
    {
        if (jugador.Unidades.Count > 0)
        {
            Unidad unidadAtacante = jugador.Unidades[0];
            enemigo.BaseDeJugador.BaseAtacada(unidadAtacante);
            Console.WriteLine("--------------------");
            Console.WriteLine($"{unidadAtacante.Nombre} (La unidad {unidadAtacante.Tipo} del jugador) ha atacado la base enemiga!");
            if (enemigo.BaseDeJugador.Salud <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine("La base del enemigo fue destruida!!");
            }
            if (unidadAtacante.Ataque <= 0 || unidadAtacante.Defensa <= 0)
            {
                jugador.Unidades.RemoveAt(0);
                Console.WriteLine("--------------------");
                Console.WriteLine($"{unidadAtacante.Nombre} ha sido destruido después del ataque!");
                Console.WriteLine("El enemigo gano 5 de oro adicional");
                enemigo.Oro += 5;

            }
        }
        else
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("No hay unidades disponibles para atacar.");
        }
    }

}