using System.Linq.Expressions;
using System.Diagnostics;
using System.Globalization;
using System.Security.AccessControl;
namespace Laberinto;
class Program
{
  static void Main(string[] args)
  {

    LaberintoDificil unLaberintoDificil = new LaberintoDificil(21,21);

    unLaberintoDificil.CrearSeccionesHorizontal();
/*SectionLaberinto asd = new SectionLaberinto(21,21);
    asd.CrearLaberintoDos();*/
    //unLaberintoDificil.MostrarMatriz();
    /*
    int[,] matriz = new int[8, 8];
    int GetCantidadFilas = matriz.GetLength(0);
    int GetCantidadColumnas = matriz.GetLength(1);
    // Inicializar la matriz con números incrementales
    int contador = 0;
    for (int i = 0; i < GetCantidadFilas; i++)
    {
      for (int j = 0; j < GetCantidadColumnas; j++)
      {
        matriz[i, j] = contador++;
      }
    }

    for (int i = 0; i < GetCantidadFilas; i++)
    {
      for (int j = 0; j < GetCantidadColumnas; j++)
      {
        Console.Write(matriz[i, j] + "\t");
      }
      Console.WriteLine();
    }

    int tamanoSubmatriz = GetCantidadFilas / 2;

    // Dividir la matriz en submatrices de 5x5
    for (int i = 0; i < GetCantidadFilas; i += tamanoSubmatriz)
    {
      for (int j = 0; j < GetCantidadColumnas; j += tamanoSubmatriz)
      {
        // Recorrer la submatriz de 5x5
        for (int row = i; row < i + tamanoSubmatriz && row < GetCantidadFilas; row++)
        {

          for (int col = j; col < j + tamanoSubmatriz && col < GetCantidadColumnas; col++)
          {
            //Console.Write(matriz[row, col] + "\t");
            Console.Write($"{row},{col}\t");

            //laberinto[row,col].ImprimirPantalla();
            // Realizar operaciones en la posición (row, col) de la matriz
            // Ejemplo: int valor = matriz[row, col];
          }


        }
        Console.WriteLine(" ");

      }

    }*/
   /*
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();


        Laberinto unLaberinto = new Laberinto(20, 20);
        unLaberinto.CrearCeldas();
        unLaberinto.SetPosicionInicial();
        unLaberinto.CrearLaberinto();
        unLaberinto.SetCeldaVictoria();

        Personaje unPersonaje = new Personaje();
        Partida unaPartida = new Partida(unLaberinto, unPersonaje);
        //unaPartida.Iniciar();
      unLaberinto.MostrarMatriz();
        stopwatch.Stop();
        Console.WriteLine($"Tiempo transcurrido: {stopwatch.ElapsedMilliseconds} ms");
 
        unLaberinto.CrearLaberintoSecciones();*/


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


