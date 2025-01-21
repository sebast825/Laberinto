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
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Selecciona la dificultad: F (Fácil), M (Media), D (Difícil), G (God):");
        string input = Console.ReadLine(); // Lee el input completo como string
        char dificultad = 'A';
        if (!string.IsNullOrEmpty(input)) // Validar que el usuario haya ingresado algo
        {
            dificultad = input.ToUpper()[0]; // Tomar el primer carácter
            Console.WriteLine($"Seleccionaste la dificultad: {dificultad}");
        }
        else
        {
            Console.WriteLine("No ingresaste ninguna dificultad.");
        }

        int filas=0;
        int columnas =0;

        switch (dificultad)
        {
            case 'F':
                filas = 10;
                columnas = 20;
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
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    LaberintoDificil unLaberintoDificil = new LaberintoDificil(columnas, filas);
    unLaberintoDificil.CrearSeccionesHorizontal();

    Personaje unPersonaje = new Personaje();

    Partida unaPartida = new Partida(unLaberintoDificil, unPersonaje);
    unaPartida.Iniciar();

    stopwatch.Stop();
    Console.WriteLine($"Tiempo transcurrido: {stopwatch.ElapsedMilliseconds} ms");

    /*
      Laberinto unLaberinto = new Laberinto(20, 20);
      unLaberinto.CrearCeldas();
      unLaberinto.SetPosicionInicial();
      unLaberinto.CrearLaberinto();
      unLaberinto.SetCeldaVictoria();
      unLaberinto.MostrarMatriz();
    */

  }
}


