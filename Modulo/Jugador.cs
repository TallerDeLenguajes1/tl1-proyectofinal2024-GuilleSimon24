public class Jugador
{
    int oro;
    Base baseDeJugador;
    List<Unidad> unidades;
    int oroGastado;

    string nombre;

    public Jugador()
    {
    }

    public Base BaseDeJugador { get => baseDeJugador; set => baseDeJugador = value; }
    public List<Unidad> Unidades { get => unidades; set => unidades = value; }
    public int Oro { get => oro; set => oro = value; }
    public int OroGastado { get => oroGastado; set => oroGastado = value; }
    public string Nombre { get => nombre; set => nombre = value; }
}
