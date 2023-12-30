namespace Laberinto;
class Program
{
  static void Main(string[] args)
  {
    Laberinto unLaberinto = new Laberinto(15, 15);
    unLaberinto.CrearFilas();
    Personaje unPersonaje = new Personaje();
    Partida unaPartida = new Partida(unLaberinto.GetLaberinto(), unPersonaje);
//unaPartida.MostrarLaberinto();
//unLaberinto.MostrarMatriz();

//unaPartida.Iniciar();
  }
}

/*
CREAR LABERINTO

-f0 recorre el la primer fila y le pone a todo 1
-f1 
  genera numero aleatorio y le pone 1
  ?sigueDerecho
    ?puedePisarIzquierda
-f2
  genera numero aleatorio
    ?PuedePisarFila
      verifica que la fila col anterior tenga 1
    else 
     ReHacerFila
     - agarra todos los 1 de la fila anterior
     los pasa a un array
     agarra uno de manera aleatoria
     y crea la fila a partir de ese
      ?sigueDerecho
        ?puedePisarIzquierda

*/