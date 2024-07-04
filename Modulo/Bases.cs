public class Base
{
    private string nombre;
    private int salud;
    private int defensa;
    private int ataque;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Defensa { get => defensa; set => defensa = value; }
    public int Ataque { get => ataque; set => ataque = value; }

    public Base() { }

    public Base(string nombre, int salud, int defensa, int ataque)
    {
        this.nombre = nombre;
        this.salud = salud;
        this.defensa = defensa;
        this.ataque = ataque;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Salud: {Salud}, Defensa: {Defensa}, Ataque: {Ataque}";
    }


    public void BaseAtacada(Unidad unidadAtacante)
    {
        int daño = unidadAtacante.Ataque - defensa;
        salud -= daño > 0 ? daño : 0;
        unidadAtacante.bajandoStats();
    }

    public void CrearBasePropia()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Ingrese un nombre para su base: ");
        string nombre = Console.ReadLine();
        this.nombre = nombre;
        salud = 50;
        ataque = 5;
        defensa = 2;
    }

    public void CrearBaseEnemiga()
    {
        nombre = "Base enemiga";
        salud = 50;
        ataque = 5;
        defensa = 2;
    }

}



