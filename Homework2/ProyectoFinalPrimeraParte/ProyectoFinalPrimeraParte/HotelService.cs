
    public class HotelService
    {
        private List<Habitacion> habitaciones = new List<Habitacion>();
        private List<Huesped> huespedes = new List<Huesped>();
        private List<Reserva> reservas = new List<Reserva>();
        private int nextHuespedId = 1;
        private int nextReservaId = 1;

        public void AgregarHabitacion(int numero, string tipo, decimal precio)
        {
            foreach (var h in habitaciones)
            {
                if (h.Numero == numero)
                {
                    Console.WriteLine("Ya existe una habitación con ese número.");
                    return;
                }
            }

            Habitacion nueva;

            switch ((tipo ?? "").Trim().ToLower())
            {
                case "simple":
                    nueva = new HabitacionSimple(numero, precio);
                    break;

                case "doble":
                    nueva = new HabitacionDoble(numero, precio);
                    break;

                case "suite":
                    nueva = new HabitacionSuite(numero, precio);
                    break;

                default:
                    Console.WriteLine("Tipo inválido. Use Simple, Doble o Suite.");
                    return;
            }

            habitaciones.Add(nueva);
            Console.WriteLine("Habitación agregada exitosamente.");
        }

        public void AgregarHuesped(string nombre, string telefono, string correo)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("El nombre es obligatorio.");
                return;
            }

            if (string.IsNullOrEmpty(correo) || !correo.Contains("@"))
            {
                Console.WriteLine("Correo inválido (debe contener @).");
                return;
            }

            huespedes.Add(new Huesped(nextHuespedId++, nombre, telefono, correo));
            Console.WriteLine("Huésped agregado exitosamente.");
        }

        public void CrearReserva(int idHuesped, int numeroHabitacion, DateTime entrada, DateTime salida)
        {
            Huesped? huesped = huespedes.Find(h => h.Id == idHuesped);

            if (huesped == null)
            {
                Console.WriteLine("Huésped no encontrado.");
                return;
            }

            Habitacion? habitacion = habitaciones.Find(h => h.Numero == numeroHabitacion);

            if (habitacion == null)
            {
                Console.WriteLine("Habitación no encontrada.");
                return;
            }

            if (!habitacion.Disponible)
            {
                Console.WriteLine("Habitación no disponible.");
                return;
            }

            reservas.Add(new Reserva(nextReservaId++, huesped, habitacion, entrada, salida));
            Console.WriteLine("Reserva creada exitosamente.");
        }

        public void BuscarHabitacionPorNumero(int numero)
        {
            var h = habitaciones.Find(x => x.Numero == numero);

            if (h != null)
                Console.WriteLine(h);
            else
                Console.WriteLine("Habitación no encontrada.");
        }

        public void BuscarHuespedPorNombre(string nombre)
        {
            bool encontrado = false;

            foreach (var h in huespedes)
            {
                if (h.Nombre.ToLower().Contains((nombre ?? "").ToLower()))
                {
                    Console.WriteLine(h);
                    encontrado = true;
                }
            }

            if (!encontrado)
                Console.WriteLine("No se encontraron huéspedes.");
        }

        public void ModificarEstadoHabitacion(int numero, bool disponible)
        {
            var h = habitaciones.Find(x => x.Numero == numero);

            if (h == null)
            {
                Console.WriteLine("Habitación no encontrada.");
                return;
            }

            h.Disponible = disponible;
            Console.WriteLine($"Estado de habitación {numero} actualizado.");
        }

        public void CancelarReserva(int idReserva)
        {
            var r = reservas.Find(x => x.Id == idReserva);

            if (r == null)
            {
                Console.WriteLine("Reserva no encontrada.");
                return;
            }

            if (r.Estado != "Activa")
            {
                Console.WriteLine($"La reserva #{idReserva} no está activa.");
                return;
            }

            r.Estado = "Cancelada";
            r.Habitacion.Disponible = true;

            Console.WriteLine($"Reserva #{idReserva} cancelada.");
        }

        public void EliminarHuesped(int id)
        {
            var h = huespedes.Find(x => x.Id == id);

            if (h == null)
            {
                Console.WriteLine("Huésped no encontrado.");
                return;
            }

            huespedes.Remove(h);
            Console.WriteLine("Huésped eliminado.");
        }

        public void ListarHabitaciones()
        {
            if (habitaciones.Count == 0)
            {
                Console.WriteLine("No hay habitaciones registradas.");
                return;
            }

            Console.WriteLine("\n   LISTA DE HABITACIONES    ");

            foreach (var h in habitaciones)
                Console.WriteLine(h);
        }

        public void ListarHuespedes()
        {
            if (huespedes.Count == 0)
            {
                Console.WriteLine("No hay huéspedes registrados.");
                return;
            }

            Console.WriteLine("\n    LISTA DE HUÉSPEDES    ");

            foreach (var h in huespedes)
                Console.WriteLine(h);
        }

        public void ListarReservas()
        {
            if (reservas.Count == 0)
            {
                Console.WriteLine("No hay reservas registradas.");
                return;
            }

            Console.WriteLine("\n    LISTA DE RESERVAS    ");

            foreach (var r in reservas)
                Console.WriteLine(r);
        }

        public void ListarReservasActivas()
        {
            var activas = reservas.FindAll(r => r.Estado == "Activa");

            Console.WriteLine("\n    RESERVAS ACTIVAS    ");

            if (activas.Count == 0)
            {
                Console.WriteLine("No hay reservas activas.");
                return;
            }

            foreach (var r in activas)
                Console.WriteLine(r);
        }
    }
