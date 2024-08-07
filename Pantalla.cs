public class Pantalla
{
    public Pantalla()
    {

    }

    public void MensajeDeBienvenida()
    {
        Console.WriteLine(@"
             ▄████████    ▄██████▄     ▄████████       ▄██████▄     ▄████████       ▄█     █▄     ▄████████    ▄████████
            ███    ███   ███    ███   ███    ███      ███    ███   ███    ███      ███     ███   ███    ███   ███    ███
            ███    ███   ███    █▀    ███    █▀       ███    ███   ███    █▀       ███     ███   ███    ███   ███    ███
            ███    ███  ▄███         ▄███▄▄▄          ███    ███  ▄███▄▄▄          ███     ███   ███    ███  ▄███▄▄▄▄██▀
           ▀███████████▀▀███ ████▄  ▀▀███▀▀▀          ███    ███ ▀▀███▀▀▀          ███     ███ ▀███████████ ▀▀███▀▀▀▀▀  
            ███    ███   ███    ███   ███    █▄       ███    ███   ███             ███     ███   ███    ███ ▀███████████
            ███    ███   ███    ███   ███    ███      ███    ███   ███             ███ ▄█▄ ███   ███    ███   ███    ███
            ███    █▀    ████████▀    ██████████       ▀██████▀    ███              ▀███▀███▀    ███    █▀    ███    ███
                                                                                                              ███    ███");
        Console.WriteLine("                                                Presione una tecla para continuar         ");
        Console.ReadKey();
    }

    public void Menu()
    {
        Console.WriteLine(@"
        ░█▄█░█▀▀░█▀█░█░█
        ░█░█░█▀▀░█░█░█░█
        ░▀░▀░▀▀▀░▀░▀░▀▀▀");
    }
    public void Bienvenido()
    {
        Console.WriteLine(@"
        ░█▀▄░▀█▀░█▀▀░█▀█░█░█░█▀▀░█▀█░▀█▀░█▀▄░█▀█░░░█▀█░█░░░░░▀▀█░█░█░█▀▀░█▀▀░█▀█
        ░█▀▄░░█░░█▀▀░█░█░▀▄▀░█▀▀░█░█░░█░░█░█░█░█░░░█▀█░█░░░░░░░█░█░█░█▀▀░█░█░█░█
        ░▀▀░░▀▀▀░▀▀▀░▀░▀░░▀░░▀▀▀░▀░▀░▀▀▀░▀▀░░▀▀▀░░░▀░▀░▀▀▀░░░▀▀░░▀▀▀░▀▀▀░▀▀▀░▀▀▀");
    }

    public void GanoElJugador()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(@"
         ██████╗  █████╗ ███╗   ██╗ █████╗ ███████╗████████╗███████╗
        ██╔════╝ ██╔══██╗████╗  ██║██╔══██╗██╔════╝╚══██╔══╝██╔════╝
        ██║  ███╗███████║██╔██╗ ██║███████║███████╗   ██║   █████╗  
        ██║   ██║██╔══██║██║╚██╗██║██╔══██║╚════██║   ██║   ██╔══╝  
        ╚██████╔╝██║  ██║██║ ╚████║██║  ██║███████║   ██║   ███████╗
        ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝   ╚═╝   ╚══════╝
                                                                    ");
        Console.ResetColor();
    }

    public void GanoElEnemigo()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
        
         ██▓███   ▓█████   ██▀███   ▓█████▄   ██▓  ██████  ▄▄▄█████▓    ▓█████ 
        ▓██░  ██ ▒▓█   ▀  ▓██ ▒ ██ ▒▒██▀ ██▌ ▓██▒ ▒██    ▒  ▓  ██▒ ▓▒   ▓█   ▀ 
        ▓██░ ██▓ ▒▒███    ▓██ ░▄█  ▒░██   █▌ ▒██▒ ░ ▓██▄    ▒ ▓██░ ▒░  ▒███   
        ▒██▄█▓▒  ▒▒▓█  ▄  ▒██▀▀█▄   ░▓█▄   ▌ ░██░   ▒   ██▒ ░ ▓██▓ ░   ▒▓█  ▄ 
        ▒██▒ ░   ░░▒████▒ ░██▓ ▒██ ▒░▒████▓  ░██░ ▒██████▒▒   ▒██▒ ░  ░▒████▒
        ▒▓▒░ ░   ░░░ ▒░ ░ ░ ▒▓ ░▒▓ ░ ▒▒▓  ▒  ░▓   ▒ ▒▓▒ ▒ ░  ▒ ░░    ░░ ▒░ ░
        ░▒ ░       ░ ░  ░   ░▒ ░ ▒ ░ ░ ▒  ▒   ▒  ░░ ░▒  ░ ░    ░     ░ ░  ░
        ░░          ░      ░░   ░  ░ ░  ░    ▒  ░░  ░  ░     ░         ░   
                    ░  ░    ░        ░       ░        ░              ░  ░
                                ░                                   ");
        Console.ResetColor();
    }

    public void Empate(){
        Console.WriteLine(@"
        ░█▀▀░█▄█░█▀█░█▀█░▀█▀░█▀▀
        ░█▀▀░█░█░█▀▀░█▀█░░█░░█▀▀
        ░▀▀▀░▀░▀░▀░░░▀░▀░░▀░░▀▀▀");
    }
}

