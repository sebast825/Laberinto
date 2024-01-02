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
    Laberinto unLaberinto = new Laberinto(10, 30);
    /*

     //ES ESTOO
       unLaberinto.SetPosicionInicial();
             unLaberinto.ModificarLaberinto(4, 14);
           unLaberinto.MostrarMatriz();
     unLaberinto.ValidarDireccion(0);
     Console.WriteLine("");
           unLaberinto.MostrarMatriz();
 */


    //ACA LO RECORRE
    //para una matriz de 15 *15, en 30 vueltas tarda 449ms
    unLaberinto.CrearCeldas();
    unLaberinto.SetPosicionInicial();

unLaberinto.CrearLaberinto();

    unLaberinto.MostrarMatriz();
  unLaberinto.SetCeldaVictoria();
    Console.WriteLine($"{unLaberinto.GetFilaActual()},{unLaberinto.GetColumnaActual()}");
    stopwatch.Stop();
    Console.WriteLine($"Tiempo transcurrido: {stopwatch.ElapsedMilliseconds} ms");


    //unLaberinto.MostrarMatriz();

    /*  bool posiValida = unLaberinto.ValidarDireccion(3); unLaberinto.MostrarMatriz();
      Console.WriteLine(posiValida);
      if (posiValida)
      {
        unLaberinto.ModificarLaberinto(unLaberinto.GetFilaActual()+1, unLaberinto.GetColumnaActual() , 3);
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

    /*  unLaberinto.CrearFilas();
   
 
    Personaje unPersonaje = new Personaje();
    Partida unaPartida = new Partida(unLaberinto.GetLaberinto(), unPersonaje);
    //unaPartida.MostrarLaberinto();
    unLaberinto.MostrarMatriz();

    //unaPartida.Iniciar();*/
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


