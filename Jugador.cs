namespace Gameplay
{
    using Unidades;
    using Bases;
    using System.Collections.Generic;

    class Jugador
    {
        int oro;
        Base baseDeJugador;
        List<Unidad> unidades;

        public Base BaseDeJugador { get => baseDeJugador; set => baseDeJugador = value; }
        public List<Unidad> Unidades { get => unidades; set => unidades = value; }
        public int Oro { get => oro; set => oro = value; }
    }
}