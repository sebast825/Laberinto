using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Laberinto
{
   internal class Laberinto
   {
      private int[,] laberinto;
      Random rnd = null!;
      public int[] posiInicial { get; set; }
      public int[] posiActual { get; set; }
      public Laberinto(int filas, int columnas)
      {
         laberinto = new int[filas, columnas];
         rnd = new Random();
         // int [] direccionesDisponibles = new int []{0,1,2,3};
         //posiActual = GetPosicionInicial();

      }

      public int[,] GetLaberinto()
      {
         return laberinto;
      }
      public int GetFilaActual()
      {
         return posiActual[0];
      }
      public int GetColumnaActual()
      {
         return posiActual[1];
      }

      public void SetPosicionInicial()
      {
         int[] posiInicia = new int[2] { 4, 2 };
         //posiInicial = CreatePosicionInicial();
         posiInicial = posiInicia;
         posiActual = posiInicial;
         //ModificarLaberinto(3,3);
         ModificarLaberinto(posiInicial[0], posiInicial[1]);

      }
      public void ModificarLaberinto(int fila, int columna, int valor = 1)
      {
         laberinto[fila, columna] = valor;
      }
      public int[] CreatePosicionInicial()
      {
         int[] posiInicial = new int[2];


         posiInicial[0] = rnd.Next(0, laberinto.GetLength(0));
         posiInicial[1] = rnd.Next(0, laberinto.GetLength(1));
         return posiInicial;
      }

      public int GetDireccionRandom()
      {
         int[] dirreccion = new int[] { 0, 1, 2, 3 }; ;
         int elegirDireccin = rnd.Next(0, dirreccion.Length);

         return dirreccion[elegirDireccin];
      }
      public bool ValidarDireccion(int direccion)
      {
         bool esValido = ValidarDerecha();
         /*
                  switch (direccion)
                  {
                     //valida arriba
                     case 0:
                        esValido = validarArriba()

                  }*/
         return esValido;
      }

      public bool ValidarDerecha()
      {

         int fila = GetFilaActual();
         int proxColumna = GetColumnaActual() + 1;
         //x si esta en la ultima columna
         if (proxColumna == laberinto.GetLength(1)) return false;
         int complementoFilas = 1;
         if (EsFilaSuperior())
         {
            fila = GetFilaActual() + 1;
            complementoFilas = 0;
         }
         if (EsFilaInferior())
         {
            complementoFilas = 0;
         }
         for (int i = fila - 1; i <= fila + complementoFilas; i++)
         {
            for (int j = proxColumna; j < proxColumna + 1; j++)
            {
               Console.WriteLine($"entra: {i},{j}");
               if (laberinto[i, j] == 1) return false;

               //verifica una 2da columna para la misma fila 
               if (GetFilaActual() == i && j == proxColumna)
               {
                  //en caso de que salga de la matriz no pasa nada
                  try
                  {
                     Console.WriteLine($"entraa: {i},{j + 1}");
                     if (laberinto[i, j + 1] == 1) return false;

                  }
                  catch (Exception error) { }
               }
            }


         }
         return true;
      }

      public bool EsFilaSuperior()
      {
         return GetFilaActual() == 0 ? true : false;
      }
      public bool EsFilaInferior()
      {
         bool asd = GetFilaActual() == (laberinto.GetLength(0) - 1) ? true : false;
         Console.WriteLine($"fila: {GetFilaActual()}, length: {laberinto.GetLength(0) - 1}");
         return asd;
      }
      public bool ValidarIzquierda()
      {
         int fila = GetFilaActual();
         int columnaAnterior = GetColumnaActual() - 1;
         //en caso de que no sea limite superior o inferior de la matriz, tiene que recorrer 3 filas en vez de 2
         int complementoFilas = 1;
         //x si esta en la primer columna, no puede agregar un valor a la izquierda
         if (GetColumnaActual() == 0) return false;

         if (EsFilaSuperior())
         {
            fila = GetFilaActual() + 1;
            complementoFilas = 0;
         }
         if (EsFilaInferior())
         {
            complementoFilas = 0;
         }

         for (int i = fila - 1; i <= fila + complementoFilas; i++)
         {
            //(Console.WriteLine("asd");
            for (int j = columnaAnterior; j > columnaAnterior - 1; j--)
            {

               Console.WriteLine($"entra: {i},{j}");
               if (laberinto[i, j] == 1) return false;

               //verifica una 2da columna para la misma fila 
               if (GetFilaActual() == i && j == columnaAnterior)
               {
                  //en caso de que salga de la matriz no pasa nada
                  try
                  {
                     Console.WriteLine($"entraa: {i},{j - 1}");
                     if (laberinto[i, j - 1] == 1) return false;

                  }
                  catch (Exception error) { }
               }
            }


         }
         return true;
      }


      public bool ReturnBool()
      {
         return rnd.Next(0, 2) == 0;
      }

      public void MostrarMatriz()
      {
         //ES PARA MOSTRAR LA AMTRIZ AL FINAL, NO BORRAR :)
         //laberinto[i, j] = (i == laberinto.GetLength(0) - 1) ? 1 : 0;

         for (int i = 0; i < laberinto.GetLength(0); i++)
         {
            //Console.Write($"{i} | ");
            for (int j = 0; j < laberinto.GetLength(1); j++)
            {
               if (laberinto[i, j] == 1)
               {
                  Console.BackgroundColor = ConsoleColor.Red;
                  Console.Write($"{laberinto[i, j]} ");

                  Console.ResetColor();
               }
               else
               {
                  Console.Write($"{laberinto[i, j]} ");

               }
            }
            Console.WriteLine("");

         }
      }
   }
}
