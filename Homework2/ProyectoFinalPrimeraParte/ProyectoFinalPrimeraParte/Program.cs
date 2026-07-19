public class Habitacion
{
    public int Numero { get; set; }
    public string Tipo { get; set; }
    public decimal Precio { get; set; }
    public bool Disponible { get; set; }

    public Habitacion(int numero, string tipo, decimal precio)
    {
        Numero = numero;
        Tipo = tipo;
        Precio = precio;
        Disponible = true;  
    }

    public override string ToString()
    {

        return $"Habitacion {Numero} - {Tipo} - ${Precio} - {(Disponible ? "Disponible" : "Ocupada")}";
    }
}
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