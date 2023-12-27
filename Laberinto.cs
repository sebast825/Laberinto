using System.Linq.Expressions;

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

      public int[,] GetLaberinto(){
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

         int index = 0;
         for (int i = 2; i < laberinto.GetLength(0); i++)
         {
            index = 0;
            for (int j = 0; j < laberinto.GetLength(1); j++)
            {


               anterior[j] = laberinto[i - 2, j];
               muestraCambio[j] = laberinto[i - 1, j];
               actual[j] = laberinto[i, j];

               if (laberinto[i - 1, j] == 1)
               {
                  tieneUno[index] = j;
                  index++;
               }
            }
            int numAPisar = rnd.Next(0, index);

            laberinto[i, tieneUno[numAPisar]] = 1;


            bool sigueDerecho = rnd.Next(0, 2) == 0;
            int fila = i;
            int columna = tieneUno[numAPisar];


            int puedePisarIzquierda = rnd.Next(0, 3);
            //Console.WriteLine($"numAPisar: {numAPisar}, index: {index},puedePisarIzquierda: {puedePisarIzquierda}");

            //si esta x fuera del array
            try
            {

               // Console.WriteLine($"valor columna: {columna}, fila {fila}");

               if (puedePisarIzquierda == 0)
               {
                  laberinto[fila, columna - 1] = 1;
                  //Console.WriteLine($"pisa derecha, fila {i}");

                  if ((columna - 1) < 0)
                  {
                     laberinto[fila, columna + 1] = 1;

                  }
               }
               if (puedePisarIzquierda == 1)
               {
                  laberinto[fila, columna + 1] = 1;
                  //Console.WriteLine($"pisa izquierda, fila {i}");

                  if (laberinto[fila, columna + 1] > laberinto.GetLength(1))
                  {
                     laberinto[fila, columna - 1] = 1;

                  }
                  //Console.WriteLine(laberinto[fila, columna + 1]);
               }
            }
            catch (Exception error)
            {

            }

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

         bool sigueDerecho = rnd.Next(0, 2) == 0;

         if (sigueDerecho) return;

         bool puedePisarIzquierda = rnd.Next(0, 2) == 0;
         //Console.WriteLine($"Casilla lateral, {fila}, puedePisarIzquierda {puedePisarIzquierda}");

         //si esta x fuera del array
         try
         {


            if (puedePisarIzquierda)
            {
               laberinto[fila, columna - 1] = 1;
               //Console.WriteLine(laberinto[fila, columna - 1]);
            }
            else
            {
               laberinto[fila, columna + 1] = 1;
               //Console.WriteLine(laberinto[fila, columna + 1]);
            }
         }
         catch (Exception error)
         {

         }

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