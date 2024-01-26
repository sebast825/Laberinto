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

      public void SetPosiVictoria(bool secondHalf = true)
      {

         List<int> listPuedePisar = ListaPosicionesVictoria();
         int posiVictoria;
         if (secondHalf)
         {
            //selecciona la 2da mitad de las opciones, es para que haya un sig sag entre las opciones
            posiVictoria = GetRandom(listPuedePisar.Count() / 2 +1, listPuedePisar.Count());
               Console.WriteLine($"true: {posiVictoria}");
         }
         else
         {
            posiVictoria = GetRandom(listPuedePisar.Count() / 4);
               Console.WriteLine($"false: {posiVictoria}");

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