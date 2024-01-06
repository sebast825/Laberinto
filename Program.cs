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
  

     //ES ESTOO
     /*
      unLaberinto.CrearCeldas();
       unLaberinto.SetPosicionInicial();
             unLaberinto.CambiarCeldaLaberinto(4, 14);
           unLaberinto.MostrarMatriz();
     unLaberinto.ValidarDireccion(0);
     Console.WriteLine("");
           unLaberinto.MostrarMatriz();
 */


    //ACA LO RECORRE
    //para una matriz de 15 *15, en 30 vueltas tarda 449ms
/*    unLaberinto.CrearCeldas();
    unLaberinto.SetPosicionInicial();

unLaberinto.CrearLaberinto();
  unLaberinto.SetCeldaVictoria();

    unLaberinto.MostrarMatriz();*/
    Console.WriteLine($"{unLaberinto.GetFilaActual()},{unLaberinto.GetColumnaActual()}");
    stopwatch.Stop();
    Console.WriteLine($"Tiempo transcurrido: {stopwatch.ElapsedMilliseconds} ms");


    //unLaberinto.MostrarMatriz();
 /* unLaberinto.CrearCeldas();
    unLaberinto.SetPosicionInicial();
    unLaberinto.CrearLaberinto();
  unLaberinto.SetCeldaVictoria();

      bool posiValida = unLaberinto.ValidarDireccion(3);
       unLaberinto.MostrarMatriz();
      Console.WriteLine(posiValida);
      if (posiValida)
      {
              Console.WriteLine("");

        unLaberinto.CambiarCeldaLaberinto(unLaberinto.GetFilaActual()+1, unLaberinto.GetColumnaActual());
      }
      Console.WriteLine("");
      unLaberinto.MostrarMatriz();*/
    /*
    int i = 0;
    while(i < 10){
    Console.WriteLine( );

        i++;
        }
    */

  unLaberinto.CrearCeldas();
    unLaberinto.SetPosicionInicial();

unLaberinto.CrearLaberinto();
  unLaberinto.SetCeldaVictoria();

 
    Personaje unPersonaje = new Personaje();
    Partida unaPartida = new Partida( unLaberinto,unPersonaje);
    //unaPartida.MostrarLaberinto();
    //unLaberinto.MostrarMatriz();

    unaPartida.Iniciar();
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


