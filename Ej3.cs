using System;
using System.Collections.Generic;

class Producto
{
    public string nombre { get; set; }
    public int cantidad { get; set; }
    public double precio { get; set; }
}

class CarritoCompras
{
    static void Main()
    {
        List<Producto> carrito = new List<Producto>();
        string entrada;

        Console.WriteLine("Ingrese los productos al carrito. Escriba 'fin' para terminar.");

        while (true)
        {
            Console.Write("Nombre del producto: ");
            entrada = Console.ReadLine();
            if (entrada.ToLower() == "fin") break;

            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());

            Console.Write("Precio unitario: ");
            double precio = double.Parse(Console.ReadLine());

            carrito.Add(new Producto { nombre = entrada, cantidad = cantidad, precio = precio });
        }

        if (carrito.Count == 0)
        {
            Console.WriteLine("El carrito está vacío.");
            return;
        }

        Console.WriteLine("\nDetalle del carrito:");
        double total = 0;
        foreach (var p in carrito)
        {
            Console.WriteLine($"{p.nombre} - Cantidad: {p.cantidad} - Precio: {p.precio} - Subtotal: {p.cantidad * p.precio}");
            total += p.cantidad * p.precio;
            if (p.cantidad == 0)
            {
                Console.WriteLine($" Advertencia: {p.nombre} tiene cantidad 0.");
            }
        }

        if (total > 200)
        {
            Console.WriteLine($"\nSubtotal: {total}");
            total *= 0.9;
            Console.WriteLine("Se aplicó 10% de descuento por compras mayores a 200.");
        }

        Console.WriteLine($"\nTotal a pagar: {total}");
    }
}
