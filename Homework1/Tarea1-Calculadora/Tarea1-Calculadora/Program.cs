double num1, num2, resultado;
int opcion, operacion;
bool salir = false;

while (!salir)
{
    Console.WriteLine("        MENU PRINCIPAL");
    Console.WriteLine("                            ");
    Console.WriteLine("1. Calculadora");
    Console.WriteLine("2. Verificar si un estudiante aprobo");
    Console.WriteLine("3. Salir");
    Console.Write("Seleccione una opcion: ");
    opcion = Convert.ToInt32(Console.ReadLine());

    if (opcion == 1)
    {
        Console.Write("Primer numero: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Segundo numero: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("1. Sumar  2. Restar  3. Multiplicar  4. Dividir");
        Console.Write("Operacion: ");
        operacion = Convert.ToInt32(Console.ReadLine());

        if (operacion == 1)
        {
            resultado = num1 + num2;
            Console.WriteLine("Resultado: " + resultado);
        }
        else if (operacion == 2)
        {
            resultado = num1 - num2;
            Console.WriteLine("Resultado: " + resultado);
        }
        else if (operacion == 3)
        {
            resultado = num1 * num2;
            Console.WriteLine("Resultado: " + resultado);
        }
        else if (operacion == 4)
        {
            resultado = num1 / num2;
            Console.WriteLine("Resultado: " + resultado);
        }
        else
            Console.WriteLine("Operacion no valida.");
    }
    else if (opcion == 2)
    {
        double calificacion;
        Console.Write("Calificacion del estudiante (0-100): ");
        calificacion = Convert.ToDouble(Console.ReadLine());

        if (calificacion >= 70)
            Console.WriteLine("APROBADO");
        else
            Console.WriteLine("NO APROBADO");
    }
    else if (opcion == 3)
    {
        salir = true;
        Console.WriteLine("Bye Bye!");
    }
    else
        Console.WriteLine("Opcion no valida.");

    if (!salir)
    {
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}