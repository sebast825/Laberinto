using System.Globalization;

namespace Laberinto
{
   internal class LaberintoDificil : Laberinto
   {
      public LaberintoDificil(int filas, int columnas) : base(filas, columnas)
      {




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

         ActualizarCeldasLaberinto(tercioDeFilas *2, laberintoPrimerTercio, laberintoSegundoTercio);
       /*  for (int i = 0; i < tercioDeFilas * 2; i++)
         {
            for (int j = 0; j < GetCantidadColumnas(); j++)
            {
               //Console.WriteLine($"desde ca{i},{j}");
               if (i < GetCantidadFilas(laberPrimero) && laberPrimero[i, j].GetPuedePisar())

               {
                  //Console.WriteLine($"{GetCantidadFilas(laberPrimero)},{i},{j}");

                  laberintoSegundoTercio.CambiarCeldaLaberinto(i, j);

               }

            }

         }*/
         /*
                  laberintoUno = laberintoPrimerTercio;
                  laberintoDos = laberintoSegundoTercio;*/
         laberintoSegundoTercio.SetCeldaActual(laberintoPrimerTercio.GetCeldaVictoria());
         laberintoSegundoTercio.SetFilaActual(laberintoPrimerTercio.GetFilaVictoria());
         laberintoSegundoTercio.SetColumnaActual(laberintoPrimerTercio.GetColumnaVictoria());

         Celda celdaVictoriaAnterior = laberintoPrimerTercio.GetCeldaVictoria();
         laberintoSegundoTercio.SetCeldaInicio(celdaVictoriaAnterior);

         //hace que se puede pisar la celda de la victoria del laberinto anterior, asi al concatenarlo sigue el recorrido

         laberintoSegundoTercio.CambiarCeldaLaberinto(celdaVictoriaAnterior.GetFila(), celdaVictoriaAnterior.GetColumna());
         //laberintoSegundoTercio.SetPosicionInicial();

         //laberintoSegundoTercio.SetCeldaVictoria();
         laberintoSegundoTercio.CrearLaberinto();
                  laberintoPrimerTercio.MostrarMatriz();

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
      public void ActualizarCeldasLaberinto(int filas, Laberinto laberintoReferencia, Laberinto laberintoActualizar){
         for (int i = 0; i < filas; i++)
         {
            for (int j = 0; j <= GetCantidadColumnas(); j++)
            {
               //Console.WriteLine($"desde ca{i},{j}");
               if (i <= laberintoReferencia.GetCantidadFilas() && laberintoReferencia.GetLaberinto()[i, j].GetPuedePisar())

               {
                  //Console.WriteLine($"{GetCantidadFilas(laberintoReferencia)},{i},{j}");

                  laberintoActualizar.CambiarCeldaLaberinto(i, j);

               }

            }

         }
         
      }
   }



}