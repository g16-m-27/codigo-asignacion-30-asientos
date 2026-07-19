using System;

public class Visitante
{
    // Propiedades del visitante
    public string Nombre { get; set; }

    public string Cedula { get; set; }

    public int NumeroAsiento { get; set; }

    // Constructor
    public Visitante(string nombre, string cedula)
    {
        Nombre = nombre;
        Cedula = cedula;
        NumeroAsiento = 0; // 0 significa que aún no tiene asiento
    }

    // Muestra la información del visitante
    public override string ToString()
    {
        if (NumeroAsiento == 0)
        {
            return $"Nombre: {Nombre} | Cédula: {Cedula} | En espera";
        }
        else
        {
            return $"Asiento {NumeroAsiento} | Nombre: {Nombre} | Cédula: {Cedula}";
        }
    }
}