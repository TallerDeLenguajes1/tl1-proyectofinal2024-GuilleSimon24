namespace Enemigos
{
    using Unidades;
    using Bases;
    class Enemigo
    {

        private string nombre;
        private int ataque;
        private int defensa;
        private int posicion;

        private TipoUnidad tipo;

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

        public Enemigo(string nombre, int ataque, int defensa, TipoUnidad tipo)
        {
            this.nombre = nombre;
            this.ataque = ataque;
            this.defensa = defensa;
            this.tipo = tipo;
            Posicion = 10;

        }

        public Enemigo()
        {

        }

        public void avanzarPosicionEnemiga()
        {
            posicion--;
        }

        public Unidad unidadAleatoria(int oro)
        {
            Unidad nueva = new Unidad();
            Random random = new Random();
            int aleatorio = random.Next(1, 4);

            switch (aleatorio)
            {
                case 1:
                    nueva.CrearUnidadTanque();
                    break;
                case 2:
                    nueva.CrearUnidadDaño();
                    break;
                case 3:
                    nueva.CrearUnidadNormal();
                    break;
            }

            return nueva;
        }


    }
}