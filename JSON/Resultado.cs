class ResultadoJuego
{
    private string nombreGanador;
    private Base baseGanador;
    private int oroGastado;
    private DateTime fechaYHora;

    public DateTime FechaYHora { get => fechaYHora; set => fechaYHora = value; }
    public string NombreGanador { get => nombreGanador; set => nombreGanador = value; }
    public Base BaseGanador { get => baseGanador; set => baseGanador = value; }
    public int OroGastado { get => oroGastado; set => oroGastado = value; }
}