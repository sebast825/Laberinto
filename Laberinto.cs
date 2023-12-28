using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Laberinto
{
   internal class Laberinto
   {
      private int[,] laberinto;
      Random rnd;

      public Laberinto(int filas, int columnas)
      {
         laberinto = new int[filas, columnas];
      }

      public int[,] GetLaberinto()
      {
         return laberinto;
      }
      public void CrearFilaDos()
      {
         int fila = 1;
         rnd = new Random();
         int sePuedePisar = rnd.Next(0, laberinto.GetLength(1));

         for (int j = 0; j < laberinto.GetLength(1); j++)
         {

            if (j == sePuedePisar)
            {
               laberinto[fila, j] = 1;

            }
            else
            {
               laberinto[fila, j] = 0;

            }
         }
         CambiarCasillasLaterales(fila, sePuedePisar);


         CrearRestoDeFilas();

      }
      public void CrearRestoDeFilas()
      {
         int[] tieneUno = new int[laberinto.GetLength(1)];
         int[] muestraCambio = new int[laberinto.GetLength(1)];

         int[] anterior = new int[laberinto.GetLength(1)];
         int[] actual = new int[laberinto.GetLength(1)];

         int seguirDerecho = 0;
         int index = 0;
         for (int i = 2; i < laberinto.GetLength(0); i++)
         {
            index = 0;
            for (int j = 0; j < laberinto.GetLength(1); j++)
            {
               anterior[j] = laberinto[i - 2, j];
               muestraCambio[j] = laberinto[i - 1, j];
               actual[j] = laberinto[i, j];

               //encuentra las filas que tienen un uno
               if (laberinto[i - 1, j] == 1)
               {
                  tieneUno[index] = j;
                  index++;
               }
            }
            //elige de manera aleatoria que fila va a continuar, (en relacion a los unos encontrados antes)
            int numAPisar = rnd.Next(0, index);
            //pisa el numero
            laberinto[i, tieneUno[numAPisar]] = 1;


            bool sigueDerecho = ReturnBool();
            int fila = i;
            int columna = tieneUno[numAPisar];
            Console.WriteLine(tieneUno.Count(num => num == 1));
            if (index == 1)
            {
               CambiarCasillasLaterales(fila, columna);
            }
            //ya no sirve el console
            //Console.WriteLine($"numAPisar: {numAPisar}, index: {index},puedePisarIzquierda: {puedePisarIzquierda}");

            //CambiarCasillasLaterales(i, numAPisar);

            /*     Console.WriteLine($"fila {i}");

                 foreach (int elem in tieneUno)
                 {
                    Console.Write($"{elem} -");
                    //tieneUno[elem] = 0;
                 }
                 Console.WriteLine("");*/

         }
      }

      public bool ReturnBool()
      {
         return rnd.Next(0, 2) == 0;
      }
      public void CrearPrimerFila()
      {
         for (int j = 0; j < laberinto.GetLength(1); j++)
         {
            laberinto[0, j] = 1;
         }
      }
      public void CrearFilas()
      {
         CrearPrimerFila();
         CrearFilaDos();

      }
      public void CambiarCasillasLaterales(int fila, int columna)
      {
         int puedePisarIzquierda = rnd.Next(0, 3);

         //si esta x fuera del array
         try
         {
            // Console.WriteLine($"valor columna: {columna}, fila {fila}");

            if (puedePisarIzquierda == 0)
            {
               PisarIzquierda(fila, columna);
            }
            if (puedePisarIzquierda == 1)
            {
               PisarDerecha(fila, columna);


            }
         }
         catch (Exception error)
         {

         }
      }

      public void PisarIzquierda(int fila, int columna)
      {
         laberinto[fila, columna - 1] = 1;
         //Console.WriteLine($"pisa derecha, fila {i}");

         if ((columna - 1) < 0)
         {
            laberinto[fila, columna + 1] = 1;

         }
      }
      public void PisarDerecha(int fila, int columna)
      {
         laberinto[fila, columna + 1] = 1;
         //Console.WriteLine($"pisa izquierda, fila {i}");

         if (laberinto[fila, columna + 1] > laberinto.GetLength(1))
         {
            laberinto[fila, columna - 1] = 1;
         }
         //Console.WriteLine(laberinto[fila, columna + 1]);
      }
      public void MostrarMatriz()
      {
         //ES PARA MOSTRAR LA AMTRIZ AL FINAL, NO BORRAR :)
         //laberinto[i, j] = (i == laberinto.GetLength(0) - 1) ? 1 : 0;

         for (int i = 0; i < laberinto.GetLength(0); i++)
         {
            Console.Write($"{i} | ");
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


/*
 //a partir de la 2da linea

                  if (j == numeroAleatorio)
                  {
                     bool sigueDerecho = rnd.Next(0, 2) == 0;
                     laberinto[i, j] = 1;

                     if (!sigueDerecho)
                     {
                        bool puedePisarIzquierda = rnd.Next(0, 2) == 0;
                        //si esta x fuera del array
                        try
                        {
                           if (puedePisarIzquierda)
                           {
                              laberinto[i, j - 1] = 1;
                           }
                           else
                           {
                              laberinto[i, j + 1] = 1;

                           }
                        }

                        catch (Exception error)
                        {
                         
                        }


                     }
                  }
                  else
                  {
                     if (laberinto[i, j] != 1)
                     {
                        laberinto[i, j] = 0;

                     }

                  }
*/