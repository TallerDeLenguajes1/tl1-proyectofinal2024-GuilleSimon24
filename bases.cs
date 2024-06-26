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
            return new Base("Base propia", 100, 5, 5);
        }

        public static Base CrearBaseEnemiga()
        {
            return new Base("Base enemiga", 100, 5, 5);
        }

        public void BaseAtacada(Unidad unidadAtacante)
        {
            int daño = unidadAtacante.Ataque - defensa;
            salud -= daño > 0 ? daño : 0;
            unidadAtacante.bajandoStats();
        }
    }
}
