using System.Dynamic;

namespace Laberinto
{
   internal class Celda
   {

      private int fila { get; }
      private int columna { get; }
      private bool puedePisar { get;set;}
      private bool esVisible { get; set; } = false;
      public Celda(int fila, int columna, bool puedePisar = false)
      {
         this.fila = fila;
         this.columna = columna;
         this.puedePisar = puedePisar;
      }
      public int GetFila()
      {
         return fila;
      }
      public int GetColumna()
      {
         return columna;
      }
      public bool GetPuedePisar()
      {
         return puedePisar;
      }
      public void SetPuedePisar(bool puedePisar)
      {
         this.puedePisar = puedePisar;
      }
      public bool GetEsVisible()
      {
         return esVisible;
      }
      public void SetEsVisible(bool esVisible = true)
      {
         this.esVisible = esVisible;
      }
   }

}