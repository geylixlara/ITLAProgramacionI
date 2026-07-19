
//Geylix Anabel Lara de Jesus 2025-2530
public abstract class Habitacion

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

        public abstract string Tipo { get; }

        public override string ToString()
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

        public override string Tipo => "Simple";
    }

    public class HabitacionDoble : Habitacion
    {
        public HabitacionDoble(int numero, decimal precio)
            : base(numero, precio)
        {
        }

        public override string Tipo => "Doble";
    }

    public class HabitacionSuite : Habitacion
    {
        public HabitacionSuite(int numero, decimal precio)
            : base(numero, precio)
        {
        }

        public override string Tipo => "Suite";
    }
