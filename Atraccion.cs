using System;
using System.Collections.Generic;

public class Atraccion
{
    private const int CAPACIDAD = 30;

    // Cola de espera (FIFO)
    private Queue<Visitante> colaEspera;

    // Lista de personas que ya tienen asiento
    private List<Visitante> asientosOcupados;

    public Atraccion()
    {
        colaEspera = new Queue<Visitante>();
        asientosOcupados = new List<Visitante>();
    }

    // Registrar visitante
    public void RegistrarVisitante(string nombre, string cedula)
    {
        Visitante visitante = new Visitante(nombre, cedula);
        colaEspera.Enqueue(visitante);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nVisitante registrado correctamente.");
        Console.ResetColor();
    }

    // Asignar asientos disponibles
    public void AsignarAsientos()
    {
        if (colaEspera.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNo existen visitantes en espera.");
            Console.ResetColor();
            return;
        }

        while (asientosOcupados.Count < CAPACIDAD && colaEspera.Count > 0)
        {
            Visitante visitante = colaEspera.Dequeue();

            visitante.NumeroAsiento = asientosOcupados.Count + 1;

            asientosOcupados.Add(visitante);

            Console.WriteLine(
                $"Asiento {visitante.NumeroAsiento} asignado a {visitante.Nombre}");
        }

        if (asientosOcupados.Count == CAPACIDAD)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nTodos los asientos han sido ocupados.");
            Console.ResetColor();
        }
    }

    // Mostrar personas con asiento
    public void MostrarAsientos()
    {
        Console.WriteLine("\n========== PERSONAS CON ASIENTO ==========");

        if (asientosOcupados.Count == 0)
        {
            Console.WriteLine("No existen personas con asiento.");
            return;
        }

        foreach (Visitante visitante in asientosOcupados)
        {
            Console.WriteLine(visitante);
        }
    }

    // Mostrar cola
    public void MostrarCola()
    {
        Console.WriteLine("\n========== PERSONAS EN ESPERA ==========");

        if (colaEspera.Count == 0)
        {
            Console.WriteLine("No existen personas esperando.");
            return;
        }

        int posicion = 1;

        foreach (Visitante visitante in colaEspera)
        {
            Console.WriteLine($"{posicion}. {visitante.Nombre} - {visitante.Cedula}");
            posicion++;
        }
    }

    // Reportería
    public void MostrarEstado()
    {
        Console.WriteLine("\n========== REPORTE ==========");

        Console.WriteLine($"Asientos ocupados : {asientosOcupados.Count}");

        Console.WriteLine($"Asientos disponibles : {CAPACIDAD - asientosOcupados.Count}");

        Console.WriteLine($"Personas en espera : {colaEspera.Count}");
    }

    // Finalizar recorrido
    public void FinalizarRecorrido()
    {
        if (asientosOcupados.Count == 0)
        {
            Console.WriteLine("\nNo existe ningún recorrido en ejecución.");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nFinalizando recorrido...");
        Console.ResetColor();

        asientosOcupados.Clear();

        Console.WriteLine("Todos los asientos fueron liberados.");

        Console.WriteLine("\nAsignando automáticamente nuevos visitantes...");

        AsignarAsientos();
    }
}