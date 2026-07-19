public class Habitacion
{
    public int Numero { get; set; }
    public string Tipo { get; set; }
    public decimal Precio { get; set; }
    public bool Disponible { get; set; }

    public Habitacion(int numero, string tipo, decimal precio)
    {
        Numero = numero;
        Tipo = tipo;
        Precio = precio;
        Disponible = true;  
    }

    public override string ToString()
    {

        return $"Habitacion {Numero} - {Tipo} - ${Precio} - {(Disponible ? "Disponible" : "Ocupada")}";
    }
}
public class Huesped
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }

    public Huesped(int id, string nombre, string telefono, string correo)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
        Correo = correo;
    }

    public override string ToString()
    {
        return $"ID: {Id} - {Nombre} - {Telefono} - {Correo}";
    }
}
public class Reserva
{
    public int Id { get; set; }
    public Huesped Huesped { get; set; }
    public Habitacion Habitacion { get; set; }
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
    public string Estado { get; set; }

    public Reserva(int id, Huesped huesped, Habitacion habitacion, DateTime entrada, DateTime salida)
    {
        Id = id;
        Huesped = huesped;
        Habitacion = habitacion;
        FechaEntrada = entrada;
        FechaSalida = salida;
        Estado = "Activa";
        habitacion.Disponible = false;
    }

    public override string ToString()
    {
        return $"Reserva #{Id} - {Huesped.Nombre} - Hab.{Habitacion.Numero} - {Estado}";
    }
}

public class HotelService
{
    private List<Habitacion> habitaciones = new List<Habitacion>();
    private List<Huesped> huespedes = new List<Huesped>();

    public void AgregarHabitacion(int numero, string tipo, decimal precio)
    {
        habitaciones.Add(new Habitacion(numero, tipo, precio));
        Console.WriteLine("Habitación agregada.");
    }

    public void AgregarHuesped(string nombre, string telefono, string correo)
    {
        huespedes.Add(new Huesped(1, nombre, telefono, correo));
        Console.WriteLine("Huésped agregado.");
    }
}
public void ListarHabitaciones()
{
    foreach (var h in habitaciones)
    {
        Console.WriteLine(h);
    }
}

public void ListarHuespedes()
{
    foreach (var h in huespedes)
    {
        Console.WriteLine(h);
    }
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
    Console.WriteLine("No encontrada.");
}

public void BuscarHuespedPorNombre(string nombre)
{
    foreach (var h in huespedes)
    {
        if (h.Nombre.ToLower().Contains(nombre.ToLower()))
        {
            Console.WriteLine(h);
        }
    }
}
public void ModificarEstadoHabitacion(int numero, bool disponible)
{
    foreach (var h in habitaciones)
    {
        if (h.Numero == numero)
        {
            h.Disponible = disponible;
            Console.WriteLine($"Estado actualizado.");
            return;
        }
    }
    Console.WriteLine("No encontrada.");
}

public void EliminarHuesped(int id)
{
    for (int i = 0; i < huespedes.Count; i++)
    {
        if (huespedes[i].Id == id)
        {
            huespedes.RemoveAt(i);
            Console.WriteLine("Eliminado.");
            return;
        }
    }
    Console.WriteLine("No encontrado.");
}
private int nextReservaId = 1;

public void CrearReserva(int idHuesped, int numeroHabitacion, DateTime entrada, DateTime salida)
{
    Huesped huesped = null;
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
        Console.WriteLine("Huésped no encontrado.");
        return;
    }

    Habitacion habitacion = null;
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
        Console.WriteLine("Habitación no disponible.");
        return;
    }

    reservas.Add(new Reserva(nextReservaId++, huesped, habitacion, entrada, salida));
    Console.WriteLine("Reserva creada.");
}