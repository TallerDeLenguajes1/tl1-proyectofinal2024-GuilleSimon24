//Esto es prueba de creacion de personajes, ANDA JOOOOOOOOYA, lo dejo comentado
//Recordar hacer una funcion que le de nombres aleatorios a las unidades
/*


Console.WriteLine(unidad1.ToString());

Console.WriteLine(unidad2.ToString());

Console.WriteLine(unidad3.ToString());

unidad1.bajandoStats();
unidad2.bajandoStats();
unidad3.bajandoStats();
Console.WriteLine(unidad1.ToString());
Console.WriteLine(unidad2.ToString());
Console.WriteLine(unidad3.ToString());
*/
using Personajes;
using Bases;

Creador unidad1 = new Creador();
unidad1 = unidad1.CrearUnidadNormal();


Creador unidad2 = new Creador();
unidad2 = unidad2.CrearUnidadTanque();

Creador unidad3 = new Creador();
unidad3 = unidad3.CrearUnidadDaño();





Base mia = new Base();
Base enemiga = new Base();

mia = mia.CrearBase();
enemiga = enemiga.CrearBaseEnemiga();


List<Creador> lista = new List<Creador>();

lista.Add(unidad3);

lista.Add(unidad2);

lista.Add(unidad1);

//Para mostrar listas
foreach (Creador unidad in lista)
{
    Console.WriteLine(unidad);
}
Console.WriteLine("");
lista.RemoveAt(0);

foreach (Creador unidad in lista)
{
    Console.WriteLine(unidad);
}
Console.WriteLine("");

lista.RemoveAt(0);

foreach (Creador unidad in lista)
{
    Console.WriteLine(unidad);
}

//Las listas funcionan como FILA


