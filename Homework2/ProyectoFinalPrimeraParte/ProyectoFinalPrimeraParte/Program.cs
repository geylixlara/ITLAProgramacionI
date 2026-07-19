using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Hotel Registration System";
        Menu menu = new Menu();
        menu.Mostrar();
    }
}

public class Habitacion
{
    public int Numero { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public bool Disponible { get; set; }

    public Habitacion(int numero, string tipo, decimal precio)
    {
        Numero = numero;
        Tipo = tipo ?? string.Empty;
        Precio = precio;
        Disponible = true;
    }

    public override string ToString()
    {
        return $"Habitación {Numero} - {Tipo} - ${Precio} - {(Disponible ? "Disponible" : "Ocupada")}";
    }
}

public class Huesped
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;

    public Huesped(int id, string nombre, string telefono, string correo)
    {
        Id = id;
        Nombre = nombre ?? string.Empty;
        Telefono = telefono ?? string.Empty;
        Correo = correo ?? string.Empty;
    }

    public override string ToString()
    {
        return $"ID: {Id} - {Nombre} - {Telefono} - {Correo}";
    }
}

public class Reserva
{
    public int Id { get; set; }
    public Huesped? Huesped { get; set; }
    public Habitacion? Habitacion { get; set; }
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
    public string Estado { get; set; } = string.Empty;

    public Reserva(int id, Huesped huesped, Habitacion habitacion, DateTime entrada, DateTime salida)
    {
        Id = id;
        Huesped = huesped;
        Habitacion = habitacion;
        FechaEntrada = entrada;
        FechaSalida = salida;
        Estado = "Activa";
        if (habitacion != null)
        {
            habitacion.Disponible = false;
        }
    }

    public override string ToString()
    {
        string nombreHuesped = Huesped?.Nombre ?? "Sin huésped";
        int numeroHabitacion = Habitacion?.Numero ?? 0;
        return $"Reserva #{Id} - {nombreHuesped} - Hab.{numeroHabitacion} - {Estado}";
    }
}

public class HotelService
{
    private List<Habitacion> habitaciones = new List<Habitacion>();
    private List<Huesped> huespedes = new List<Huesped>();
    private List<Reserva> reservas = new List<Reserva>();
    private int nextHuespedId = 1;
    private int nextReservaId = 1;

    public void AgregarHabitacion(int numero, string tipo, decimal precio)
    {
        tipo = tipo ?? string.Empty;

        foreach (var h in habitaciones)
        {
            if (h.Numero == numero)
            {
                Console.WriteLine(" Ya existe una habitación con ese número.");
                return;
            }
        }

        if (string.IsNullOrEmpty(tipo))
        {
            Console.WriteLine(" El tipo de habitación es obligatorio.");
            return;
        }

        habitaciones.Add(new Habitacion(numero, tipo, precio));
        Console.WriteLine(" Habitación agregada exitosamente.");
    }

    public void AgregarHuesped(string nombre, string telefono, string correo)
    {
        nombre = nombre ?? string.Empty;
        telefono = telefono ?? string.Empty;
        correo = correo ?? string.Empty;

        if (string.IsNullOrEmpty(nombre))
        {
            Console.WriteLine(" El nombre es obligatorio.");
            return;
        }

        if (string.IsNullOrEmpty(correo) || !correo.Contains("@"))
        {
            Console.WriteLine(" Correo inválido (debe contener @).");
            return;
        }

        huespedes.Add(new Huesped(nextHuespedId++, nombre, telefono, correo));
        Console.WriteLine(" Huésped agregado exitosamente.");
    }

    public void CrearReserva(int idHuesped, int numeroHabitacion, DateTime entrada, DateTime salida)
    {
        Huesped? huesped = null;
        foreach (var h in huespedes)
        {
            if (h.Id == idHuesped)
            {
                huesped = h;
                break;
            }
        }

        if (huesped == null)
        {
            Console.WriteLine(" Huésped no encontrado.");
            return;
        }

        Habitacion? habitacion = null;
        foreach (var h in habitaciones)
        {
            if (h.Numero == numeroHabitacion)
            {
                habitacion = h;
                break;
            }
        }

        if (habitacion == null)
        {
            Console.WriteLine(" Habitación no encontrada.");
            return;
        }

        if (!habitacion.Disponible)
        {
            Console.WriteLine(" Habitación no disponible.");
            return;
        }

        reservas.Add(new Reserva(nextReservaId++, huesped, habitacion, entrada, salida));
        Console.WriteLine(" Reserva creada exitosamente.");
    }

    public void BuscarHabitacionPorNumero(int numero)
    {
        foreach (var h in habitaciones)
        {
            if (h.Numero == numero)
            {
                Console.WriteLine(h);
                return;
            }
        }
        Console.WriteLine(" Habitación no encontrada.");
    }

    public void BuscarHuespedPorNombre(string nombre)
    {
        nombre = nombre ?? string.Empty;

        bool encontrado = false;
        foreach (var h in huespedes)
        {
            if (h.Nombre.ToLower().Contains(nombre.ToLower()))
            {
                Console.WriteLine(h);
                encontrado = true;
            }
        }

        if (!encontrado)
            Console.WriteLine(" No se encontraron huéspedes.");
    }

    public void ModificarEstadoHabitacion(int numero, bool disponible)
    {
        foreach (var h in habitaciones)
        {
            if (h.Numero == numero)
            {
                h.Disponible = disponible;
                Console.WriteLine($"Estado de habitación {numero} actualizado.");
                return;
            }
        }
        Console.WriteLine(" Habitación no encontrada.");
    }

    public void CancelarReserva(int idReserva)
    {
        foreach (var r in reservas)
        {
            if (r.Id == idReserva)
            {
                if (r.Estado == "Activa")
                {
                    r.Estado = "Cancelada";
                    if (r.Habitacion != null)
                    {
                        r.Habitacion.Disponible = true;
                    }
                    Console.WriteLine($" Reserva #{idReserva} cancelada.");
                }
                else
                {
                    Console.WriteLine($" La reserva #{idReserva} no está activa.");
                }
                return;
            }
        }
        Console.WriteLine(" Reserva no encontrada.");
    }

    public void EliminarHuesped(int id)
    {
        for (int i = 0; i < huespedes.Count; i++)
        {
            if (huespedes[i].Id == id)
            {
                huespedes.RemoveAt(i);
                Console.WriteLine(" Huésped eliminado.");
                return;
            }
        }
        Console.WriteLine(" Huésped no encontrado.");
    }

    public void ListarHabitaciones()
    {
        if (habitaciones.Count == 0)
        {
            Console.WriteLine(" No hay habitaciones registradas.");
            return;
        }

        Console.WriteLine("\n=== LISTA DE HABITACIONES ===");
        foreach (var h in habitaciones)
        {
            Console.WriteLine(h);
        }
    }

    public void ListarHuespedes()
    {
        if (huespedes.Count == 0)
        {
            Console.WriteLine(" No hay huéspedes registrados.");
            return;
        }

        Console.WriteLine("\n=== LISTA DE HUÉSPEDES ===");
        foreach (var h in huespedes)
        {
            Console.WriteLine(h);
        }
    }

    public void ListarReservas()
    {
        if (reservas.Count == 0)
        {
            Console.WriteLine(" No hay reservas registradas.");
            return;
        }

        Console.WriteLine("\n=== LISTA DE RESERVAS ===");
        foreach (var r in reservas)
        {
            Console.WriteLine(r);
        }
    }

    public void ListarReservasActivas()
    {
        bool hayActivas = false;
        Console.WriteLine("\n=== RESERVAS ACTIVAS ===");
        foreach (var r in reservas)
        {
            if (r.Estado == "Activa")
            {
                Console.WriteLine(r);
                hayActivas = true;
            }
        }

        if (!hayActivas)
            Console.WriteLine(" No hay reservas activas.");
    }
}

public class Menu
{
    private HotelService service = new HotelService();

    public void Mostrar()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("                                     ");
            Console.WriteLine("     SISTEMA DE REGISTRO DE HOTEL   ");
            Console.WriteLine("                                      ");
            Console.WriteLine("1.  Agregar habitación");
            Console.WriteLine("2.  Agregar huésped");
            Console.WriteLine("3.  Crear reserva");
            Console.WriteLine("4.  Buscar habitación por número");
            Console.WriteLine("5.  Buscar huésped por nombre");
            Console.WriteLine("6.  Modificar estado de habitación");
            Console.WriteLine("7.  Cancelar reserva");
            Console.WriteLine("8.  Eliminar huésped");
            Console.WriteLine("9.  Listar habitaciones");
            Console.WriteLine("10. Listar huéspedes");
            Console.WriteLine("11. Listar todas las reservas");
            Console.WriteLine("12. Listar reservas activas");
            Console.WriteLine("0.  Salir");
            Console.WriteLine("                                         ");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();
            opcion = opcion ?? "";

            try
            {
                switch (opcion)
                {
                    case "1": AgregarHabitacion(); break;
                    case "2": AgregarHuesped(); break;
                    case "3": CrearReserva(); break;
                    case "4": BuscarHabitacion(); break;
                    case "5": BuscarHuesped(); break;
                    case "6": ModificarHabitacion(); break;
                    case "7": CancelarReserva(); break;
                    case "8": EliminarHuesped(); break;
                    case "9": service.ListarHabitaciones(); break;
                    case "10": service.ListarHuespedes(); break;
                    case "11": service.ListarReservas(); break;
                    case "12": service.ListarReservasActivas(); break;
                    case "0":
                        Console.WriteLine(" Saliendo del sistema...");
                        return;
                    default:
                        Console.WriteLine(" Opción no válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    private void AgregarHabitacion()
    {
        Console.Write("Número: ");
        string? input = Console.ReadLine();
        int num = int.Parse(input ?? "0");

        Console.Write("Tipo (Simple/Doble/Suite): ");
        string tipo = Console.ReadLine() ?? string.Empty;

        Console.Write("Precio: ");
        decimal precio = decimal.Parse(Console.ReadLine() ?? "0");

        service.AgregarHabitacion(num, tipo, precio);
    }

    private void AgregarHuesped()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? string.Empty;

        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine() ?? string.Empty;

        Console.Write("Correo: ");
        string correo = Console.ReadLine() ?? string.Empty;

        service.AgregarHuesped(nombre, telefono, correo);
    }

    private void CrearReserva()
    {
        Console.Write("ID del huésped: ");
        int idHuesped = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Número de habitación: ");
        int numHabitacion = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Fecha entrada (yyyy-MM-dd): ");
        DateTime entrada = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));

        Console.Write("Fecha salida (yyyy-MM-dd): ");
        DateTime salida = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));

        service.CrearReserva(idHuesped, numHabitacion, entrada, salida);
    }

    private void BuscarHabitacion()
    {
        Console.Write("Número de habitación: ");
        int num = int.Parse(Console.ReadLine() ?? "0");
        service.BuscarHabitacionPorNumero(num);
    }

    private void BuscarHuesped()
    {
        Console.Write("Nombre a buscar: ");
        string nombre = Console.ReadLine() ?? string.Empty;
        service.BuscarHuespedPorNombre(nombre);
    }

    private void ModificarHabitacion()
    {
        Console.Write("Número de habitación: ");
        int num = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("¿Disponible? (true/false): ");
        bool disponible = bool.Parse(Console.ReadLine() ?? "true");

        service.ModificarEstadoHabitacion(num, disponible);
    }

    private void CancelarReserva()
    {
        Console.Write("ID de la reserva a cancelar: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        service.CancelarReserva(id);
    }

    private void EliminarHuesped()
    {
        Console.Write("ID del huésped a eliminar: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        service.EliminarHuesped(id);
    }
}