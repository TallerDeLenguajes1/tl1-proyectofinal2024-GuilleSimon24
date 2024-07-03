public enum TipoUnidad
{
    comun,
    tanque,
    daño
}

public class Unidad
{
    private string nombre;
    private int ataque;
    private int defensa;
    private TipoUnidad tipo;
    private int costo;


    public string Nombre { get => nombre; set => nombre = value; }
    public int Ataque { get => ataque; set => ataque = value; }
    public int Defensa { get => defensa; set => defensa = value; }
    public TipoUnidad Tipo { get => tipo; set => tipo = value; }
    public int Costo { get => costo; set => costo = value; }

    public Unidad(string nombre, int ataque, int defensa, TipoUnidad tipo, int costo)
    {
        this.nombre = nombre;
        this.ataque = ataque;
        this.defensa = defensa;
        this.tipo = tipo;

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

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Ataque: {Ataque}, Defensa: {Defensa}, Tipo: {Tipo}";
    }

}
