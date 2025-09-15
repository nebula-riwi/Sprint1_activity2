using System;
using System.Linq;
using System.Collections.Generic;

class ProgramaEjercicios
{
    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\nMenú principal");
            Console.WriteLine("1. Gestión de notas");
            Console.WriteLine("2. Carrito de Compras");
            Console.WriteLine("3. Concurso Canto");
            Console.WriteLine("4. Salir");
            Console.Write("Selecciona una opción: ");

            string opcion = Console.ReadLine()?.Trim() ?? "";

            switch (opcion)
            {
                case "1":
                    GestionNotas();
                    break;

                case "2":
                    CarritoCompras();
                    break;

                case "3":
                    ConcursoCanto();
                    break;

                case "4":
                    salir = true;
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void GestionNotas()
    {
        List<int> notas = new();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\nMenú de notas");
            Console.WriteLine("1. Agregar nota");
            Console.WriteLine("2. Mostrar todas");
            Console.WriteLine("3. Mostrar aprobadas");
            Console.WriteLine("4. Promedio");
            Console.WriteLine("5. Estudiantes en riesgo");
            Console.WriteLine("6. Volver al menú principal");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine()?.Trim() ?? "";

            switch (opcion)
            {
                case "1":
                    int nota = LeerNota();
                    notas.Add(nota);
                    Console.WriteLine("Nota agregada.");
                    break;

                case "2":
                    MostrarLista(notas, "Todas las notas");
                    break;

                case "3":
                    var aprobadas = notas.Where(n => n >= 3).ToList();
                    MostrarLista(aprobadas, "Notas aprobadas");
                    break;

                case "4":
                    if (notas.Count == 0)
                        Console.WriteLine("No hay notas registradas.");
                    else
                        Console.WriteLine($"Promedio: {notas.Average():F2}");
                    break;

                case "5":
                    var riesgo = notas.Where(n => n < 3).ToList();
                    MostrarLista(riesgo, "Estudiantes en riesgo");
                    break;

                case "6":
                    salir = true;
                    Console.WriteLine("Volviendo al menú principal...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void CarritoCompras()
    {
        List<Producto> productos = new();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\nEjercicio 2: Carrito de Compras");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar carrito");
            Console.WriteLine("3. Editar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Calcular total");
            Console.WriteLine("6. Volver al menú principal");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine()?.Trim() ?? "";

            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine()?.Trim() ?? "";
                    int cantidad = LeerEntero("Cantidad: ");
                    decimal precio = LeerDecimal("Precio: ");
                    productos.Add(new Producto { Nombre = nombre, Cantidad = cantidad, Precio = precio });
                    Console.WriteLine("Producto agregado.");
                    break;

                case "2":
                    if (productos.Count == 0)
                    {
                        Console.WriteLine("Carrito vacío.");
                    }
                    else
                    {
                        Console.WriteLine("\nDetalle del carrito:");
                        foreach (var p in productos)
                        {
                            Console.WriteLine($"- {p.Nombre} | Cantidad: {p.Cantidad} | Precio: {p.Precio:C} | Subtotal: {p.Subtotal:C}");
                            if (p.Cantidad == 0)
                                Console.WriteLine("  ⚠️ Advertencia: cantidad 0.");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Producto a editar: ");
                    string editar = Console.ReadLine()?.Trim() ?? "";
                    var prodEdit = productos.FirstOrDefault(p => p.Nombre.Equals(editar, StringComparison.OrdinalIgnoreCase));
                    if (prodEdit == null)
                    {
                        Console.WriteLine("No encontrado.");
                    }
                    else
                    {
                        prodEdit.Cantidad = LeerEntero("Nueva cantidad: ");
                        prodEdit.Precio = LeerDecimal("Nuevo precio: ");
                        Console.WriteLine("Producto actualizado.");
                    }
                    break;

                case "4":
                    Console.Write("Producto a eliminar: ");
                    string eliminar = Console.ReadLine()?.Trim() ?? "";
                    int removidos = productos.RemoveAll(p => p.Nombre.Equals(eliminar, StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine(removidos > 0 ? "Producto eliminado." : "No encontrado.");
                    break;

                case "5":
                    decimal total = productos.Sum(p => p.Subtotal);
                    decimal descuento = total > 200 ? total * 0.10m : 0;
                    decimal final = total - descuento;
                    Console.WriteLine($"\nTotal: {total:C}");
                    if (descuento > 0)
                        Console.WriteLine($"Descuento: {descuento:C}");
                    Console.WriteLine($"Total a pagar: {final:C}");
                    break;

                case "6":
                    salir = true;
                    Console.WriteLine("Volviendo al menú principal...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    class Producto
    {
        public string Nombre { get; set; } = "";
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal => Cantidad * Precio;
    }

    static int LeerEntero(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine()?.Trim() ?? "";
            if (int.TryParse(entrada, out int valor) && valor >= 0)
                return valor;
            Console.WriteLine("Valor inválido.");
        }
    }

    static decimal LeerDecimal(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine()?.Trim() ?? "";
            if (decimal.TryParse(entrada, out decimal valor) && valor >= 0)
                return valor;
            Console.WriteLine("Valor inválido.");
        }
    }


    static void ConcursoCanto()
    {
        List<string> concursantes = new();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\nEjercicio 3: Concurso de Canto");
            Console.WriteLine("1. Inscribir concursante");
            Console.WriteLine("2. Mostrar todos los inscritos");
            Console.WriteLine("3. Buscar concursante");
            Console.WriteLine("4. Editar nombre");
            Console.WriteLine("5. Eliminar concursante");
            Console.WriteLine("6. Contar inscritos");
            Console.WriteLine("7. Contar nombres que empiezan con 'A'");
            Console.WriteLine("8. Volver al menú principal");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine()?.Trim() ?? "";

            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre del concursante: ");
                    string nombre = Console.ReadLine()?.Trim() ?? "";
                    if (!string.IsNullOrEmpty(nombre))
                    {
                        concursantes.Add(nombre);
                        Console.WriteLine("Concursante inscrito.");
                    }
                    else
                    {
                        Console.WriteLine("Nombre inválido.");
                    }
                    break;

                case "2":
                    if (concursantes.Count == 0)
                    {
                        Console.WriteLine("No hay concursantes inscritos.");
                    }
                    else
                    {
                        Console.WriteLine("\nLista de concursantes:");
                        concursantes.ForEach(n => Console.WriteLine($"- {n}"));
                    }
                    break;

                case "3":
                    Console.Write("Nombre a buscar: ");
                    string buscar = Console.ReadLine()?.Trim() ?? "";
                    bool existe = concursantes.Any(n => n.Equals(buscar, StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine(existe ? "Sí está inscrito." : "No está inscrito.");
                    break;

                case "4":
                    Console.Write("Nombre actual: ");
                    string actual = Console.ReadLine()?.Trim() ?? "";
                    int index = concursantes.FindIndex(n => n.Equals(actual, StringComparison.OrdinalIgnoreCase));
                    if (index == -1)
                    {
                        Console.WriteLine("Concursante no encontrado.");
                    }
                    else
                    {
                        Console.Write("Nuevo nombre: ");
                        string nuevo = Console.ReadLine()?.Trim() ?? "";
                        if (!string.IsNullOrEmpty(nuevo))
                        {
                            concursantes[index] = nuevo;
                            Console.WriteLine("Nombre actualizado.");
                        }
                        else
                        {
                            Console.WriteLine("Nombre inválido.");
                        }
                    }
                    break;

                case "5":
                    Console.Write("Nombre a eliminar: ");
                    string eliminar = Console.ReadLine()?.Trim() ?? "";
                    int eliminados = concursantes.RemoveAll(n => n.Equals(eliminar, StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine(eliminados > 0 ? "Concursante eliminado." : "No encontrado.");
                    break;

                case "6":
                    Console.WriteLine($"Total de concursantes inscritos: {concursantes.Count}");
                    break;

                case "7":
                    int conA = concursantes.Count(n => n.StartsWith("A", StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine($"Nombres que comienzan con 'A': {conA}");
                    break;

                case "8":
                    salir = true;
                    Console.WriteLine("Volviendo al menú principal...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }


    static int LeerNota()
    {
        while (true)
        {
            Console.Write("Ingresa una nota (1 a 5): ");
            string entrada = Console.ReadLine()?.Trim() ?? "";

            if (int.TryParse(entrada, out int nota) && nota >= 1 && nota <= 5)
                return nota;

            Console.WriteLine("Nota inválida.");
        }
    }

    static void MostrarLista(List<int> lista, string titulo)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine($"No hay datos para '{titulo}'.");
        }
        else
        {
            Console.WriteLine($"\n{titulo}:");
            lista.ForEach(n => Console.WriteLine($"- {n}"));
        }
    }
}
