class FabricaDeUnidades
{
    private List<string> nombresDisponibles;
    public FabricaDeUnidades(List<string> nombresDisponibles)
    {
        this.nombresDisponibles = nombresDisponibles;
    }

    public Unidad CrearUnidadNormal()
    {
        Unidad objeto = new Unidad(ObtenerNombreAleatorio(), 4, 3, TipoUnidad.comun, 10);
        return objeto;
    }
    public Unidad CrearUnidadTanque()
    {
        Unidad objeto = new Unidad(ObtenerNombreAleatorio(), 4, 9, TipoUnidad.tanque, 15);
        return objeto;
    }
    public Unidad CrearUnidadDaño()
    {
        Unidad objeto = new Unidad(ObtenerNombreAleatorio(), 8, 4, TipoUnidad.daño, 20);
        return objeto;
    }

    private string ObtenerNombreAleatorio()
    {
        if (nombresDisponibles.Count == 0)
        {
            throw new InvalidOperationException("No hay nombres disponibles.");
        }
        var random = new Random();
        int index = random.Next(nombresDisponibles.Count);  //Para sacar por indice
        var nombre = nombresDisponibles[index];
        nombresDisponibles.RemoveAt(index); // Elimina el nombre para que no se repita
        return nombre;
    }

}
