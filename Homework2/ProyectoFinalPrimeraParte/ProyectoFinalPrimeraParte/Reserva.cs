
//Geylix Anabel Lara de Jesus 2025-2530
public class Reserva
    {
        public int Id { get; set; }
        public Huesped Huesped { get; set; }
        public Habitacion Habitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Estado { get; set; } = "Activa";

        public Reserva(int id, Huesped huesped, Habitacion habitacion, DateTime entrada, DateTime salida)
        {
            Id = id;
            Huesped = huesped;
            Habitacion = habitacion;
            FechaEntrada = entrada;
            FechaSalida = salida;

            Habitacion.Disponible = false;
        }

        public override string ToString()
        {
            return $"Reserva #{Id} - {Huesped.Nombre} - Hab.{Habitacion.Numero} - {Estado}";
        }
    }