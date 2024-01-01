using System.Linq.Expressions;
using System.Diagnostics;
using System.Globalization;
namespace Laberinto;
class Program
{
  static void Main(string[] args)
  {


    Stopwatch stopwatch = new Stopwatch();

    stopwatch.Start();
    Laberinto unLaberinto = new Laberinto(25, 25);
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

    int j = 0;

    bool sigue = true;
    while (j < 60)
    {
      int i = 0;
      bool seAgrego = false;
      while (i < 10 && sigue)
      {
        Console.WriteLine($"iteration {i}");

        sigue = unLaberinto.ElegirDireccion();
        if (sigue)
        {

          unLaberinto.SetCasillaOcupada(unLaberinto.GetLaberinto()[unLaberinto.GetFilaActual(), unLaberinto.GetColumnaActual()]);
        }
        else
        {
          if (unLaberinto.HayCasillasDisponibles())
          {
            if (!seAgrego)
            {
              unLaberinto.SetCasillaOcupada(unLaberinto.GetLaberinto()[unLaberinto.GetFilaInicial(), unLaberinto.GetFilaInicial()]);
              seAgrego = true;

            }
            unLaberinto.CambiarRutaLaberinto();
            sigue = true;
          }


        }
        Console.WriteLine("");

        i++;
      }
      j++;
      i = 0;
      if (unLaberinto.HayCasillasDisponibles())
      {
        unLaberinto.CambiarRutaLaberinto();
      }
      else
      {
        break;
      }
    }



    unLaberinto.MostrarMatriz();


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


