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


         LaberintoSeccion(tercioDeFilas * 2, laberintoPrimerTercio, laberintoSegundoTercio);
         laberintoSegundoTercio.SetPosiVictoria(false);

      
         LaberintoSeccion(tercioDeFilas * 3, laberintoSegundoTercio, laberintoTercerTercio);

         laberintoTercerTercio.SetCeldaVictoria();

         laberintoTercerTercio.MostrarMatriz();


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
         laberintoSegundoTercio.SetPosicionInicial();
         laberintoSegundoTercio.SetCeldaActual(laberintoReferencia.GetCeldaVictoria());

         laberintoSegundoTercio.SetCeldaInicio(laberintoReferencia.GetCeldaVictoria());
         //le da mas versatilidad al crear la proxima seccion, porque las toma para crear nuevos caminos
         SetCeldaOcupada(laberintoReferencia.GetCeldaVictoria());
         laberintoSegundoTercio.AgregarCeldasOcupadas(laberintoReferencia.GetCantidadFilas());
         laberintoSegundoTercio.CrearLaberinto();
         //laberintoSegundoTercio.SetPosiVictoria();
         //ModificarFilaAnterior(laberintoReferencia.GetCantidadFilas(),laberintoSegundoTercio, laberintoReferencia);

      }

      // esto es para que al unir los distintos mapas no quede un choclo de pared
      public void ModificarFilaAnterior(int fila, SectionLaberinto laberintoSegundoTercio, Laberinto laberintoReferencia)
      {
         Console.WriteLine("");
         Console.WriteLine($"columna: {fila}- victoria: {laberintoReferencia.GetColumnaVictoria()}");

         Celda celda;
         Celda celdaLabAnterior;
         for (int i = 0; i < laberintoSegundoTercio.GetCantidadColumnas(); i++)
         {
            celdaLabAnterior = laberintoReferencia.GetLaberinto()[fila, i];
            celda = laberintoSegundoTercio.GetLaberinto()[fila, i];
            //Console.Write($"{celda.GetPuedePisar()}- {i}- ");
            //verifica que no sea un unico camino y que no sea necesario para ganar (al ganar xq toma la posi victoria para continuar con el siguiente tramo)
            if (celda.GetPuedePisar() && !celdaLabAnterior.GetEsVictoria() && laberintoSegundoTercio.GetLaberinto()[fila - 1, i].GetPuedePisar())
            {
               laberintoSegundoTercio.CambiarCeldaLaberinto(fila, i, false);
               //Console.WriteLine("modifica");
               Console.Write($"{celda.GetPuedePisar()}, {celdaLabAnterior.GetEsVictoria()}- {i} modi| ");
            }
            else
            {
               Console.Write($"{celda.GetPuedePisar()}, {celdaLabAnterior.GetEsVictoria()}- {i} | ");

            }
         }
      }
   }
}