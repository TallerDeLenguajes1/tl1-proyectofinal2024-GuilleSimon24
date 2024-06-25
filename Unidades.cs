namespace Unidades
{

    public class Unidad
    {


        private string nombre;
        private int ataque;
        private int defensa;
        private int posicion;
        private TipoUnidad tipo;
        private int costo;
        public enum TipoUnidad
        {
            comun,
            tanque,
            daño
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Ataque { get => ataque; set => ataque = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        public TipoUnidad Tipo { get => tipo; set => tipo = value; }
        public int Posicion { get => posicion; set => posicion = value; }
        public int Costo{ get => costo; set => costo = value; }
        



        public Unidad(string nombre, int ataque, int defensa, TipoUnidad tipo, int costo)
        {
            this.nombre = nombre;
            this.ataque = ataque;
            this.defensa = defensa;
            this.tipo = tipo;
            Posicion = 0;
            this.costo = costo;

        }



        public Unidad()
        {

        }

        public void bajandoStats()
        {
            Ataque = Ataque / 2;
            Defensa = Defensa / 2;
            if (Ataque == 0)
            {
                Ataque = 1;
            }
        }

        public void avanzarPosicion()
        {
            posicion += 1;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Ataque: {Ataque}, Defensa: {Defensa}, Tipo: {Tipo}";
        }
        //Queda pendiente encontrar una relacion para cumplir con las ideas de combates sucesivos de una unidad

        //Consultar si puedo hacer esto desde aca
        //Metodo para crear unidad normal
        public static Unidad CrearUnidadNormal()
        {
            Unidad objeto = new Unidad("Normal", 4, 6, TipoUnidad.comun, 10);
            return objeto;
        }

        //Metodo para crear unidad Tanque
        public static Unidad CrearUnidadTanque()
        {
            Unidad objeto = new Unidad("Tanque", 4, 10, TipoUnidad.tanque, 20);
            return objeto;
        }

        //Metodo para crear unidad Daño
        public static Unidad CrearUnidadDaño()
        {
            Unidad objeto = new Unidad("Daño", 6, 4, TipoUnidad.daño, 15);
            return objeto;
        }
        //Hasta acá


        public static List<Unidad> CrearListaUnidades()
        {
            var unidades = new List<Unidad>();

            return unidades;
        }



        //Recordar hacer un funcion para darle nombres aleatorios a las unidades


        


    }

}