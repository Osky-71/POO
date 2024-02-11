using System;
using System.Collections.Generic;

class RepuestoVehicular
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string Marca { get; set; }

    public RepuestoVehicular(string nombre, decimal precio, string marca)
    {
        Nombre = nombre;
        Precio = precio;
        Marca = marca;
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Precio: {Precio:C}, Marca: {Marca}");
    }
}

class Program
{
    static List<RepuestoVehicular> repuestos = new List<RepuestoVehicular>();

    static void Main(string[] args)
    {
        // Agregar algunos repuestos vehiculares predefinidos
        repuestos.Add(new RepuestoVehicular("Filtro de aceite", 15.99m, "Bosch"));
        repuestos.Add(new RepuestoVehicular("Pastillas de freno", 49.99m, "Ferodo"));
        repuestos.Add(new RepuestoVehicular("Batería", 89.99m, "Varta"));

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\n1. Mostrar todos los repuestos");
            Console.WriteLine("2. Agregar repuesto");
            Console.WriteLine("3. Editar repuesto");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción: ");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        MostrarTodosRepuestos();
                        break;
                    case 2:
                        AgregarRepuesto();
                        break;
                    case 3:
                        EditarRepuesto();
                        break;
                    case 4:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        }
    }

    static void MostrarTodosRepuestos()
    {
        Console.WriteLine("\nListado de todos los repuestos:");
        foreach (var repuesto in repuestos)
        {
            repuesto.MostrarInformacion();
        }
    }

    static void AgregarRepuesto()
    {
        Console.Write("\nIngrese el nombre del repuesto: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el precio del repuesto: ");
        decimal precio;
        while (!decimal.TryParse(Console.ReadLine(), out precio))
        {
            Console.Write("Precio no válido. Ingrese un valor numérico: ");
        }
        Console.Write("Ingrese la marca del repuesto: ");
        string marca = Console.ReadLine();

        repuestos.Add(new RepuestoVehicular(nombre, precio, marca));
        Console.WriteLine("Repuesto agregado correctamente.");
    }

    static void EditarRepuesto()
    {
        Console.Write("\nIngrese el nombre del repuesto que desea editar: ");
        string nombre = Console.ReadLine();
        RepuestoVehicular repuesto = BuscarRepuesto(nombre);
        if (repuesto != null)
        {
            Console.WriteLine($"Nombre actual: {repuesto.Nombre}");
            Console.Write("Ingrese el nuevo nombre del repuesto (deje vacío para mantener el actual): ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                repuesto.Nombre = nuevoNombre;
            }

            Console.WriteLine($"Precio actual: {repuesto.Precio:C}");
            Console.Write("Ingrese el nuevo precio del repuesto (deje vacío para mantener el actual): ");
            string precioStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(precioStr))
            {
                decimal nuevoPrecio;
                while (!decimal.TryParse(precioStr, out nuevoPrecio))
                {
                    Console.Write("Precio no válido. Ingrese un valor numérico: ");
                    precioStr = Console.ReadLine();
                }
                repuesto.Precio = nuevoPrecio;
            }

            Console.WriteLine($"Marca actual: {repuesto.Marca}");
            Console.Write("Ingrese la nueva marca del repuesto (deje vacío para mantener el actual): ");
            string nuevaMarca = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaMarca))
            {
                repuesto.Marca = nuevaMarca;
            }

            Console.WriteLine("Repuesto editado correctamente.");
        }
        else
        {
            Console.WriteLine("Repuesto no encontrado.");
        }
    }

    static RepuestoVehicular BuscarRepuesto(string nombre)
    {
        foreach (var repuesto in repuestos)
        {
            if (repuesto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                return repuesto;
            }
        }
        return null;
    }
}
