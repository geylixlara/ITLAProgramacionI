//Geylix Anabel Lara de Jesus 2025-2530
class Program
{
    static List<int> numeros = new List<int>();
    static List<string> tipos = new List<string>();
    static List<decimal> precios = new List<decimal>();

    static List<string> huespedes = new List<string>();
    static List<string> telefonos = new List<string>();
    static List<string> correos = new List<string>();

    static void Main(string[] args)
    {
        int opcion = -1;

        while (opcion != 0)
        {
            Console.Clear();

            Console.WriteLine("===== SISTEMA DE REGISTRO DE HOTEL =====");
            Console.WriteLine("1. Agregar habitación");
            Console.WriteLine("2. Agregar huésped");
            Console.WriteLine("3. Mostrar habitaciones");
            Console.WriteLine("4. Mostrar huéspedes");
            Console.WriteLine("0. Salir");

            Console.Write("\nOpción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarHabitacion();
                    break;

                case 2:
                    AgregarHuesped();
                    break;

                case 3:
                    MostrarHabitaciones();
                    break;

                case 4:
                    MostrarHuespedes();
                    break;

                case 0:
                    Console.WriteLine("Hasta luego.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void AgregarHabitacion()
    {
        Console.Write("Número: ");
        numeros.Add(Convert.ToInt32(Console.ReadLine()));

        Console.Write("Tipo: ");
        tipos.Add(Console.ReadLine());

        Console.Write("Precio: ");
        precios.Add(Convert.ToDecimal(Console.ReadLine()));

        Console.WriteLine("\nHabitación agregada correctamente.");
    }

    static void AgregarHuesped()
    {
        Console.Write("Nombre: ");
        huespedes.Add(Console.ReadLine());

        Console.Write("Teléfono: ");
        telefonos.Add(Console.ReadLine());

        Console.Write("Correo: ");
        correos.Add(Console.ReadLine());

        Console.WriteLine("\nHuésped agregado correctamente.");
    }

    static void MostrarHabitaciones()
    {
        Console.WriteLine("\n=== HABITACIONES ===");

        if (numeros.Count == 0)
        {
            Console.WriteLine("No hay habitaciones registradas.");
            return;
        }

        for (int i = 0; i < numeros.Count; i++)
        {
            Console.WriteLine("Número: " + numeros[i]);
            Console.WriteLine("Tipo: " + tipos[i]);
            Console.WriteLine("Precio: RD$" + precios[i]);
            Console.WriteLine("---------------------------");
        }
    }

    static void MostrarHuespedes()
    {
        Console.WriteLine("\n=== HUÉSPEDES ===");

        if (huespedes.Count == 0)
        {
            Console.WriteLine("No hay huéspedes registrados.");
            return;
        }

        for (int i = 0; i < huespedes.Count; i++)
        {
            Console.WriteLine("Nombre: " + huespedes[i]);
            Console.WriteLine("Teléfono: " + telefonos[i]);
            Console.WriteLine("Correo: " + correos[i]);
            Console.WriteLine("---------------------------");
        }
    }
}