namespace Personajes{

    public class Creador{


        private string nombre;
        private int ataque;
        private int defensa;
        private int posicion;

        private TipoUnidad tipo;

        public enum TipoUnidad{
            comun,
            tanque,
            daño
        }

        public string Nombre{get => nombre; set => nombre = value;}

        public int Ataque{get => ataque; set => ataque = value;}

        public int Defensa{get => defensa; set => defensa = value;}

        public TipoUnidad Tipo{get => tipo; set => tipo = value;}

        public int Posicion{get => posicion; set => posicion = value;}
        
        public Creador(string nombre, int ataque, int defensa, TipoUnidad tipo) { 
            this.nombre = nombre;
            this.ataque = ataque;
            this.defensa = defensa;
            this.tipo = tipo;
            Posicion = 0;
            
        }

        public Creador(){

        }

        public void bajandoStats(){
            Ataque = Ataque/2;
            Defensa = Defensa/2;
            if (Ataque == 0)
            {
                Ataque = 1;
            }
        }

        public void avanzarPosicion(){
            posicion += 1;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Ataque: {Ataque}, Defensa: {Defensa}, Tipo: {Tipo}";
        }
        //Queda pendiente encontrar una relacion para cumplir con las ideas de combates sucesivos de una unidad

        //Consultar si puedo hacer esto desde aca
        //Metodo para crear unidad normal
        public Creador CrearUnidadNormal(){
           Creador objeto = new Creador("Normal", 4, 6, TipoUnidad.comun);
           return objeto;
        }

        //Metodo para crear unidad Tanque
        public Creador CrearUnidadTanque(){
            Creador objeto = new Creador("Tanque", 4, 10, TipoUnidad.tanque);
            return objeto;
        }

        //Metodo para crear unidad Daño
        public Creador CrearUnidadDaño(){
            Creador objeto = new Creador("Daño", 6, 4, TipoUnidad.daño);
            return objeto;
        }
        //Hasta acá


        public List<Creador> CrearListaUnidades()
        {
            var unidades = new List<Creador>();
            
            return unidades;
        }

        

        //Recordar hacer un funcion para darle nombres aleatorios a las unidades



        
    }

}