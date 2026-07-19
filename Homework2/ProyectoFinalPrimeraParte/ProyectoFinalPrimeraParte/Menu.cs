// Geylix Anabel Lara de Jesus 2025-2530v
public class Menu
{
    private HotelService service = new HotelService();

    public void Mostrar()
    {
        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine("   SISTEMA DE REGISTRO DE HOTEL  ");
            System.Console.WriteLine("1. Agregar habitación");
            System.Console.WriteLine("2. Agregar huésped");
            System.Console.WriteLine("3. Crear reserva");
            System.Console.WriteLine("4. Buscar habitación por número");
            System.Console.WriteLine("5. Buscar huésped por nombre");
            System.Console.WriteLine("6. Modificar estado de habitación");
            System.Console.WriteLine("7. Eliminar huésped");
            System.Console.WriteLine("8. Listar habitaciones");
            System.Console.WriteLine("9. Listar huéspedes");
            System.Console.WriteLine("10. Listar reservas");
            System.Console.WriteLine("0. Salir");
            System.Console.Write("Seleccione una opción: ");

            string opcion = System.Console.ReadLine();

            try
            {
                switch (opcion)
                {
                    case "1":
                        AgregarHabitacion();
                        break;
                    case "2":
                        AgregarHuesped();
                        break;
                    case "3":
                        CrearReserva();
                        break;
                    case "4":
                        BuscarHabitacion();
                        break;
                    case "5":
                        BuscarHuesped();
                        break;
                    case "6":
                        ModificarHabitacion();
                        break;
                    case "7":
                        EliminarHuesped();
                        break;
                    case "8":
                        service.ListarHabitaciones();
                        break;
                    case "9":
                        service.ListarHuespedes();
                        break;
                    case "10":
                        service.ListarReservas();
                        break;
                    case "0":
                        System.Console.WriteLine("Saliendo del sistema...");
                        return;
                    default:
                        System.Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }

            System.Console.WriteLine("\nPresione cualquier tecla para continuar...");
            System.Console.ReadKey();
        }
    }

    private void AgregarHabitacion()
    {
        System.Console.Write("Número: ");
        int num = int.Parse(System.Console.ReadLine());
        System.Console.Write("Tipo (Simple/Doble/Suite): ");
        string tipo = System.Console.ReadLine();
        System.Console.Write("Precio: ");
        decimal precio = decimal.Parse(System.Console.ReadLine());
        service.AgregarHabitacion(num, tipo, precio);
    }

    private void AgregarHuesped()
    {
        System.Console.Write("Nombre: ");
        string nombre = System.Console.ReadLine();
        System.Console.Write("Teléfono: ");
        string telefono = System.Console.ReadLine();
        System.Console.Write("Correo: ");
        string correo = System.Console.ReadLine();
        service.AgregarHuesped(nombre, telefono, correo);
    }

    private void CrearReserva()
    {
        System.Console.Write("ID del huésped: ");
        int idHuesped = int.Parse(System.Console.ReadLine());
        System.Console.Write("Número de habitación: ");
        int numHabitacion = int.Parse(System.Console.ReadLine());
        System.Console.Write("Fecha entrada (yyyy-MM-dd): ");
        System.DateTime entrada = System.DateTime.Parse(System.Console.ReadLine());
        System.Console.Write("Fecha salida (yyyy-MM-dd): ");
        System.DateTime salida = System.DateTime.Parse(System.Console.ReadLine());
        service.CrearReserva(idHuesped, numHabitacion, entrada, salida);
    }

    private void BuscarHabitacion()
    {
        System.Console.Write("Número de habitación: ");
        int num = int.Parse(System.Console.ReadLine());
        service.BuscarHabitacionPorNumero(num);
    }

    private void BuscarHuesped()
    {
        System.Console.Write("Nombre a buscar: ");
        string nombre = System.Console.ReadLine();
        service.BuscarHuespedPorNombre(nombre);
    }

    private void ModificarHabitacion()
    {
        System.Console.Write("Número de habitación: ");
        int num = int.Parse(System.Console.ReadLine());
        System.Console.Write("¿Disponible? (true/false): ");
        bool disponible = bool.Parse(System.Console.ReadLine());
        service.ModificarEstadoHabitacion(num, disponible);
    }

    private void EliminarHuesped()
    {
        System.Console.Write("ID del huésped a eliminar: ");
        int id = int.Parse(System.Console.ReadLine());
        service.EliminarHuesped(id);
    }
}