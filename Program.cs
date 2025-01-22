using System.Linq.Expressions;
using System.Diagnostics;
using System.Globalization;
using System.Security.AccessControl;
using System.Text;
namespace Laberinto;
class Program
{
  static void Main(string[] args)
  {
        string textoGrande = "Laberintos Aleatorios \n";
        string textoAscii = Figgle.FiggleFonts.Standard.Render(textoGrande);
        Console.WriteLine(textoAscii);
        Console.WriteLine("Desarrollado por Sebastián Molina \n\n\n");
        do
        {
            // Console.WriteLine("\nPresiona cualquier tecla para reiniciar o 'Esc' para salir...");
            
            Console.WriteLine("Para moverte utiliza las teclas W/A/S/D, si quieres finalizar la partida utiliza la letra 'R' \n");
            EjecutarApp();

        }
        while (true); // Esc para salir

    }

    static void EjecutarApp()
    {
        Console.OutputEncoding = Encoding.UTF8;//es necesario si se cambia a otros caracteres 

        Console.WriteLine("Selecciona la dificultad: F (Fácil), M (Media), D (Difícil), G (God):\n");
        string input = Console.ReadLine();
        char dificultad = 'A';
        if (!string.IsNullOrEmpty(input))
        {
            dificultad = input.ToUpper()[0];
        }


        int filas = 0;
        int columnas = 0;

        switch (dificultad)
        {
            case 'F':
                filas = 10;
                columnas = 10;
                break;
            case 'M':
                filas = 20;
                columnas = 30;
                break;
            case 'D':
                filas = 30;
                columnas = 40;
                break;
            case 'G':
                filas = 40;
                columnas = 50;
                break;
            default:
                filas = 10;
                columnas = 20;
                break;
        }
        //a partir de las 20 filas se habilita la opcion de zig zag
        Console.Clear();    

        LaberintoDificil unLaberintoDificil = new LaberintoDificil(columnas, filas);
        unLaberintoDificil.CrearSeccionesHorizontal();

        Personaje unPersonaje = new Personaje();

        Partida unaPartida = new Partida(unLaberintoDificil, unPersonaje);
        unaPartida.Iniciar();

        

    }
}


