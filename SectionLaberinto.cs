using System.Resources;

namespace Laberinto
{
   internal class SectionLaberinto : Laberinto
   {
      public SectionLaberinto(int filas, int columnas) : base(filas, columnas)
      {
      }

      public List<int> ListaPosicionesDisponiblesUltimaFila()
      {
         List<int> listPuedePisar = new List<int>();

         int ulltimaFila = GetCantidadFilas();
         for (int i = 0; i <= GetCantidadColumnas(); i++)
         {
            if (laberinto[ulltimaFila, i].GetPuedePisar())
            {
               listPuedePisar.Add(i);
            };
         }
         return listPuedePisar;
      }
      public List<int> ListaPosicionesDisponiblesUltimaFila(int laberintoReferenciaCantidadFilas)
      {
         List<int> listPuedePisar = new List<int>();

         int ulltimaFila = laberintoReferenciaCantidadFilas;
         for (int i = 0; i < GetCantidadColumnas(); i++)
         {
            if (laberinto[ulltimaFila, i].GetPuedePisar())
            {
               listPuedePisar.Add(i);
            };
         }
         return listPuedePisar;
      }
      public void AgregarCeldasOcupadas(int laberintoReferenciaCantidadFilas, int seccionColumnasARecorrer = 0)
      {
         List<int> listPuedePisar = ListaPosicionesDisponiblesUltimaFila(laberintoReferenciaCantidadFilas);
         int comienzaEn = 0;
         int recorreHasta = listPuedePisar.Count();
         switch (seccionColumnasARecorrer)
         {
            case 1:
               //recorre la 2da mitad
               comienzaEn = listPuedePisar.Count() / 2;
               break;
            case 2:
               //recorre la 1er mitad
               recorreHasta = listPuedePisar.Count() / 2 - 1;
               break;
            default:
               break;
         }

         for (int i = comienzaEn; i < recorreHasta; i++)
         {
            SetCeldaOcupada(GetLaberinto()[laberintoReferenciaCantidadFilas, listPuedePisar[i]]);
         }
        



      }
      public void AgregarCeldasOcupadas(Laberinto laberintoReferencia)
      {
         //List<int> listPuedePisar = ListaPosicionesDisponiblesUltimaFila(laberintoReferenciaCantidadFilas);
         Console.WriteLine($"agregar, ");
         for (int i = 0; i <= laberintoReferencia.GetCantidadFilas(); i++)
         {
            if (laberintoReferencia.GetLaberinto()[laberintoReferencia.GetCantidadFilas(), i].GetPuedePisar())
            {
               SetCeldaOcupada(GetLaberinto()[laberintoReferencia.GetCantidadFilas(), i]);

            }
         }
         //SetCeldaOcupada(laberintoReferencia.GetCeldaVictoria());


      }

      //elegis de que lado es la posicion de victoria, izquierda o derecha
      public void SetPosiVictoria(bool secondHalf = true)
      {

         List<int> listPuedePisar = ListaPosicionesDisponiblesUltimaFila();
         int posiVictoria;
         if (secondHalf)
         {
            //selecciona la 2da mitad de las opciones, es para que haya un sig sag entre las opciones
            posiVictoria = GetRandom(listPuedePisar.Count() / 4*2, listPuedePisar.Count());
         }
         else
         {
            Console.WriteLine("entra acaaa");
            posiVictoria = GetRandom(listPuedePisar.Count() / 4);


         }

         this.SetCeldaVictoria(laberinto[GetCantidadFilas(), listPuedePisar[posiVictoria]]);

      }


      public void SetCeldaVictoria(bool RightCorner = true)
      {
         List<int> listPuedePisar = ListaPosicionesDisponiblesUltimaFila();
         int posiVictoria;
         if (RightCorner)
         {
            posiVictoria = listPuedePisar.Last();
            Console.WriteLine(posiVictoria);
         }
         else
         {
            posiVictoria = listPuedePisar[0];
         }

         this.SetCeldaVictoria(laberinto[GetCantidadFilas(), posiVictoria]);

      }
      public void CrearLaberintoDos()
      {

         //laberintoPrimerTercio.GenerarLaberintoFuncional();

         CrearCeldas();
         SetPosicionInicial();
         CrearLaberinto();
         SetPosiVictoria();
         MostrarMatriz();
      }
   }
}