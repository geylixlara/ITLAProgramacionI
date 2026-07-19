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
