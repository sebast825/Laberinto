using System.Linq.Expressions;

namespace Laberinto;
class Program
{
  static void Main(string[] args)
  {
    Laberinto unLaberinto = new Laberinto(15, 5);

    /*
    bool posiValida = unLaberinto.ValidarDireccion(2); unLaberinto.MostrarMatriz();

  if (posiValida)
      {
        unLaberinto.ModificarLaberinto(unLaberinto.GetFilaActual()+1, unLaberinto.GetColumnaActual() , 3);
      }
      Console.WriteLine("");
      unLaberinto.MostrarMatriz();*/

   
   /*

    //ES ESTOO
      unLaberinto.SetPosicionInicial();
            unLaberinto.ModificarLaberinto(4, 14);
          unLaberinto.MostrarMatriz();
    unLaberinto.ValidarDireccion(0);
    Console.WriteLine("");
          unLaberinto.MostrarMatriz();
*/
 

    unLaberinto.SetPosicionInicial();

    int i = 0;
    bool sigue = true;
    while (i < 30 && sigue)
    {
      Console.WriteLine($"iteration {i}");

      sigue = unLaberinto.ElegirDireccion();
      unLaberinto.MostrarMatriz();
      //Console.WriteLine($"{unLaberinto.GetColumnaActual()},{unLaberinto.GetFilaActual()}");
      Console.WriteLine("");

      i++;
    }

    
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
    unLaberinto.MostrarMatriz();*/

    //unaPartida.Iniciar();
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


