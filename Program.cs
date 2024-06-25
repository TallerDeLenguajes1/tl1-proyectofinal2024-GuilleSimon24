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
using Unidades;
using Bases;

Unidad unidad1 = new Unidad();
unidad1 = unidad1.CrearUnidadNormal();


Unidad unidad2 = new Unidad();
unidad2 = unidad2.CrearUnidadTanque();

Unidad unidad3 = new Unidad();
unidad3 = unidad3.CrearUnidadDaño();





Base mia = new Base();
Base enemiga = new Base();

mia = mia.CrearBase();
enemiga = enemiga.CrearBaseEnemiga();


List<Unidad> lista = new List<Unidad>();

lista.Add(unidad3);

lista.Add(unidad2);

lista.Add(unidad1);

//Para mostrar listas
foreach (Unidad unidad in lista)
{
    Console.WriteLine(unidad);
}
Console.WriteLine("");
lista.RemoveAt(0);

foreach (Unidad unidad in lista)
{
    Console.WriteLine(unidad);
}
Console.WriteLine("");

lista.RemoveAt(0);

foreach (Unidad unidad in lista)
{
    Console.WriteLine(unidad);
}

//Las listas funcionan como FILA


