using System.Dynamic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Laberinto
{
   internal class Celda
   {

      private int fila { get; }
      private int columna { get; }
      private bool puedePisar { get; set; }
      private bool esVisible { get; set; } = false;
      private bool esInicio { get; set; } = false;
      private bool esVictoria { get; set; } = false;
      private bool estaPersonaje { get; set; } = false;

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
      public bool GetEsInicio()
      {
         return esInicio;
      }
      public void SetEsInicio(bool esInicio = true)
      {
         this.esInicio = esInicio;
      }
      public bool GetEsVictoria()
      {
         return esVictoria;
      }
      public void SetEsVictoria(bool victoria = true)
      {
         this.esVictoria = victoria;
      }
      public bool GetEstaPersonaje()
      {
         return estaPersonaje;
      }
      public void SetEstaPersonaje(bool estaPersonaje)
      {
         this.estaPersonaje = estaPersonaje;
      }
      public void ImprimirPantalla()
      {

         if (puedePisar)
         {
            if (esInicio)
            {
               Console.BackgroundColor = ConsoleColor.Red;
            }
          
             if (estaPersonaje)
            {
               Console.BackgroundColor = ConsoleColor.Green;
  
            }
              else if (esVictoria)
            {
               Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
               Console.BackgroundColor = ConsoleColor.DarkGray;

            }
            Console.Write($" * ");

         }
         else
         {
            Console.BackgroundColor = ConsoleColor.DarkCyan;

            Console.Write($" * ");

         }
      }
   }

}