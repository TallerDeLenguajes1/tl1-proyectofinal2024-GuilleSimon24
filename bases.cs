namespace Bases
{   using Personajes;
    public class Base{

        private string nombre;
        private int salud;
        private int defensa;
        private int ataque;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Salud{get => salud; set => salud = value;}
        public int Defensa{get => defensa; set => defensa = value;}
        public int Ataque{get => ataque; set => ataque = value;}

        public Base(){}

        public Base(string nombre, int salud, int defensa, int ataque){
            this.nombre = nombre;
            this.salud = salud;
            this.defensa = defensa;
            this.ataque = ataque;
        }

        public Base CrearBase(){
            Base objeto = new Base("Base prueba", 40, 3, 2);
            return objeto;
        }

        public void baseAtacada(Creador unidad1){
            salud -= (unidad1.Ataque - defensa);
            unidad1.bajandoStats();
        }
    }
}