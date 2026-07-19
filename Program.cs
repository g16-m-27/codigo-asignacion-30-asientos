using System;

class Program
{
    static void Main(string[] args)
    {
        Atraccion atraccion = new Atraccion();

        int opcion;

        do
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================================");
            Console.WriteLine(" PARQUE DE DIVERSIONES");
            Console.WriteLine(" Sistema de Asignación de 30 Asientos");
            Console.WriteLine("===============================================");
            Console.ResetColor();

            Console.WriteLine("1. Registrar visitante");
            Console.WriteLine("2. Asignar asientos");
            Console.WriteLine("3. Mostrar personas con asiento");
            Console.WriteLine("4. Mostrar personas en espera");
            Console.WriteLine("5. Mostrar reporte");
            Console.WriteLine("6. Finalizar recorrido");
            Console.WriteLine("7. Salir");

            Console.Write("\nSeleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1:

                    Console.WriteLine("===== REGISTRO DE VISITANTE =====");

                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Cédula: ");
                    string cedula = Console.ReadLine();

                    atraccion.RegistrarVisitante(nombre, cedula);

                    break;

                case 2:

                    Console.WriteLine("===== ASIGNACIÓN DE ASIENTOS =====");

                    atraccion.AsignarAsientos();

                    break;

                case 3:

                    atraccion.MostrarAsientos();

                    break;

                case 4:

                    atraccion.MostrarCola();

                    break;

                case 5:

                    atraccion.MostrarEstado();

                    break;

                case 6:

                    atraccion.FinalizarRecorrido();

                    break;

                case 7:

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Gracias por utilizar el sistema.");
                    Console.ResetColor();

                    break;

                default:

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida.");
                    Console.ResetColor();

                    break;
            }

            if (opcion != 7)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 7);
    }
}