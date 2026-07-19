
//Geylix Anabel Lara de Jesus 2025-2530
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Hotel Registration System";
        Menu menu = new Menu();
        menu.Mostrar();
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