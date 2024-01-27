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
         for (int i = 0; i < GetCantidadColumnas(); i++)
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
      public void AgregarCeldasOcupadas(int laberintoReferenciaCantidadFilas)
      {
         List<int> listPuedePisar = ListaPosicionesDisponiblesUltimaFila(laberintoReferenciaCantidadFilas);
         for (int i = 0; i < listPuedePisar.Count(); i++)
         {
            SetCeldaOcupada(GetLaberinto()[laberintoReferenciaCantidadFilas, listPuedePisar[i]]);
         }
                         


      }
        public void AgregarCeldasOcupadas(Laberinto laberintoReferencia)
      {
         //List<int> listPuedePisar = ListaPosicionesDisponiblesUltimaFila(laberintoReferenciaCantidadFilas);
        // Console.WriteLine($"agregar, {listPuedePisar.Count()}");
         for (int i = 0; i <= laberintoReferencia.GetCantidadFilas(); i++)
         {
            if(laberintoReferencia.GetLaberinto()[laberintoReferencia.GetCantidadFilas(),i].GetPuedePisar()){
            SetCeldaOcupada(GetLaberinto()[laberintoReferencia.GetCantidadFilas(), i]);

            }
         }
                  //SetCeldaOcupada(laberintoReferencia.GetCeldaVictoria());


      }
      public void SetPosiVictoria(bool secondHalf = true)
      {

         List<int> listPuedePisar = ListaPosicionesDisponiblesUltimaFila();
         int posiVictoria;
         if (secondHalf)
         {
            //selecciona la 2da mitad de las opciones, es para que haya un sig sag entre las opciones
            posiVictoria = GetRandom(listPuedePisar.Count() / 2 + 1, listPuedePisar.Count());
         }
         else
         {
            posiVictoria = GetRandom(listPuedePisar.Count() / 4);

         }

         this.SetCeldaVictoria(laberinto[GetCantidadFilas(), listPuedePisar[posiVictoria]]);

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