using System.Linq.Expressions;
using System.Diagnostics;
using System.Globalization;
using System.Security.AccessControl;
using System.Text;
namespace Laberinto;
class Program
{
  static void Main(string[] args)
  {
        do
        {
           // Console.WriteLine("\nPresiona cualquier tecla para reiniciar o 'Esc' para salir...");

            EjecutarApp();

        }
        while (true); // Esc para salir

    }

    static void EjecutarApp()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Selecciona la dificultad: F (Fácil), M (Media), D (Difícil), G (God):");
        string input = Console.ReadLine();
        char dificultad = 'A';
        if (!string.IsNullOrEmpty(input))
        {
            dificultad = input.ToUpper()[0];
            Console.WriteLine($"Seleccionaste la dificultad: {dificultad}");
        }


        int filas = 0;
        int columnas = 0;

        switch (dificultad)
        {
            case 'F':
                filas = 10;
                columnas = 10;
                break;
            case 'M':
                filas = 20;
                columnas = 30;
                break;
            case 'D':
                filas = 30;
                columnas = 40;
                break;
            case 'G':
                filas = 50;
                columnas = 60;
                break;
            default:
                filas = 10;
                columnas = 20;
                break;
        }
        //a partir de las 20 filas se habilita la opcion de zig zag
        Console.Clear();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        LaberintoDificil unLaberintoDificil = new LaberintoDificil(columnas, filas);
        unLaberintoDificil.CrearSeccionesHorizontal();

        Personaje unPersonaje = new Personaje();

        Partida unaPartida = new Partida(unLaberintoDificil, unPersonaje);
        unaPartida.Iniciar();

        stopwatch.Stop();
        Console.WriteLine($"Tiempo transcurrido: {stopwatch.ElapsedMilliseconds} ms");

    }
}


