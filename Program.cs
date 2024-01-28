using System.Linq.Expressions;
using System.Diagnostics;
using System.Globalization;
using System.Security.AccessControl;
namespace Laberinto;
class Program
{
  static void Main(string[] args)
  {
    //a partir de las 20 filas se habilita la opcion de zig zag
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    LaberintoDificil unLaberintoDificil = new LaberintoDificil(40, 40);
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


