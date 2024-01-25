namespace Laberinto
{
   internal class LaberintoDificil : Laberinto
   {
      Celda[,] laberinto;
      Laberinto laberintoUno;
      Laberinto laberintoDos;
      public LaberintoDificil(int filas, int columnas) : base(filas, columnas)
      {
         /*Celda[,] laberinto = this.GetLaberinto();
         this.SetPosicionInicial();
         
      */

      }


      //subdivide el laberinto en 3 secciones
      public void CrearSeccionesHorizontal()
      {
         //crea las celdas para la totalidad del laberinto
         this.CrearCeldas();



         //se le suma 1 porque el metodo esta echo para iterar la matriz, ya viene con el valor restado
         int tercioDeFilas = (GetCantidadFilas() + 1) / 3;
         //int tercioDeColumnas = (GetCantidadColumnas() + 1) / 3;
         Laberinto laberintoPrimerTercio = GenerarPrimeraParte(tercioDeFilas, GetCantidadColumnas() + 1);
         Celda[,] laberPrimero = laberintoPrimerTercio.GetLaberinto();

         //Console.WriteLine(GetCantidadFilas());
         Laberinto laberintoSegundoTercio = new Laberinto(tercioDeFilas * 2, GetCantidadColumnas() + 1);
         laberintoSegundoTercio.CrearCeldas();

         // Console.WriteLine($"primer matriz {      GetCantidadFilas(laberintoPrimerTercio.GetLaberinto())},{GetCantidadColumnas(laberintoPrimerTercio.GetLaberinto())}; ");
         //        Console.WriteLine($"primer matriz {      GetCantidadFilas(laberintoSegundoTercio.GetLaberinto())},{GetCantidadColumnas(laberintoSegundoTercio.GetLaberinto())}; ");


         //laberintoSegundoTercio.MostrarMatriz();
         //laberintoPrimerTercio.MostrarMatriz();

         //le paso todas las filas y el segundo tercio de las columnas a laberintoSegundoTercio
         for (int i = 0; i < tercioDeFilas * 2; i++)
         {
            for (int j = 0; j <= GetCantidadColumnas(); j++)
            {
               //Console.WriteLine($"desde ca{i},{j}");
               Console.WriteLine($"{GetCantidadFilas(laberPrimero)},{i}");
               if (i > GetCantidadFilas(laberPrimero)) { return; }
               if (laberPrimero[i, j].GetPuedePisar())
               {
                  laberintoSegundoTercio.CambiarCeldaLaberinto(i, j);

               }

            }
         }
/*
         laberintoUno = laberintoPrimerTercio;
         laberintoDos = laberintoSegundoTercio;*/
         
         laberintoSegundoTercio.SetFilaActual(laberintoPrimerTercio.GetFilaVictoria());
         laberintoSegundoTercio.SetColumnaActual(laberintoPrimerTercio.GetColumnaVictoria());

         Celda celdaVictoriaAnterior = laberintoPrimerTercio.GetCeldaVictoria();
         laberintoSegundoTercio.SetCeldaInicio(celdaVictoriaAnterior);

         //hace que se puede pisar la celda de la victoria del laberinto anterior, asi al concatenarlo sigue el recorrido

         laberintoSegundoTercio.CambiarCeldaLaberinto(celdaVictoriaAnterior.GetFila(), celdaVictoriaAnterior.GetColumna());
         //laberintoSegundoTercio.SetPosicionInicial();

         //laberintoSegundoTercio.SetCeldaVictoria();
         laberintoPrimerTercio.MostrarMatriz();
         laberintoSegundoTercio.CrearLaberinto();
         Console.WriteLine("asd");
         laberintoSegundoTercio.MostrarMatriz();

         // laberintoSegundoTercio.MostrarMatriz();
         /*     for (int i = 0; i < laberintoSegundoTercio.GetLaberinto().GetLength(0); i++)
             {
                for (int j = 0; j <laberintoSegundoTercio.GetLaberinto().GetLength(1); j++)
                {
                  laberintoSegundoTercio.GetLaberinto()[i,j].ImprimirPantalla();

                }
             }*/


      }
      public Laberinto GenerarPrimeraParte(int filas, int columnas)
      {
         Laberinto laberintoPrimerTercio = new Laberinto(filas, columnas);
         laberintoPrimerTercio.GenerarLaberintoFuncional();
         return laberintoPrimerTercio;

      }
      public void MostrarUno()
      {
         this.laberintoUno.MostrarMatriz();
      }
   }



}