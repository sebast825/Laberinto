namespace Laberinto
{
   class Personaje
   {

      private int posiX { get; set; } = 0;
      private int posiY { get; set; } = 0;

      private int laberintoFilas { get; set; }
      private int laberintoColumnas { get; set; }
      public void Mover(char movimiento)
      {
         switch (movimiento)
         {
            case 'w':
               posiY++;
               break;
            case 'd':
               posiX++;
               break;
            case 's':
               posiY -=1;
               break;
            case 'a':
               posiX--;
               break;

         }


      }

      public int GetPosiX()
      {
         return posiX;
      }
      public int GetPosiY()
      {
         return posiY;
      }

      public char ElegirMovimiento()
      {
         char movimiento;
         do
         {
            //Console.WriteLine("");

            Console.Write("Ingresar w/a/s/d: ");
            string input = Console.ReadLine().ToLower();

            // Verificar si el input es un carácter válido
            if (input.Length == 1 && (input[0] == 'w' || input[0] == 'd' || input[0] == 's' || input[0] == 'a'))
            {
               movimiento = input[0];
               break; // Salir del bucle si el input es válido
            }
            else
            {
               Console.Write("Entrada no válida. Por favor, ingrese w/a/s/d: ");
            }
         } while (true); // El bucle se ejecutará hasta que se ingrese un carácter válido
         return movimiento;
         /*   switch (movimiento)
            {
               case 'w':
                  return 0;
               case 'd':
                  return 1;
               case 's':
                  return 2;
               case 'a':
                  return 3;
               default:
                  return 4;
            }*/
      }

      public void CambiarPosicion(int x, int y){
         posiX = x;
         posiY = y;
      }
   }
}