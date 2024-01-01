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
         posiActual = new int[2];
         posiInicial = new int[2];
         // int [] direccionesDisponibles = new int []{0,1,2,3};
         //posiActual = GetPosicionInicial();

      }

      public void ShowPosiActual(string direction)
      {

         Console.WriteLine($"{direction} | fila:{GetFilaActual()}, columna{GetColumnaActual()}");
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
      public void SetFilaActual(int fila)
      {
         posiActual[0] = fila;
      }
      public void SetColumnaActual(int columna)
      {
         posiActual[1] = columna;
      }
      public void SetFilaInicial(int fila)
      {
         posiInicial[0] = fila;
      }
      public void SetColumnaInicial(int columna)
      {
         posiInicial[1] = columna;
      }

      public void SetPosicionInicial()
      {// { 1, 4 }
         int[] posiIni = new int[2];
         posiIni = CreatePosicionInicial();
         SetFilaInicial(posiIni[0]);
         SetColumnaInicial(posiIni[1]);
         SetFilaActual(posiInicial[0]);
         SetColumnaActual(posiInicial[1]);

         //ModificarLaberinto(2, 3);

         //ModificarLaberinto(3, 4);


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
         foreach (int elem in posiInicial)
         {
            Console.WriteLine(elem);
         }
         return posiInicial;
      }

      public int GetDireccionRandom(int[] direccionesDisponibles)
      {

         int[] dirreccion = direccionesDisponibles;

         int elegirDireccin = rnd.Next(0, dirreccion.Length);
         return dirreccion[elegirDireccin];
      }
      public bool ValidarDireccion(int direccion)
      {
         bool esValido;

         switch (direccion)
         {
            //valida arriba
            case 0:
               esValido = ValidarArriba();
               break;
            case 1:
               esValido = ValidarDerecha();
               break;
            case 2:
               esValido = ValidarAbajo();
               break;
            case 3:
               esValido = ValidarIzquierda();
               break;
            default:
               esValido = false;
               break;

         }
         return esValido;
      }

      public void SwichModificarLaberinto(int direccion)
      {

         switch (direccion)
         {
            //valida arriba
            case 0:
               ShowPosiActual("arriba");
               ModificarLaberinto(GetFilaActual() - 1, GetColumnaActual());
               SetFilaActual(GetFilaActual() - 1);
               SetColumnaActual(GetColumnaActual());
               ShowPosiActual("arriba");

               break;

            case 1:
               ShowPosiActual("derecha");

               ModificarLaberinto(GetFilaActual(), GetColumnaActual() + 1);
               SetFilaActual(GetFilaActual());
               SetColumnaActual(GetColumnaActual() + 1);
               ShowPosiActual("derecha");

               break;

            case 2:
               ShowPosiActual("abajo");

               ModificarLaberinto(GetFilaActual() + 1, GetColumnaActual());
               SetFilaActual(GetFilaActual() + 1);
               SetColumnaActual(GetColumnaActual());
               ShowPosiActual("abajo");

               break;

            case 3:
               ShowPosiActual("izquierda");
               ModificarLaberinto(GetFilaActual(), GetColumnaActual() - 1);
               SetFilaActual(GetFilaActual());
               SetColumnaActual(GetColumnaActual() - 1);
               ShowPosiActual("izquierda");

               break;

            default:
               Console.WriteLine("error");
               break;

         }

      }

      public bool ElegirDireccion()
      {
         int[] direccionesDisponibles = new int[] { 0, 1, 2, 3 };
         int numDireccion = GetDireccionRandom(direccionesDisponibles);
         bool isValid = ValidarDireccion(numDireccion);
         //direccionesDisponibles.Length >=  1 ||
         while (!isValid)
         {

            direccionesDisponibles = direccionesDisponibles.Where(n => n != numDireccion).ToArray();

            if (direccionesDisponibles.Length == 0)
            {
               break;
            }
            numDireccion = GetDireccionRandom(direccionesDisponibles);
            isValid = ValidarDireccion(numDireccion);
         }
         if (isValid)
         {

            SwichModificarLaberinto(numDireccion);
            return true;
         }
         else
         {
            Console.WriteLine($"is valid: {isValid}");

            return false;
         }
      }
      public bool ValidarDerecha()
      {

         int fila = GetFilaActual();
         int columna = GetColumnaActual();
         int[] posicionFilas = new int[] { -1, 0, 1 };

         // si es la ultima columna
         if (EsUltimaColumna())
         {
            return false;
         }
         //si no tiene posibilidad de revisar 2 atras
         else if (columna < GetCantidadColumnas() - 1)
         {
            if (CeldaOcupada(fila, columna + 2, "derr"))
            {
               return false;
            }
         }

         //si es la primer fila
         if (fila == 0)
         {

            int[] posicionFilaCero = new int[] { 0, 1 };
            posicionFilas = posicionFilaCero;
         }
         //si es la ultima fila
         else if (EsUltimaFila())
         {
            int[] posicionUltimaFila = new int[] { -1, 0 };
            posicionFilas = posicionUltimaFila;
         }
         //itera
         foreach (int fil in posicionFilas)
         {
            if (CeldaOcupada(fila + fil, columna + 1, "der"))
            {
               return false;
            }
         }
         return true;
      }

      public bool CeldaOcupada(int fila, int columna, string vieneDe)
      {
         try
         {
            return laberinto[fila, columna] == 1 ? true : false;

         }
         catch (Exception error)
         {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"{vieneDe} | fila: {fila}, columna: {columna}");

            Console.ResetColor();
            Console.WriteLine(error);
            return false;
         }
      }
      public bool EsFilaSuperior()
      {
         return GetFilaActual() == 0 ? true : false;
      }
      public bool EsUltimaFila()
      {
         return GetFilaActual() == (laberinto.GetLength(0) - 1) ? true : false;
         // Console.WriteLine($"fila: {GetFilaActual()}, length: {laberinto.GetLength(0) - 1}");

      }

      public int GetCantidadFilas()
      {
         return (laberinto.GetLength(0) - 1);
      }
      public int GetCantidadColumnas()
      {
         return (laberinto.GetLength(1) - 1);
      }
      public bool EsUltimaColumna()
      {
         return GetColumnaActual() == (laberinto.GetLength(1) - 1) ? true : false;

      }
      public bool ValidarIzquierda()
      {

         int fila = GetFilaActual();
         int columna = GetColumnaActual();
         int[] posicionFilas = new int[] { -1, 0, 1 };

         // si es la primer columna
         if (columna == 0)
         {
            return false;
         }
         //si no tiene posibilidad de revisar 2 atras
         else if (columna > 1)
         {
            if (CeldaOcupada(fila, columna - 2, "izqqqq"))
            {
               return false;
            }
         }

         //si es la primer fila
         if (fila == 0)
         {

            int[] posicionColumnasCero = new int[] { 0, 1 };
            posicionFilas = posicionColumnasCero;
         }
         //si es la ultima fila
         else if (EsUltimaFila())
         {
            int[] posicionUltimaColumna = new int[] { -1, 0 };
            posicionFilas = posicionUltimaColumna;
         }
         //itera
         foreach (int fil in posicionFilas)
         {
            if (CeldaOcupada(fila + fil, columna - 1, "izq"))
            {
               return false;
            }
         }
         return true;
      }
      public bool ValidarArriba()
      {

         int fila = GetFilaActual();
         int columna = GetColumnaActual();
         int[] posicionColumnas = new int[] { -1, 0, 1 };


         if (EsFilaSuperior())
         {
            return false;
         }
         if (fila > 1)
         {
            if (CeldaOcupada(fila - 2, columna, "arriba"))
            {
               return false;
            }
         }


         if (columna == 0)
         {

            int[] posicionColumnasCero = new int[] { 0, 1 };
            posicionColumnas = posicionColumnasCero;
         }
         else if (EsUltimaColumna())
         {

            int[] posicionUltimaColumna = new int[] { -1, 0 };
            posicionColumnas = posicionUltimaColumna;
         }

         foreach (int colum in posicionColumnas)
         {
            if (CeldaOcupada(fila - 1, columna + colum, "arriba"))
            {
               return false;
            }
         }
         return true;
      }
      public bool ValidarAbajo()
      {

         int fila = GetFilaActual();
         int columna = GetColumnaActual();
         int[] posicionColumnas = new int[] { -1, 0, 1 };

         // si es la ultima fila
         if (EsUltimaFila())
         {
            return false;
         }
         //si no tiene posibilidad de revisar 2 adelante
         else if (fila < GetCantidadFilas() - 1)
         {
            if (CeldaOcupada(fila + 2, columna, "abajooo"))
            {
               return false;
            }
         }

         //si es la primer columna
         if (columna == 0)
         {

            int[] posicionColumnasCero = new int[] { 0, 1 };
            posicionColumnas = posicionColumnasCero;
         }
         //si es la ultima columna
         else if (EsUltimaColumna())
         {
            int[] posicionUltimaColumna = new int[] { -1, 0 };
            posicionColumnas = posicionUltimaColumna;
         }
         //itera
         foreach (int colum in posicionColumnas)
         {
            if (CeldaOcupada(fila + 1, columna + colum, "abajo"))
            {
               return false;
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
