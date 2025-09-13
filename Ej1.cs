using System;
using System.Collections.Generic;

class NotasCurso
{
    static void Main()
    {
        List<double> notas = new List<double>();
        string entrada;
        Console.WriteLine("Ingrese las notas de los estudiantes (1 a 5). Escriba 'fin' para terminar:");
        
        while (true)
        {
            entrada = Console.ReadLine();
            if (entrada.ToLower() == "fin") break;
            double nota = double.Parse(entrada);

            if (nota >= 1 && nota <= 5)
            {
                notas.Add(nota);
            }
            else
            {
                Console.WriteLine("Nota inválida. Ingrese una nota entre 1 y 5.");
            }
        }

        if (notas.Count == 0)
        {
            Console.WriteLine("No se ingresaron notas.");
            return;
        }

        Console.WriteLine("\nListado de notas:");
        double suma = 0;
        bool riesgo = false;

        foreach (var nota in notas)
        {
            Console.WriteLine($"Nota: {nota} - {(nota >= 3 ? "Aprobado" : "Reprobado")}");
            suma += nota;
            if (nota < 2) riesgo = true;
        }

        double promedio = suma / notas.Count;
        Console.WriteLine($"\nPromedio del grupo: {promedio}");

        if (riesgo)
        {
            Console.WriteLine(" Hay estudiantes en riesgo académico.");
        }
    }
}
