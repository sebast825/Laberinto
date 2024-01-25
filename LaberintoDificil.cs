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
         SectionLaberinto laberintoPrimerTercio = GenerarPrimeraParte(tercioDeFilas, GetCantidadColumnas() + 1);
         Celda[,] laberPrimero = laberintoPrimerTercio.GetLaberinto();
         Celda celdaVictoriaAnterior = laberintoPrimerTercio.GetCeldaVictoria();

         //Console.WriteLine(GetCantidadFilas());
         SectionLaberinto laberintoSegundoTercio = new SectionLaberinto(tercioDeFilas * 2, GetCantidadColumnas() + 1);

         SectionLaberinto laberintoTercerTercio = new SectionLaberinto(GetCantidadFilas()+1, GetCantidadColumnas() + 1);


         LaberintoSeccion(tercioDeFilas * 2, laberintoPrimerTercio, laberintoSegundoTercio);
         LaberintoSeccion(tercioDeFilas * 3, laberintoSegundoTercio, laberintoTercerTercio);
         /*
                  laberintoSegundoTercio.CrearCeldas();
                  ActualizarCeldasLaberinto(tercioDeFilas * 2, laberintoPrimerTercio, laberintoSegundoTercio);


                  laberintoSegundoTercio.SetPosicionInicial();
                  laberintoSegundoTercio.SetCeldaActual(laberintoPrimerTercio.GetCeldaVictoria());
                  laberintoSegundoTercio.SetFilaActual(laberintoPrimerTercio.GetFilaVictoria());
                  laberintoSegundoTercio.SetColumnaActual(laberintoPrimerTercio.GetColumnaVictoria());
                  laberintoSegundoTercio.SetCeldaInicio(celdaVictoriaAnterior);
                  laberintoSegundoTercio.CrearLaberinto();
                  laberintoSegundoTercio.SetPosiVictoria();*/
         //hace que se puede pisar la celda de la victoria del laberinto anterior, asi al concatenarlo sigue el recorrido
         //laberintoSegundoTercio.CambiarCeldaLaberinto(celdaVictoriaAnterior.GetFila(), celdaVictoriaAnterior.GetColumna());
         //laberintoSegundoTercio.SetPosicionInicial();

         Console.WriteLine(laberintoSegundoTercio.GetFilaActual());
         //laberintoSegundoTercio.SetCeldaSinSalida(GetLaberinto()[laberintoSegundoTercio.GetFilaActual(), laberintoSegundoTercio.GetColumnaActual()]);
         //laberintoSegundoTercio.CreateCeldaVictoria(laberintoSegundoTercio.GetCeldaActual());

         laberintoPrimerTercio.MostrarMatriz();

         Console.WriteLine("asd");

         laberintoSegundoTercio.MostrarMatriz();
                  Console.WriteLine("asd");

         laberintoTercerTercio.MostrarMatriz();
         // laberintoSegundoTercio.MostrarMatriz();
         /*     for (int i = 0; i < laberintoSegundoTercio.GetLaberinto().GetLength(0); i++)
             {
                for (int j = 0; j <laberintoSegundoTercio.GetLaberinto().GetLength(1); j++)
                {
                  laberintoSegundoTercio.GetLaberinto()[i,j].ImprimirPantalla();

                }
             }*/


      }


      public SectionLaberinto GenerarPrimeraParte(int filas, int columnas)
      {
         SectionLaberinto laberintoPrimerTercio = new SectionLaberinto(filas, columnas);
         //no uso este metodo porque setPosiVictoria es distinto
         //laberintoPrimerTercio.GenerarLaberintoFuncional();

         laberintoPrimerTercio.CrearCeldas();
         laberintoPrimerTercio.SetPosicionInicial();
         laberintoPrimerTercio.CrearLaberinto();
         laberintoPrimerTercio.SetPosiVictoria();
         return laberintoPrimerTercio;
      }
      public void ActualizarCeldasLaberinto(int filas, Laberinto laberintoReferencia, Laberinto laberintoActualizar)
      {
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

      public void LaberintoSeccion(int filas, Laberinto laberintoReferencia, SectionLaberinto laberintoSegundoTercio)
      {
         laberintoSegundoTercio.CrearCeldas();
         ActualizarCeldasLaberinto(filas, laberintoReferencia, laberintoSegundoTercio);

         /*
                  laberintoUno = laberintoPrimerTercio;
                  laberintoDos = laberintoSegundoTercio;*/
         laberintoSegundoTercio.SetPosicionInicial();
         laberintoSegundoTercio.SetCeldaActual(laberintoReferencia.GetCeldaVictoria());
         laberintoSegundoTercio.SetFilaActual(laberintoReferencia.GetFilaVictoria());
         laberintoSegundoTercio.SetColumnaActual(laberintoReferencia.GetColumnaVictoria());
         laberintoSegundoTercio.SetCeldaInicio(laberintoReferencia.GetCeldaVictoria());
         laberintoSegundoTercio.CrearLaberinto();
         laberintoSegundoTercio.SetPosiVictoria();
      }
   }
}