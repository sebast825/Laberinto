

namespace Laberinto
{
   public class ConfiguracionLaberinto
   {
      public bool boolFirst { get; }
      public bool boolSecond { get; }
      public int numSecond { get; }
      public int numThird { get; }

      public ConfiguracionLaberinto(bool boolFirst, bool boolSecond, int numSecond, int numThird)
      {
         this.boolFirst = boolFirst;
         this.boolSecond = boolSecond;
         this.numSecond = numSecond;
         this.numThird = numThird;
      }
   }
}