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

         SectionLaberinto laberintoSegundoTercio = new SectionLaberinto(tercioDeFilas * 2, GetCantidadColumnas() + 1);

         SectionLaberinto laberintoTercerTercio = new SectionLaberinto(GetCantidadFilas() + 1, GetCantidadColumnas() + 1);

ConfiguracionLaberinto unaConfiguracion = ConfigurarLaberinto();


         laberintoPrimerTercio.SetPosiVictoriaSecondHalf(unaConfiguracion.boolFirst);
         //con el 2 recorre la 2da mitad, con el 1 la 1er mitad, con el 0 todo

         LaberintoSeccion(tercioDeFilas * 2, laberintoPrimerTercio, laberintoSegundoTercio, unaConfiguracion.numSecond);
         //con true recorre la 2da mitad
         laberintoSegundoTercio.SetPosiVictoriaSecondHalf(unaConfiguracion.boolSecond);

         LaberintoSeccion(tercioDeFilas * 3, laberintoSegundoTercio, laberintoTercerTercio, unaConfiguracion.numThird);
         /*
         laberintoPrimerTercio.SetPosiVictoriaSecondHalf(false);
         //con el 2 recorre la 2da mitad, con el 1 la 1er mitad, con el 0 todo

         LaberintoSeccion(tercioDeFilas * 2, laberintoPrimerTercio, laberintoSegundoTercio, 1);
         //con true recorre la 2da mitad
         laberintoSegundoTercio.SetPosiVictoriaSecondHalf(false);

         LaberintoSeccion(tercioDeFilas * 3, laberintoSegundoTercio, laberintoTercerTercio, 1);
         //laberintoTercerTercio.SetPosiVictoriaSecondHalf(false);*/
         laberintoPrimerTercio.MostrarMatriz();
         Console.WriteLine(" ");
         laberintoSegundoTercio.MostrarMatriz();
         laberintoTercerTercio.SetCeldaVictoria();
         /*  Console.WriteLine($"parte 2 ini- {laberintoSegundoTercio.GetCeldaInicio().GetFila()}, {laberintoSegundoTercio.GetCeldaInicio().GetColumna()}");
        Console.WriteLine($"parte 2 win - {laberintoSegundoTercio.GetCeldaVictoria().GetFila()}, {laberintoSegundoTercio.GetCeldaVictoria().GetColumna()}");

        Console.WriteLine($"parte 3 ini- {laberintoTercerTercio.GetCeldaInicio().GetFila()}, {laberintoTercerTercio.GetCeldaInicio().GetColumna()}");
        Console.WriteLine($"parte 3 win - {laberintoTercerTercio.GetCeldaVictoria().GetFila()}, {laberintoTercerTercio.GetCeldaVictoria().GetColumna()}");
*/
         laberintoTercerTercio.MostrarMatriz();


      }
      private ConfiguracionLaberinto ConfigurarLaberinto(int option = 2)
      {
      

         switch (option)
         {
            // va por derecha
            case 0:
               return new ConfiguracionLaberinto(true, true, 2, 2);
            // va por izquierda
            case 1:
               return new ConfiguracionLaberinto(false, false, 1, 1);
            // aleatorio
            case 2:
               return new ConfiguracionLaberinto(GetRandomBool(), GetRandomBool(), GetRandom(3), GetRandom(3));
            // lo hace lab normal
            case 3:
               return new ConfiguracionLaberinto(GetRandomBool(), GetRandomBool(), 0, 0);
            // zigZag
            default:
               return new ConfiguracionLaberinto(true, false, 2, 1);
         }
      }

      public SectionLaberinto GenerarPrimeraParte(int filas, int columnas)
      {
         SectionLaberinto laberintoPrimerTercio = new SectionLaberinto(filas, columnas);
         //no uso este metodo porque setPosiVictoria es distinto
         //laberintoPrimerTercio.GenerarLaberintoFuncional();

         laberintoPrimerTercio.CrearCeldas();
         laberintoPrimerTercio.SetPosicionInicial();
         laberintoPrimerTercio.CrearLaberinto();

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

      public void LaberintoSeccion(int filas, Laberinto laberintoReferencia, SectionLaberinto laberintoModificar, int queMitad)
      {
         laberintoModificar.CrearCeldas();
         ActualizarCeldasLaberinto(filas, laberintoReferencia, laberintoModificar);
         laberintoModificar.SetPosicionInicial();
         laberintoModificar.SetCeldaActual(laberintoReferencia.GetCeldaVictoria());

         laberintoModificar.SetCeldaInicio(laberintoReferencia.GetCeldaVictoria());
         //le da mas versatilidad al crear la proxima seccion, porque las toma para crear nuevos caminos
         laberintoModificar.AgregarCeldasOcupadas(laberintoReferencia.GetCantidadFilas(), queMitad);


         //laberintoModificar.SetCeldaOcupada(laberintoReferencia.GetCeldaVictoria());
         //laberintoSegundoTercio.SetCeldaOcupada(laberintoReferencia.GetCeldaVictoria());
         laberintoModificar.CrearLaberinto();
         //laberintoSegundoTercio.SetPosiVictoriaSecondHalf();
         //ModificarFilaAnterior(laberintoReferencia.GetCantidadFilas(),laberintoSegundoTercio, laberintoReferencia);

      }


   }
}