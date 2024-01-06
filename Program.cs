using System.Linq.Expressions;
using System.Diagnostics;
using System.Globalization;
using System.Security.AccessControl;
namespace Laberinto;
class Program
{
  static void Main(string[] args)
  {


    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();


    Laberinto unLaberinto = new Laberinto(5, 10);
    unLaberinto.CrearCeldas();
    unLaberinto.SetPosicionInicial();
    unLaberinto.CrearLaberinto();
    unLaberinto.SetCeldaVictoria();

    Personaje unPersonaje = new Personaje();
    Partida unaPartida = new Partida(unLaberinto, unPersonaje);
    unaPartida.Iniciar();

    stopwatch.Stop();
    Console.WriteLine($"Tiempo transcurrido: {stopwatch.ElapsedMilliseconds} ms");
  }
}

/*
CREAR LABERINTO

 -setPosicionInicial
 -proximoMovimiento

    ElegirDireccion
    while (!validarDireccion || array.lenght == 0){
      array
      GetDireccionRandom(array)
      validarDireccion

      if(validarDireccion)
      {
        modificarLaberinto
      }else{
        array.remove(num GetDireccionRandom)
      }


    }

*/


