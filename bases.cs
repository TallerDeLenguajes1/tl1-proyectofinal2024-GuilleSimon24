namespace Bases
{   using Unidades;


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

        public Base(string nombre, int salud, int defensa, int ataque, int oro){
            this.nombre = nombre;
            this.salud = salud;
            this.defensa = defensa;
            this.ataque = ataque;
        
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Ataque: {Ataque}, Defensa: {Defensa}";
        }

        public Base CrearBase(){
            Base objeto = new Base("Base propia", 40, 3, 2, 20);
            return objeto;
        }
        public Base CrearBaseEnemiga(){
            Base objeto = new Base("Base enemiga", 40, 3, 2, 20);
            return objeto;
        }

        public void BaseAtacada(Unidad unidad1, Base atacada){
            atacada.salud -= (unidad1.Ataque - defensa);
            unidad1.bajandoStats();
        }

        
        


        

        //Finjo demencia como que la base mia esta en posicion 0, y la del enemigo en posicion 15

    }
}