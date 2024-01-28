using System.Resources;

namespace Laberinto
{
   internal class SectionLaberinto : Laberinto
   {
      public SectionLaberinto(int filas, int columnas) : base(filas, columnas)
      {
      }


      //se usa para el laberint actual
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
      //se usa para el laberinto anterior
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
               //recorre la 1er mitad
               recorreHasta = listPuedePisar.Count() / 2 - 1;
               break;
            case 2:

               //recorre la 2da mitad
               comienzaEn = listPuedePisar.Count() / 2;

               break;
            default:
               comienzaEn = 0;
               break;
         }

         for (int i = comienzaEn; i < recorreHasta; i++)
         {
            SetCeldaOcupada(GetLaberinto()[laberintoReferenciaCantidadFilas, listPuedePisar[i]]);
         }




      }


      //elegis de que lado es la posicion de victoria, izquierda o derecha
      public void SetPosiVictoriaSecondHalf(bool secondHalf = true)
      {

         List<int> listPuedePisar = ListaPosicionesDisponiblesUltimaFila();
         int posiVictoria = 0;
         if (secondHalf)
         {
            //selecciona la 2da mitad de las opciones, es para que haya un sig sag entre las opciones
            posiVictoria = GetRandom(listPuedePisar.Count() / 3 * 2, listPuedePisar.Count());
         }
         else
         {
            posiVictoria = GetRandom(listPuedePisar.Count() / 4);
         }
         try
         {
            this.SetCeldaVictoria(laberinto[GetCantidadFilas(), listPuedePisar[posiVictoria]]);

         }
         catch (Exception error)
         {
            Console.WriteLine(error);
         }

      }


      public void SetCeldaVictoria(bool RightCorner = true)
      {
         List<int> listPuedePisar = ListaPosicionesDisponiblesUltimaFila();
         int posiVictoria;
         if (RightCorner)
         {
            posiVictoria = listPuedePisar.Last();
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
         SetPosiVictoriaSecondHalf();
         MostrarMatriz();
      }
   }
}