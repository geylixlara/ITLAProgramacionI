// Geylix Anabel Lara de Jesus 2025-2530v
public class Reserva
{
    public int Id { get; set; }
    public Huesped Huesped { get; set; }
    public Habitacion Habitacion { get; set; }
    public System.DateTime FechaEntrada { get; set; }
    public System.DateTime FechaSalida { get; set; }
    public string Estado { get; set; }

    public Reserva(int id, Huesped huesped, Habitacion habitacion, System.DateTime entrada, System.DateTime salida)
    {
        Id = id;
        Huesped = huesped;
        Habitacion = habitacion;
        FechaEntrada = entrada;
        FechaSalida = salida;
        Estado = "Activa";
        habitacion.Disponible = false; // Al reservar, la habitación se ocupa
    }

    public override string ToString()
    {
        return $"Reserva #{Id} - {Huesped.Nombre} - Hab.{Habitacion.Numero} - {Estado}";
    }
}