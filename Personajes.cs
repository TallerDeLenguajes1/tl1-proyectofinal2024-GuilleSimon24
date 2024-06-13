namespace Personajes{

    public class Creador{


        private string nombre;
        private int ataque;
        private int defensa;

        private int Posicion;

        public enum TipoUnidad{
            comun,
            tanque,
            daño
        }

        public string Nombre{get => nombre; set => nombre = value;}

        public int Ataque{get => ataque; set => ataque = value;}

        public int Defensa{get => defensa; set => defensa = value;}

        public TipoUnidad Tipo{get => Tipo; set => Tipo = value;}

        public int posicion{get => posicion; set => posicion = value;}
        
        public Creador(string nombre, int ataque, int defensa, TipoUnidad tipo) { 
            this.nombre = nombre;
            this.ataque = ataque;
            this.defensa = defensa;
            this.Tipo = tipo;
            Posicion = 0;
            
        }



        public void bajandoStats(){
            Ataque = Ataque/2;
            Defensa = Defensa/2;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Ataque: {Ataque}, Defensa: {Defensa}, Tipo: {Tipo}";
        }
        //Queda pendiente encontrar una relacion para cumplir con las ideas de combates sucesivos de una unidad

        //Consultar si se puede
        public Creador CrearUnidadNormal(){
           Creador objeto = new Creador("Normal", 4, 6, TipoUnidad.Normal);
           return objeto;
        }

        public Creador CrearUnidadTanque(){
            Creador objeto = new Creador("Tanque", 4, 10, TipoUnidad.Tanque);
            return objeto;
        }

        public Creador CrearUnidadDaño(){
            Creador objeto = new Creador("Daño", 6, 4, TipoUnidad.Daño);
            return objeto;
        }



        
    }

}