namespace Laberinto
{
   class Personaje
   {

      private int posiX { get; set; } = 0;
      private int posiY { get; set; } = 0;

      public int GetPosiX()
      {
         return posiX;
      }
      public int GetPosiY()
      {
         return posiY;
      }
      public void SetPosiY(int columna)
      {
         posiY = columna;
      }
      public void SetPosiX(int fila)
      {
         posiX = fila;
      }

      public char ElegirMovimiento()
      {
         char movimiento;
         do
         {
            //Console.WriteLine("");

           // Console.Write("Ingresar w/a/s/d: ");
            char input = Console.ReadKey(true).KeyChar;
            input = char.ToLower(input);

            // Verificar si el input es un carácter válido
            if (input == 'w' || input == 'd' || input == 's' || input == 'a' || input=='r')
            {
               movimiento = input;
               break; // Salir del bucle si el input es válido
            }
            else
            {
                    //Console.WriteLine("Direccion invalida!");
                    continue;
            }
         } while (true); // El bucle se ejecutará hasta que se ingrese un carácter válido
         return movimiento;
        
      }

   }
}