using System;
using System.Collections.Generic;

class Empleado
{
    public string nombre { get; set; }
    public int edad { get; set; }
    public string correo { get; set; }
}

class RegistroEmpleados
{
    static void Main()
    {
        List<Empleado> empleados = new List<Empleado>();
        string entrada;

        Console.WriteLine("Ingrese los empleados. Escriba 'fin' en el nombre para terminar.");

        while (true)
        {
            Console.Write("Nombre: ");
            entrada = Console.ReadLine();
            if (entrada.ToLower() == "fin") break;

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            Console.Write("Correo: ");
            string correo = Console.ReadLine();

            empleados.Add(new Empleado { nombre = entrada, edad = edad, correo = correo });
        }

        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            return;
        }

        Console.WriteLine("\nLista de empleados:");
        foreach (var e in empleados)
        {
            Console.WriteLine($"{e.nombre} - {e.edad} años - {e.correo}");
        }

        int menores = 0;
        Empleado mayor = empleados[0];

        foreach (var e in empleados)
        {
            if (e.edad < 18) menores++;
            if (e.edad > mayor.edad) mayor = e;
        }

        Console.WriteLine($"\nMenores de edad: {menores}");
        Console.WriteLine($"Empleado de mayor edad: {mayor.nombre} ({mayor.edad} años)");
    }
}
