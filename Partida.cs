namespace Laberinto
{

   class Partida
   {
      private int[,] laberinto;
      private Personaje personaje;

      public Partida(int[,] laberinto, Personaje personaje)
      {
         this.laberinto = laberinto;
         this.personaje = personaje;

      }
      public void MostrarLaberinto()
      {
         int personajeX = personaje.GetPosiX();
         int personajeY = personaje.GetPosiY();
         int valor = -1;
         int ia = -1;
         int ij = -1;
         for (int i = laberinto.GetLength(0) - 1; i >= 0; i--)
         {
            Console.Write($"{i} | ");
            for (int j = 0; j < laberinto.GetLength(1); j++)
            {
               if (j == personajeX && personajeY == i)
               {
                  /* pa ver que valor toma   
                  valor = laberinto[i, j];
                     ia = i;
                     ij = j;*/
                  Console.BackgroundColor = ConsoleColor.Green;
                  Console.Write($"{laberinto[i, j]} ");
                  Console.ResetColor();
               }
               else
               {
                  if (laberinto[i, j] == 1)
                  {
                     Console.BackgroundColor = ConsoleColor.Red;
                     Console.Write($"{laberinto[i, j]} ");

                     Console.ResetColor();
                  }
                  else
                  {
                     Console.Write($"{laberinto[i, j]} ");

                  }
               }

            }
            Console.WriteLine(" ");

         }
         //Console.WriteLine($"valor: {valor}, {ia}, {ij}");

      }
      public void Iniciar()
      {
         bool ganar = false;
         while (ganar == false)
         {
            MostrarLaberinto();
            bool validarMovimiento = false;
            do
            {
               char movimiento = personaje.ElegirMovimiento();
               validarMovimiento = HayPared(validarMovimiento, movimiento);
               bool personajeMuere = PuedeCaminar();
               //Console.WriteLine($"personajeMuere: {personajeMuere}");
               if (personajeMuere)
               {  
                  Console.WriteLine("Perdiste, intentalo nuevamente! Apreta Enter para re intentar");
                  Console.ReadLine();
                  personaje.CambiarPosicion(laberinto.GetLength(1) / 2,0);

               }
               Console.WriteLine("");
            }

            while (!validarMovimiento);


            ganar = verificarVictoria();

         }
         Console.WriteLine("ganaste!!");

      }
      public bool PuedeCaminar()
      {
         if(verificarVictoria()) return false;
         //Console.WriteLine($"laberinto {laberinto[personaje.GetPosiY(), personaje.GetPosiX()]}, {personaje.GetPosiX()},{personaje.GetPosiY()}");
         return (laberinto[personaje.GetPosiY(), personaje.GetPosiX()] == 0) ? true : false;


      }
      public bool verificarVictoria()
      {
         return personaje.GetPosiY() >= laberinto.GetLength(0) ? true : false;

      }

      //si se puede mover, cambia la posicion del personaje
      public bool HayPared(bool validarMovimiento, char movimiento)
      {
         int personajePosiX = personaje.GetPosiX();
         int personajePosiY = personaje.GetPosiY();
         switch (movimiento)
         {
            case 'w':
               personaje.Mover(movimiento);
               validarMovimiento = true;
               break;
            case 'd':
               if ((personajePosiX + 1) < laberinto.GetLength(1))
               {
                  personaje.Mover(movimiento);
                  validarMovimiento = true;
               }
               break;
            case 's':

               if ((personajePosiY - 1) >= 0)
               {
                  personaje.Mover(movimiento);
                  validarMovimiento = true;
               }
               break;
            case 'a':
               if ((personajePosiX - 1) >= 0)
               {
                  personaje.Mover(movimiento);
                  validarMovimiento = true;
               }
               break;


         }
         return validarMovimiento;
      }
      public bool SePuedeMovrer(int x)
      {
         bool validarMovimiento;
         int personajePosiX = personaje.GetPosiX();

         if ((personajePosiX - x) < 0 || (personajePosiX + x) > laberinto.GetLength(0))
         {
            validarMovimiento = false;
         }
         else
         {
            validarMovimiento = true;
         }
         return validarMovimiento;
      }
   }
}