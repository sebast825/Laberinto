﻿using System.Linq.Expressions;

namespace Laberinto;
class Program
{
  static void Main(string[] args)
  {
    Laberinto unLaberinto = new Laberinto(5, 5);
unLaberinto.SetPosicionInicial();
bool posiValida = unLaberinto.ValidarDireccion(3);unLaberinto.MostrarMatriz();

if(posiValida) {
  unLaberinto.ModificarLaberinto(unLaberinto.GetFilaActual(),unLaberinto.GetColumnaActual()-1,3);
}
Console.WriteLine("");
unLaberinto.MostrarMatriz();
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


