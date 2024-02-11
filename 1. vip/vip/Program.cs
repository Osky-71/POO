using System;
using System.Collections.Generic;

class Cliente
{
    public string Nombre { get; set; }
    public string Categoria { get; protected set; }

    public Cliente(string nombre)
    {
        Nombre = nombre;
        Categoria = "Regular";
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Categoría: {Categoria}");
    }
}

class ClienteVIP : Cliente
{
    public ClienteVIP(string nombre) : base(nombre)
    {
        Categoria = "VIP";
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
    }
}

class Program
{
    static List<Cliente> clientes = new List<Cliente>();

    static void Main(string[] args)
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\n1. Mostrar todos los clientes");
            Console.WriteLine("2. Mostrar clientes por categoría");
            Console.WriteLine("3. Agregar nuevo cliente");
            Console.WriteLine("4. Editar cliente");
            Console.WriteLine("5. Eliminar cliente");
            Console.WriteLine("6. Promover cliente a VIP");
            Console.WriteLine("7. Salir");
            Console.Write("\nSeleccione una opción: ");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        MostrarTodosClientes();
                        break;
                    case 2:
                        MostrarClientesPorCategoria();
                        break;
                    case 3:
                        AgregarCliente();
                        break;
                    case 4:
                        EditarCliente();
                        break;
                    case 5:
                        EliminarCliente();
                        break;
                    case 6:
                        PromoverClienteVIP();
                        break;
                    case 7:
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

    static void MostrarTodosClientes()
    {
        Console.WriteLine("\nListado de todos los clientes:");
        foreach (var cliente in clientes)
        {
            cliente.MostrarInformacion();
        }
    }

    static void MostrarClientesPorCategoria()
    {
        Console.Write("\nIngrese la categoría (Regular/VIP): ");
        string categoria = Console.ReadLine();
        Console.WriteLine($"\nListado de clientes {categoria}s:");
        foreach (var cliente in clientes)
        {
            if (cliente.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            {
                cliente.MostrarInformacion();
            }
        }
    }

    static void AgregarCliente()
    {
        Console.Write("\nIngrese el nombre del cliente: ");
        string nombre = Console.ReadLine();
        Console.Write("¿Es VIP? (S/N): ");
        string respuesta = Console.ReadLine();
        if (respuesta.Equals("S", StringComparison.OrdinalIgnoreCase))
        {
            clientes.Add(new ClienteVIP(nombre));
        }
        else
        {
            clientes.Add(new Cliente(nombre));
        }
        Console.WriteLine("Cliente agregado correctamente.");
    }

    static void EditarCliente()
    {
        Console.Write("\nIngrese el nombre del cliente que desea editar: ");
        string nombre = Console.ReadLine();
        Cliente cliente = BuscarCliente(nombre);
        if (cliente != null)
        {
            Console.Write("Ingrese el nuevo nombre del cliente: ");
            string nuevoNombre = Console.ReadLine();
            cliente.Nombre = nuevoNombre;
            Console.WriteLine("Cliente editado correctamente.");
        }
        else
        {
            Console.WriteLine("Cliente no encontrado.");
        }
    }

    static void EliminarCliente()
    {
        Console.Write("\nIngrese el nombre del cliente que desea eliminar: ");
        string nombre = Console.ReadLine();
        Cliente cliente = BuscarCliente(nombre);
        if (cliente != null)
        {
            clientes.Remove(cliente);
            Console.WriteLine("Cliente eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Cliente no encontrado.");
        }
    }

    static void PromoverClienteVIP()
    {
        Console.Write("\nIngrese el nombre del cliente que desea promover a VIP: ");
        string nombre = Console.ReadLine();
        Cliente cliente = BuscarCliente(nombre);
        if (cliente != null)
        {
            if (cliente is ClienteVIP)
            {
                Console.WriteLine("El cliente ya es VIP.");
            }
            else
            {
                ClienteVIP clienteVIP = new ClienteVIP(cliente.Nombre);
                clientes.Remove(cliente);
                clientes.Add(clienteVIP);
                Console.WriteLine("Cliente promovido a VIP correctamente.");
            }
        }
        else
        {
            Console.WriteLine("Cliente no encontrado.");
        }
    }

    static Cliente BuscarCliente(string nombre)
    {
        foreach (var cliente in clientes)
        {
            if (cliente.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                return cliente;
            }
        }
        return null;
    }
}
