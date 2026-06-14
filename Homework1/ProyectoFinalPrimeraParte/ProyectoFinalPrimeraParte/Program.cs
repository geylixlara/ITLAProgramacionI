//using System;
//using System.Collections.Generic;

class Habitacion
{
    public int Numero;
    public string Tipo;
    public string Estado;

    public Habitacion(int numero, string tipo)
    {
        Numero = numero;
        Tipo = tipo;
        Estado = "Disponible";
    }
}                                   // esa es una clase o

class Huesped
{
    public string Nombre;
    public string Documento;

    public Huesped(string nombre, string documento)
    {
        Nombre = nombre;
        Documento = documento;
    }
}

class Reserva
{
    public Habitacion Habitacion;
    public Huesped Huesped;
    public string FechaEntrada;
    public string FechaSalida;

    public Reserva(Habitacion habitacion, Huesped huesped,
                   string fechaEntrada, string fechaSalida)
    {
        Habitacion = habitacion;
        Huesped = huesped;
        FechaEntrada = fechaEntrada;
        FechaSalida = fechaSalida;
    }
}

class Program
{
    static List<Habitacion> habitaciones = new List<Habitacion>();
    static List<Huesped> huespedes = new List<Huesped>();
    static List<Reserva> reservas = new List<Reserva>();

    static void Main()
    {
        habitaciones.Add(new Habitacion(101, "Simple"));
        habitaciones.Add(new Habitacion(102, "Doble"));
        habitaciones.Add(new Habitacion(103, "Suite"));

        int opcion = -1;

        while (opcion != 0)
        {
            Console.Clear();

            Console.WriteLine("===== HOTEL =====");
            Console.WriteLine("1. Registrar huesped");
            Console.WriteLine("2. Registrar reserva");
            Console.WriteLine("3. Ver habitaciones disponibles");
            Console.WriteLine("4. Cambiar estado de habitacion");
            Console.WriteLine("5. Ver reservas");
            Console.WriteLine("0. Salir");

            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opcion invalida");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarHuesped();
                    break;

                case 2:
                    RegistrarReserva();
                    break;

                case 3:
                    MostrarDisponibles();
                    break;

                case 4:
                    CambiarEstado();
                    break;

                case 5:
                    MostrarReservas();
                    break;

                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void RegistrarHuesped()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Documento: ");
        string documento = Console.ReadLine();

        if (nombre == "" || documento == "")
        {
            Console.WriteLine("No puede dejar campos vacios.");
            return;
        }

        Huesped nuevo = new Huesped(nombre, documento);
        huespedes.Add(nuevo);

        Console.WriteLine("Huesped registrado.");
    }

    static void RegistrarReserva()
    {
        Console.Write("Documento del huesped: ");
        string documento = Console.ReadLine();

        Huesped huespedEncontrado = null;

        foreach (Huesped h in huespedes)
        {
            if (h.Documento == documento)
            {
                huespedEncontrado = h;
            }
        }

        if (huespedEncontrado == null)
        {
            Console.WriteLine("Huesped no encontrado.");
            return;
        }

        Console.Write("Numero de habitacion: ");

        int numero;

        if (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Numero invalido.");
            return;
        }

        Habitacion habitacionEncontrada = null;

        foreach (Habitacion h in habitaciones)
        {
            if (h.Numero == numero &&
                h.Estado == "Disponible")
            {
                habitacionEncontrada = h;
            }
        }

        if (habitacionEncontrada == null)
        {
            Console.WriteLine("Habitacion no disponible.");
            return;
        }

        Console.Write("Fecha de entrada: ");
        string entrada = Console.ReadLine();

        Console.Write("Fecha de salida: ");
        string salida = Console.ReadLine();

        Reserva reserva = new Reserva(
            habitacionEncontrada,
            huespedEncontrado,
            entrada,
            salida);

        reservas.Add(reserva);

        habitacionEncontrada.Estado = "Ocupada";

        Console.WriteLine("Reserva registrada.");
    }

    static void MostrarDisponibles() // esas no se pueden por ejemplo?
    {
        Console.WriteLine("\nHabitaciones disponibles:");

        foreach (Habitacion h in habitaciones)
        {
            if (h.Estado == "Disponible")
            {
                Console.WriteLine(
                    "Habitacion " + h.Numero +
                    " - " + h.Tipo);
            }
        }
    }

    static void CambiarEstado()
    {
        Console.Write("Numero de habitacion: ");

        int numero;

        if (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Numero invalido.");
            return;
        }

        foreach (Habitacion h in habitaciones)
        {
            if (h.Numero == numero)
            {
                Console.Write("Nuevo estado: ");
                h.Estado = Console.ReadLine();

                Console.WriteLine("Estado actualizado.");
                return;
            }
        }

        Console.WriteLine("Habitacion no encontrada.");
    }

    static void MostrarReservas()
    {
        if (reservas.Count == 0)
        {
            Console.WriteLine("No hay reservas.");
            return;
        }

        foreach (Reserva r in reservas)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Huesped: " + r.Huesped.Nombre);
            Console.WriteLine("Habitacion: " + r.Habitacion.Numero);
            Console.WriteLine("Entrada: " + r.FechaEntrada);
            Console.WriteLine("Salida: " + r.FechaSalida);
        }
    }
}