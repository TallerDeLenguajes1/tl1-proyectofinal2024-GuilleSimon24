namespace Bases
{
    using Unidades;

    public class Base
    {
        private string nombre;
        private int salud;
        private int defensa;
        private int ataque;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        public int Ataque { get => ataque; set => ataque = value; }

        public Base() { }

        public Base(string nombre, int salud, int defensa, int ataque)
        {
            this.nombre = nombre;
            this.salud = salud;
            this.defensa = defensa;
            this.ataque = ataque;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Salud: {Salud}, Defensa: {Defensa}, Ataque: {Ataque}";
        }

        public static Base CrearBase()
        {
            return new Base("Base propia", 50, 2, 5);      
        }

        public static Base CrearBaseEnemiga()
        {
            return new Base("Base enemiga", 50, 2, 5);
        }

        public void BaseAtacada(Unidad unidadAtacante)
        {
            int daño = unidadAtacante.Ataque - defensa;
            salud -= daño > 0 ? daño : 0;
            unidadAtacante.bajandoStats();
        }

        public static void AtacarBaseJugador(List<Unidad> unidadesEnemigo, int oroEnemigo, Base BaseJugador)
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

        public static void AtacarBaseEnemiga(List<Unidad> unidadesJugador, int oroEnemigo, Base BaseEnemiga)
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
    }
}
