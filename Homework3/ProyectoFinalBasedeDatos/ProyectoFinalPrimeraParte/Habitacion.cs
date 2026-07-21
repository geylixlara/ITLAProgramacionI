
//Geylix Anabel Lara de Jesus 2025-2530
public class Habitacion

    {
        public int Numero { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }

        public Habitacion(int numero, decimal precio)
        {
            Numero = numero;
            Precio = precio;
            Disponible = true;
        }

        public string Tipo { get; }

        public string ToString()
        {
            return $"Habitación {Numero} - {Tipo} - ${Precio} - {(Disponible ? "Disponible" : "Ocupada")}";
        }
    }

    public class HabitacionSimple : Habitacion
    {
        public HabitacionSimple(int numero, decimal precio)
            : base(numero, precio)
        {
        }

        public string Tipo => "Simple";
    }

    public class HabitacionDoble : Habitacion
    {
        public HabitacionDoble(int numero, decimal precio)
            : base(numero, precio)
        {
        }

        public string Tipo => "Doble";
    }

    public class HabitacionSuite : Habitacion
    {
        public HabitacionSuite(int numero, decimal precio)
            : base(numero, precio)
        {
        }

        public string Tipo => "Suite";
    }
