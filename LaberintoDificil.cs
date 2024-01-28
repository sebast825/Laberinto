using System.Diagnostics.Contracts;
using System.Globalization;

namespace Laberinto
{
   internal class LaberintoDificil : Laberinto
   {
      public LaberintoDificil(int filas, int columnas) : base(filas, columnas){}

      //subdivide el laberinto en 3 secciones
      public void CrearSeccionesHorizontal()
      {
         //crea las celdas para la totalidad del laberinto
         this.CrearCeldas();
         //se le suma 1 porque el metodo esta echo para iterar la matriz, ya viene con el valor restado
         int tercioDeFilas = (GetCantidadFilas() + 1) / 3;
         SectionLaberinto laberintoPrimerTercio = GenerarPrimeraParte(tercioDeFilas, GetCantidadColumnas() + 1);
    

         SectionLaberinto laberintoSegundoTercio = new SectionLaberinto(tercioDeFilas * 2, GetCantidadColumnas() + 1);

         SectionLaberinto laberintoTercerTercio = new SectionLaberinto(GetCantidadFilas() + 1, GetCantidadColumnas() + 1);

         ConfiguracionLaberinto unaConfiguracion = ConfigurarLaberinto(ElegirConfiguracion());


         laberintoPrimerTercio.SetPosiVictoriaSecondHalf(unaConfiguracion.boolFirst);
         //con el 2 recorre la 2da mitad, con el 1 la 1er mitad, con el 0 todo

         LaberintoSeccion(tercioDeFilas * 2, laberintoPrimerTercio, laberintoSegundoTercio, unaConfiguracion.numSecond);
         //con true recorre la 2da mitad
         laberintoSegundoTercio.SetPosiVictoriaSecondHalf(unaConfiguracion.boolSecond);

         LaberintoSeccion(tercioDeFilas * 3, laberintoSegundoTercio, laberintoTercerTercio, unaConfiguracion.numThird);

 
         laberintoTercerTercio.SetCeldaVictoria();
         laberinto = laberintoTercerTercio.GetLaberinto();
         SetPosicionInicial();


      }
      private ConfiguracionLaberinto ConfigurarLaberinto(int option = 3)
      {

         switch (option)
         {
            // va por derecha
            case 0:
               return new ConfiguracionLaberinto(true, true, 2, 2);
            // va por izquierda
            case 1:
               return new ConfiguracionLaberinto(false, false, 1, 1);
            // aleatorio
            case 2:
               return new ConfiguracionLaberinto(GetRandomBool(), GetRandomBool(), GetRandom(3), GetRandom(3));
            // lo hace lab normal
            case 3:
               return new ConfiguracionLaberinto(GetRandomBool(), GetRandomBool(), 0, 0);
            // zigZag
            default:
               return new ConfiguracionLaberinto(true, false, 2, 1);
         }
      }

   public int ElegirConfiguracion(){
      int numero = 0;
      
      if(GetCantidadFilas() < 19){
         numero = GetRandom(4);
         
      }else{
          numero = GetRandom(20);

      }
      return numero;
   }
      public SectionLaberinto GenerarPrimeraParte(int filas, int columnas)
      {
         SectionLaberinto laberintoPrimerTercio = new SectionLaberinto(filas, columnas);
   
         laberintoPrimerTercio.CrearCeldas();
         laberintoPrimerTercio.SetPosicionInicial();
         laberintoPrimerTercio.CrearLaberinto();

         return laberintoPrimerTercio;
      }
      public void ActualizarCeldasLaberinto(int filas, Laberinto laberintoReferencia, Laberinto laberintoActualizar)
      {
         for (int i = 0; i < filas; i++)
         {
            for (int j = 0; j <= GetCantidadColumnas(); j++)
            {
               if (i <= laberintoReferencia.GetCantidadFilas() && laberintoReferencia.GetLaberinto()[i, j].GetPuedePisar())

               {
                  laberintoActualizar.CambiarCeldaLaberinto(i, j);
               }
            }
         }
      }

      public void LaberintoSeccion(int filas, Laberinto laberintoReferencia, SectionLaberinto laberintoModificar, int queMitad)
      {
         laberintoModificar.CrearCeldas();
         ActualizarCeldasLaberinto(filas, laberintoReferencia, laberintoModificar);
         laberintoModificar.SetPosicionInicial();
         laberintoModificar.SetCeldaActual(laberintoReferencia.GetCeldaVictoria());
         laberintoModificar.SetCeldaInicio(laberintoReferencia.GetCeldaVictoria());
         //le da mas versatilidad al crear la proxima seccion, porque las toma para crear nuevos caminos
         laberintoModificar.AgregarCeldasOcupadas(laberintoReferencia.GetCantidadFilas(), queMitad);
         laberintoModificar.CrearLaberinto();
      }
   }
}