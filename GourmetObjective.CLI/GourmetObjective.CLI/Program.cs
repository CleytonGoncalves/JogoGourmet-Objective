using GourmetObjective.Core;

namespace GourmetObjective.CLI
{
    public class Program
    {
        public static void Main()
        {
            var jogo = new JogoGourmet(new InterfaceCli());
            jogo.Iniciar();
        }
    }
}
