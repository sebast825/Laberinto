using System.Formats.Asn1;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Laberinto
{
   internal class Laberinto
   {
      protected Celda[,] laberinto;
      Random rnd = null!;
      protected Celda posiInicial { get; set; }
      protected Celda posiVictoria { get; set; }
        protected Celda celdaActual { get; set; }
      public List<Celda> celdasOcupadas { get; set; }
      protected List<Celda> celdasSinSalida { get; set; }

      public Laberinto(int filas, int columnas)
      {
         laberinto = new Celda[filas, columnas];
         rnd = new Random();
     
         celdasOcupadas = new List<Celda>();
         celdasSinSalida = new List<Celda>();

         // int [] direccionesDisponibles = new int []{0,1,2,3};
         //posiActual = GetPosicionInicial();

      }
      public Celda GetCeldaActual()
      {

         return celdaActual;
      }
         public void SetCeldaActual(Celda celdaActual)
      {

          this.celdaActual = celdaActual;
      }
      public Celda GetCeldaInicio()
      {

         return posiInicial;
      }
         public void SetCeldaInicio(Celda celdaInicio)
      {

          posiInicial = celdaInicio;
      }
      public void SetCeldaVictoria(Celda celdaVictoria)
      {
         celdaVictoria.SetEsVictoria();
         SetPosiVictoria(celdaVictoria);
      }
      public Celda GetCeldaVictoria()
      {
        return posiVictoria;
      }
      public void SetPosiVictoria(Celda celdaVictoria)
      {
         posiVictoria = celdaVictoria;
      }
      public void SetCeldaOcupada(Celda celda)
      {
         celdasOcupadas.Add(celda);
      }
      public void SetCeldaSinSalida(Celda celda)
      {
         celdasSinSalida.Add(celda);
      }
      public bool HayCasillasDisponibles()
      {
         return celdasOcupadas.Count > 0 ? true : false;
      }
      public void CambiarRutaLaberinto()
      {
         int posicion = GetRandom(celdasOcupadas.Count);

         SetFilaActual(celdasOcupadas[posicion].GetFila());
         SetColumnaActual(celdasOcupadas[posicion].GetColumna());
         celdasOcupadas.RemoveAt(posicion);
      }

      public int GetRandom(int techo)
      {
         int num = rnd.Next(0, techo);
         return num;
      }
       public bool GetRandomBool()
      {
          bool randomBool = rnd.Next(0, 2) == 0;

         return randomBool;
      }
        public int GetRandom(int piso, int techo)
      {
         int num = rnd.Next(piso, techo);
         return num;
      }
      public void CrearCeldas()
      {

         int filas = GetCantidadFilas();
         int columnas = GetCantidadColumnas();
         for (int i = 0; i <= filas; i++)
         {
            for (int j = 0; j <= columnas; j++)
            {
               laberinto[i, j] = new Celda(i, j);
            }
         }

      }
      public void ShowPosiActual(string direction)
      {

         Console.WriteLine($"{direction} | fila:{GetFilaActual()}, columna{GetColumnaActual()}");
      }
      public Celda[,] GetLaberinto()
      {
         return laberinto;
      }
      public int GetFilaActual()
      {
         return celdaActual.GetFila();
      }
      public int GetColumnaActual()
      {
         return celdaActual.GetColumna();
      }
      public int GetFilaVictoria()
      {
         return posiVictoria.GetFila();
      }
      public int GetColumnaVictoria()
      {
         return posiVictoria.GetColumna();
      }
      public void SetFilaActual(int fila)
      {
         celdaActual = laberinto[fila,celdaActual.GetColumna()];
      }
      public void SetColumnaActual(int columna)
      {
                  celdaActual = laberinto[celdaActual.GetFila(),columna];

      }

      public void SetPosicionInicial()
      {// { 1, 4 }
         int[] posiIni = new int[2] { 0, 0 };

         Celda celdaInicio = laberinto[posiIni[0], posiIni[1]];

SetCeldaActual(laberinto[posiIni[0],posiIni[1]]);
      
         celdaInicio.SetEsInicio();
         posiInicial = celdaInicio;
         laberinto[posiIni[0], posiIni[1]].SetEstaPersonaje(true);
         CambiarCeldaLaberinto(posiInicial.GetFila(), posiInicial.GetColumna());

      }
      public void CambiarCeldaLaberinto(int fila, int columna, bool valor = true)
      {
         laberinto[fila, columna].SetPuedePisar(valor);
      }
      public int[] CreatePosicionInicial()
      {
         int[] posiInicial = new int[2];

         posiInicial[0] = rnd.Next(0, laberinto.GetLength(0));
         posiInicial[1] = rnd.Next(0, laberinto.GetLength(1));

         return posiInicial;
      }

      public int GetDireccionRandom(List<int> direccionesDisponibles)
      {

         List<int> dirreccion = direccionesDisponibles;

         int elegirDireccin = rnd.Next(0, dirreccion.Count);
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

      public void SwichCambiarCeldaLaberinto(int direccion)
      {

         switch (direccion)
         {
            //valida arriba
            case 0:
               //ShowPosiActual("arriba");
               CambiarCeldaLaberinto(GetFilaActual() - 1, GetColumnaActual());
               SetFilaActual(GetFilaActual() - 1);
               SetColumnaActual(GetColumnaActual());
               //ShowPosiActual("arriba");

               break;

            case 1:
               //ShowPosiActual("derecha");

               CambiarCeldaLaberinto(GetFilaActual(), GetColumnaActual() + 1);
               SetFilaActual(GetFilaActual());
               SetColumnaActual(GetColumnaActual() + 1);
               //ShowPosiActual("derecha");

               break;

            case 2:
               //ShowPosiActual("abajo");

               CambiarCeldaLaberinto(GetFilaActual() + 1, GetColumnaActual());
               SetFilaActual(GetFilaActual() + 1);
               SetColumnaActual(GetColumnaActual());
               //ShowPosiActual("abajo");

               break;

            case 3:
               //ShowPosiActual("izquierda");
               CambiarCeldaLaberinto(GetFilaActual(), GetColumnaActual() - 1);
               SetFilaActual(GetFilaActual());
               SetColumnaActual(GetColumnaActual() - 1);
               //ShowPosiActual("izquierda");

               break;

            default:
               Console.WriteLine("error");
               break;

         }

      }

      public bool ElegirDireccion()
      {
         List<int> direccionesDisponibles = new List<int>() { 0, 1, 2, 3 };
         int numDireccion = GetDireccionRandom(direccionesDisponibles);
         bool isValid = ValidarDireccion(numDireccion);
         //direccionesDisponibles.Length >=  1 ||
         while (!isValid)
         {
            direccionesDisponibles.Remove(numDireccion);

            if (direccionesDisponibles.Count == 0)
            {
               break;
            }
            numDireccion = GetDireccionRandom(direccionesDisponibles);
            isValid = ValidarDireccion(numDireccion);
         }
         if (isValid)
         {

            SwichCambiarCeldaLaberinto(numDireccion);
            return true;
         }
         else
         {
            //Console.WriteLine($"is valid: {isValid}");
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
            return laberinto[fila, columna].GetPuedePisar();

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
      public int GetCantidadFilas(Celda[,] matriz)
      {
         return (matriz.GetLength(0) - 1);
      }
      public int GetCantidadColumnas()
      {
         return (laberinto.GetLength(1) - 1);
      }
      public int GetCantidadColumnas(Celda[,] matriz)
      {
         return (matriz.GetLength(1) - 1);
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
         //Console.Clear();
         for (int i = 0; i < laberinto.GetLength(0); i++)
         {
            //Console.Write($"{i} | ");
            for (int j = 0; j < laberinto.GetLength(1); j++)
            {
               laberinto[i, j].ImprimirPantalla();

            }
            Console.ResetColor();

            Console.WriteLine("");

         }

      }
      public void CrearLaberinto()

      {

         int j = 0, i = 0;
         bool sigue = true, seAgregoCoordenadaInicio = false;
      
         while (HayCasillasDisponibles() || j < 10)
         {
            while (i < GetCantidadColumnas()/2 && sigue)
            {
               sigue = ElegirDireccion();
               /*valida que la direccion elegida es valida, si lo es agrega la casilla a una lista para despues generar caminos alternativos*/
               if (sigue)
               {
                  SetCeldaOcupada(GetLaberinto()[GetFilaActual(), GetColumnaActual()]);
               }
               else
               {
                  if (HayCasillasDisponibles())
                  {
                     //agrega la coordenada de inicio para despues generar caminos alternativos, va aca porque si se agrega al final es menos probable que se utilize
                     if (!seAgregoCoordenadaInicio)
                     {

                        SetCeldaOcupada(GetLaberinto()[posiInicial.GetFila(), posiInicial.GetColumna()]);
                        seAgregoCoordenadaInicio = true;

                     }
                     //Console.WriteLine("Entra carnal");
                     SetCeldaSinSalida(GetLaberinto()[GetFilaActual(), GetColumnaActual()]);
                     CambiarRutaLaberinto();
                     sigue = true;
                  }

               }
         

               i++;

            }

            j++;
            i = 0;
            //modifica la ruta actual del laberinto, para darle mas variedad. Puede ser porque no habia una salida disponible para la ruta actual o porque despues de ciertas iteraciones cambia (while de i)
            if (HayCasillasDisponibles())
            {
               CambiarRutaLaberinto();

            }
            else
            {

               break;
            }
         }
      }

    
      public int CalcularDistanciaManhattan(int fila1, int columna1, int fila2, int columna2)
      {
         return Math.Abs(fila1 - fila2) + Math.Abs(columna1 - columna2);
      }
      public virtual void SetCeldaVictoria()
      {
         Celda celdaMasAlejada = GetCeldaInicio();
         int distanciaMaxima = int.MinValue;

         for (int i = 0; i < celdasSinSalida.Count; i++) // Recorrer filas
         {

            Celda celdaActual = celdasSinSalida[i];
            int distancia = CalcularDistanciaManhattan(posiInicial.GetFila(), posiInicial.GetColumna(), celdaActual.GetFila(), celdaActual.GetColumna());
            if (distancia > distanciaMaxima)
            {
               distanciaMaxima = distancia;
               celdaMasAlejada = celdaActual;
            }

         }
         Celda celdaVicotira = laberinto[celdaMasAlejada.GetFila(), celdaMasAlejada.GetColumna()];
  
         SetCeldaVictoria(celdaVicotira);

      }

      public void GenerarLaberintoFuncional()
      {
         this.CrearCeldas();
         this.SetPosicionInicial();
         this.CrearLaberinto();
         this.SetCeldaVictoria();
      }


   }

}