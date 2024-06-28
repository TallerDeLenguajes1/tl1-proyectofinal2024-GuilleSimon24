/*namespace Turnos
{   
    using Unidades;
    using Gameplay;
    public static class Turnos
    {   
        
    }public static void TurnoJugador()
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
                            break; //Elimine esto por que estaba muy desbalanceado el juego
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
}*/