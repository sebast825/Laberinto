using System.Resources;

namespace Laberinto
{
   internal class SectionLaberinto : Laberinto
   {
      public SectionLaberinto(int filas, int columnas) : base(filas, columnas)
      {
      }

      public List<int> ListaPosicionesVictoria()
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

      public void SetPosiVictoria(){
         List<int> listPuedePisar = ListaPosicionesVictoria();
         int posiVictoria = GetRandom(listPuedePisar.Count());
         this.SetCeldaVictoria(laberinto[GetCantidadFilas(),listPuedePisar[posiVictoria]]);
         Console.WriteLine(posiVictoria);
         Console.WriteLine(listPuedePisar.Count());
      }



         public void CrearLaberintoDos(){
       
         //laberintoPrimerTercio.GenerarLaberintoFuncional();

            CrearCeldas();
         SetPosicionInicial();
         CrearLaberinto();
         SetPosiVictoria();
         MostrarMatriz();
   }
   }
}