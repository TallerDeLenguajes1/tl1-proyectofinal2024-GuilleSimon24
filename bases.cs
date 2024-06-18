namespace Bases
{   using Personajes;
    public class Base{

        private string nombre;
        private int salud;
        private int defensa;
        private int ataque;
        private int oro;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Salud{get => salud; set => salud = value;}
        public int Defensa{get => defensa; set => defensa = value;}
        public int Ataque{get => ataque; set => ataque = value;}
        public int Oro{get => oro; set => oro = value;}

        public Base(){}

        public Base(string nombre, int salud, int defensa, int ataque, int oro){
            this.nombre = nombre;
            this.salud = salud;
            this.defensa = defensa;
            this.ataque = ataque;
            this.oro = 20;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Ataque: {Ataque}, Defensa: {Defensa}, Oro: {Oro}";
        }

        public Base CrearBase(){
            Base objeto = new Base("Base propia", 40, 3, 2, 20);
            return objeto;
        }
        public Base CrearBaseEnemiga(){
            Base objeto = new Base("Base enemiga", 40, 3, 2, 20);
            return objeto;
        }

        public void BaseAtacada(Creador unidad1, Base atacada){
            atacada.salud -= (unidad1.Ataque - defensa);
            unidad1.bajandoStats();
        }

        public void SubirOro(Base base1){
            base1.oro +=5;
        }

        


        

        //Finjo demencia como que la base mia esta en posicion 0, y la del enemigo en posicion 15

    }
}