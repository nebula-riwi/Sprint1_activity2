using System;
using System.Collections.Generic;
using System.Linq;

class ConcursoCanto
{
    static void Main()
    {
        List<string> concursantes = new List<string>();
        string entrada;
        Console.WriteLine("Ingrese los nombres de los concursantes. Escriba 'fin' para terminar:");

        while (true)
        {
            entrada = Console.ReadLine();
            if (entrada.ToLower() == "fin") break;
            concursantes.Add(entrada);
        }

        if (concursantes.Count == 0)
        {
            Console.WriteLine("No hay concursantes registrados.");
            return;
        }

        Console.WriteLine("\nLista de concursantes:");
        foreach (var nombre in concursantes)
        {
            Console.WriteLine(nombre);
        }

        Console.Write("\nIngrese un nombre para verificar si está inscrito: ");
        string buscar = Console.ReadLine();

        if (concursantes.Contains(buscar))
        {
            Console.WriteLine($"{buscar} sí está inscrito.");
        }
        else
        {
            Console.WriteLine($"{buscar} no está inscrito.");
        }

        int cantidadA = concursantes.Count(n => n.StartsWith("A", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"\nNúmero de concursantes: {concursantes.Count}");
        Console.WriteLine($"Concursantes que comienzan con A: {cantidadA}");
    }
}
