namespace Laberinto
{

   class Partida
   {

      private Laberinto laberinto;
      private Personaje personaje;
      Celda[,] matrizLaberinto;
      public Partida(Laberinto laberinto, Personaje personaje)
      {

         this.personaje = personaje;
         this.laberinto = laberinto;
         this.matrizLaberinto = laberinto.GetLaberinto();

      }

      public void Iniciar()
      {
         Celda celdaInicio = laberinto.GetCeldaInicio();

            bool cancelarPartida = false;
             personaje.SetPosiX(celdaInicio.GetFila());
             personaje.SetPosiY(celdaInicio.GetColumna());
         
            bool validarMovimiento = false;
            do
            {
                laberinto.MostrarMatriz();
                char movimiento = personaje.ElegirMovimiento();

                if (movimiento == 'r')
                {
                    cancelarPartida = true;
                }
                validarMovimiento = ValidarMovimiento(movimiento);
                laberinto.MostrarMatriz();

            }

            while ( !VerificarVictoria() && !cancelarPartida);
            
            if (VerificarVictoria())
            {
               
                Console.WriteLine("Ganaste!!");
            }
            else
            {
                Console.WriteLine("Has fializado la partida");

            }

        }

      public bool VerificarVictoria()
      {
         return matrizLaberinto[personaje.GetPosiX(), personaje.GetPosiY()].GetEsVictoria();

      }



      //MOVIMINETO DEL PERSONAJE
      public bool SePuedeMover(int fila, int columna)
      {
         return laberinto.GetLaberinto()[fila, columna].GetPuedePisar();
      }
      public bool ValidarMovimiento(char movimiento)
      {
         int personajeFila = personaje.GetPosiX();
         int personajeColumna = personaje.GetPosiY();
         bool esValido = false;
         switch (movimiento)
         {
            case 'w':
               if (personajeFila == 0) return false;
               if (SePuedeMover(personajeFila - 1, personajeColumna))
               {
                  matrizLaberinto[personajeFila, personajeColumna].SetEstaPersonaje(false);
                  personaje.SetPosiX(personajeFila - 1);
                  matrizLaberinto[personajeFila - 1, personajeColumna].SetEstaPersonaje(true);
                  esValido = true;
               }
               else
               {
                  esValido = false;
               }
               break;


            case 'd':
               if (personajeColumna == matrizLaberinto.GetLength(1) - 1) return false;

               if (SePuedeMover(personajeFila, personajeColumna + 1))
               {
                  matrizLaberinto[personajeFila, personajeColumna].SetEstaPersonaje(false);
                  personaje.SetPosiY(personajeColumna + 1);
                  matrizLaberinto[personajeFila, personajeColumna + 1].SetEstaPersonaje(true);
                  esValido = true;
               }
               else
               {
                  esValido = false;
               }
               break;


            case 's':
               if (personajeFila == matrizLaberinto.GetLength(0) - 1) return false;

               if (SePuedeMover(personajeFila + 1, personajeColumna))
               {
                  matrizLaberinto[personajeFila, personajeColumna].SetEstaPersonaje(false);
                  personaje.SetPosiX(personajeFila + 1);
                  matrizLaberinto[personajeFila + 1, personajeColumna].SetEstaPersonaje(true);
                  esValido = true;
               }
               else
               {
                  esValido = false;
               }

               break;
            case 'a':
               if (personajeColumna == 0) return false;

               if (SePuedeMover(personajeFila, personajeColumna - 1))
               {
                  matrizLaberinto[personajeFila, personajeColumna].SetEstaPersonaje(false);
                  personaje.SetPosiY(personajeColumna - 1);
                  matrizLaberinto[personajeFila, personajeColumna - 1].SetEstaPersonaje(true);
                  esValido = true;
               }
               else
               {
                  esValido = false;
               }
               break;



         }
         return esValido;


      }
   }
}