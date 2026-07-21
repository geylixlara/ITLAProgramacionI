
//Geylix Anabel Lara de Jesus 2025-2530
using Microsoft.Data.SqlClient;
public class HotelService
    {
    private DBConnection db = new DBConnection();

    private List<Habitacion> habitaciones = new List<Habitacion>();
        private List<Huesped> huespedes = new List<Huesped>();
        private List<Reserva> reservas = new List<Reserva>();
        private int nextHuespedId = 1;
        private int nextReservaId = 1;
    public void AgregarHabitacion(int numero, string tipo, decimal precio)
    {
        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();

            string verificar =
                "SELECT COUNT(*) FROM Habitacion WHERE Numero = @Numero";

            SqlCommand check = new SqlCommand(verificar, connection);
            check.Parameters.AddWithValue("@Numero", numero);

            int existe = (int)check.ExecuteScalar();

            if (existe > 0)
            {
                Console.WriteLine("Ya existe una habitación con ese número.");
                return;
            }


            string query =
            @"INSERT INTO Habitacion
        (Numero, Precio, Disponible)
        VALUES
        (@Numero,@Precio,1)";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Numero", numero);
            cmd.Parameters.AddWithValue("@Precio", precio);

            cmd.ExecuteNonQuery();

            Console.WriteLine("Habitación agregada exitosamente.");
        }
    }

    public void AgregarHuesped(string nombre, string telefono, string correo)
    {
        if (string.IsNullOrEmpty(nombre))
        {
            Console.WriteLine("El nombre es obligatorio.");
            return;
        }


        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();


            string query =
            @"INSERT INTO Huesped
        (Nombre,Telefono,Correo)
        VALUES
        (@Nombre,@Telefono,@Correo)";


            SqlCommand cmd = new SqlCommand(query, connection);


            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Telefono", telefono);
            cmd.Parameters.AddWithValue("@Correo", correo);


            cmd.ExecuteNonQuery();


            Console.WriteLine("Huésped agregado exitosamente.");
        }
    }

    public void CrearReserva(int idHuesped, int numeroHabitacion, DateTime entrada, DateTime salida)
    {

        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();


            string verificar =
            @"SELECT Disponible 
          FROM Habitacion 
          WHERE Numero=@Numero";


            SqlCommand check =
                new SqlCommand(verificar, connection);


            check.Parameters.AddWithValue("@Numero", numeroHabitacion);


            object resultado = check.ExecuteScalar();


            if (resultado == null)
            {
                Console.WriteLine("Habitación no encontrada.");
                return;
            }


            if (!(bool)resultado)
            {
                Console.WriteLine("Habitación no disponible.");
                return;
            }



            string insertar =
            @"INSERT INTO Reserva
        (IdHuesped,NumeroHabitacion,FechaEntrada,FechaSalida,Estado)

        VALUES

        (@IdHuesped,@NumeroHabitacion,@Entrada,@Salida,'Activa')";


            SqlCommand cmd =
                new SqlCommand(insertar, connection);



            cmd.Parameters.AddWithValue("@IdHuesped", idHuesped);
            cmd.Parameters.AddWithValue("@NumeroHabitacion", numeroHabitacion);
            cmd.Parameters.AddWithValue("@Entrada", entrada);
            cmd.Parameters.AddWithValue("@Salida", salida);


            cmd.ExecuteNonQuery();



            string actualizar =
            @"UPDATE Habitacion
          SET Disponible=0
          WHERE Numero=@Numero";


            SqlCommand update =
                new SqlCommand(actualizar, connection);


            update.Parameters.AddWithValue("@Numero", numeroHabitacion);


            update.ExecuteNonQuery();



            Console.WriteLine("Reserva creada exitosamente.");
        }
    }

    public void BuscarHabitacionPorNumero(int numero)
    {
        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();

            string query =
            @"SELECT *
          FROM Habitacion
          WHERE Numero = @Numero";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Numero", numero);


            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                Console.WriteLine(
                    $"Número: {reader["Numero"]} | " +
                    $"Precio: {reader["Precio"]} | " +
                    $"Disponible: {reader["Disponible"]}"
                );
            }
            else
            {
                Console.WriteLine("Habitación no encontrada.");
            }
        }
    }

    public void BuscarHuespedPorNombre(string nombre)
    {
        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();


            string query =
            @"SELECT *
          FROM Huesped
          WHERE Nombre LIKE @Nombre";


            SqlCommand cmd =
                new SqlCommand(query, connection);


            cmd.Parameters.AddWithValue(
                "@Nombre",
                "%" + nombre + "%"
            );


            SqlDataReader reader = cmd.ExecuteReader();


            bool encontrado = false;


            while (reader.Read())
            {
                encontrado = true;

                Console.WriteLine(
                    $"ID: {reader["Id"]} | " +
                    $"Nombre: {reader["Nombre"]} | " +
                    $"Teléfono: {reader["Telefono"]} | " +
                    $"Correo: {reader["Correo"]}"
                );
            }


            if (!encontrado)
            {
                Console.WriteLine("No se encontraron huéspedes.");
            }
        }
    }

    public void ModificarEstadoHabitacion(int numero, bool disponible)
    {
        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();


            string query =
            @"UPDATE Habitacion
          SET Disponible=@Disponible
          WHERE Numero=@Numero";


            SqlCommand cmd =
                new SqlCommand(query, connection);


            cmd.Parameters.AddWithValue("@Disponible", disponible);
            cmd.Parameters.AddWithValue("@Numero", numero);


            int filas = cmd.ExecuteNonQuery();


            if (filas > 0)
            {
                Console.WriteLine(
                    $"Estado de habitación {numero} actualizado."
                );
            }
            else
            {
                Console.WriteLine("Habitación no encontrada.");
            }
        }
    }

    public void CancelarReserva(int idReserva)
    {
        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();


            string buscar =
            @"SELECT NumeroHabitacion
          FROM Reserva
          WHERE Id=@Id
          AND Estado='Activa'";


            SqlCommand cmdBuscar =
                new SqlCommand(buscar, connection);


            cmdBuscar.Parameters.AddWithValue("@Id", idReserva);


            object resultado = cmdBuscar.ExecuteScalar();


            if (resultado == null)
            {
                Console.WriteLine("Reserva no encontrada o ya cancelada.");
                return;
            }


            int habitacion =
                Convert.ToInt32(resultado);



            string cancelar =
            @"UPDATE Reserva
          SET Estado='Cancelada'
          WHERE Id=@Id";


            SqlCommand cmdCancelar =
                new SqlCommand(cancelar, connection);


            cmdCancelar.Parameters.AddWithValue("@Id", idReserva);


            cmdCancelar.ExecuteNonQuery();



            string liberar =
            @"UPDATE Habitacion
          SET Disponible=1
          WHERE Numero=@Numero";


            SqlCommand cmdLiberar =
                new SqlCommand(liberar, connection);


            cmdLiberar.Parameters.AddWithValue("@Numero", habitacion);


            cmdLiberar.ExecuteNonQuery();


            Console.WriteLine($"Reserva #{idReserva} cancelada.");
        }
    }

    public void EliminarHuesped(int id)
    {
        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();


            string verificar =
            @"SELECT COUNT(*)
          FROM Reserva
          WHERE IdHuesped=@Id";


            SqlCommand check =
                new SqlCommand(verificar, connection);


            check.Parameters.AddWithValue("@Id", id);


            int reservas =
                (int)check.ExecuteScalar();


            if (reservas > 0)
            {
                Console.WriteLine(
                "No se puede eliminar porque tiene reservas registradas."
                );

                return;
            }



            string query =
            @"DELETE FROM Huesped
          WHERE Id=@Id";


            SqlCommand cmd =
                new SqlCommand(query, connection);


            cmd.Parameters.AddWithValue("@Id", id);


            int filas = cmd.ExecuteNonQuery();


            if (filas > 0)
            {
                Console.WriteLine("Huésped eliminado.");
            }
            else
            {
                Console.WriteLine("Huésped no encontrado.");
            }
        }
    }

    public void ListarHabitaciones()
    {
        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();


            string query = "SELECT * FROM Habitacion";


            SqlCommand cmd = new SqlCommand(query, connection);


            SqlDataReader reader = cmd.ExecuteReader();


            Console.WriteLine("\n LISTA DE HABITACIONES");


            while (reader.Read())
            {
                Console.WriteLine(
                    $"Número: {reader["Numero"]} | " +
                    $"Precio: {reader["Precio"]} | " +
                    $"Disponible: {reader["Disponible"]}"
                );
            }
        }
    }

    public void ListarHuespedes()
    {
        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();


            string query = "SELECT * FROM Huesped";


            SqlCommand cmd = new SqlCommand(query, connection);


            SqlDataReader reader = cmd.ExecuteReader();



            Console.WriteLine("\n LISTA DE HUÉSPEDES");


            while (reader.Read())
            {
                Console.WriteLine(
                $"ID: {reader["Id"]} | " +
                $"Nombre: {reader["Nombre"]} | " +
                $"Teléfono: {reader["Telefono"]} | " +
                $"Correo: {reader["Correo"]}"
                );
            }
        }
    }

    public void ListarReservas()
    {
        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();


            string query =
            @"SELECT 
        R.Id,
        H.Nombre,
        R.NumeroHabitacion,
        R.FechaEntrada,
        R.FechaSalida,
        R.Estado

        FROM Reserva R

        INNER JOIN Huesped H
        ON R.IdHuesped = H.Id";


            SqlCommand cmd =
                new SqlCommand(query, connection);


            SqlDataReader reader = cmd.ExecuteReader();



            Console.WriteLine("\n LISTA DE RESERVAS");


            while (reader.Read())
            {
                Console.WriteLine(
                $"Reserva: {reader["Id"]} | " +
                $"Huésped: {reader["Nombre"]} | " +
                $"Habitación: {reader["NumeroHabitacion"]} | " +
                $"Estado: {reader["Estado"]}"
                );
            }
        }
    }

    public void ListarReservasActivas()
    {
        using (SqlConnection connection = db.GetConnection())
        {
            connection.Open();


            string query =
            @"SELECT
            R.Id,
            H.Nombre,
            R.NumeroHabitacion,
            R.FechaEntrada,
            R.FechaSalida,
            R.Estado

          FROM Reserva R

          INNER JOIN Huesped H
          ON R.IdHuesped = H.Id

          WHERE R.Estado='Activa'";


            SqlCommand cmd =
                new SqlCommand(query, connection);


            SqlDataReader reader =
                cmd.ExecuteReader();



            bool existe = false;


            Console.WriteLine("\n RESERVAS ACTIVAS");


            while (reader.Read())
            {
                existe = true;

                Console.WriteLine(
                $"ID: {reader["Id"]} | " +
                $"Huésped: {reader["Nombre"]} | " +
                $"Habitación: {reader["NumeroHabitacion"]} | " +
                $"Entrada: {reader["FechaEntrada"]} | " +
                $"Salida: {reader["FechaSalida"]}"
                );
            }


            if (!existe)
            {
                Console.WriteLine("No hay reservas activas.");
            }
        }
    }
}
