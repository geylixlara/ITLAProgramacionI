
//Geylix Anabel Lara de Jesus 2025-2530
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