namespace GourmetObjective.Core.Modelos
{
    public class Prato
    {
        public string Nome { get; }

        public Prato(string nome)
        {
            Nome = nome;
        }

        public override string ToString() => Nome;
    }
}
