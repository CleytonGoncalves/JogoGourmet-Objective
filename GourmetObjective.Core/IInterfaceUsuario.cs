namespace GourmetObjective.Core
{
    public interface IInterfaceUsuario
    {
        void ExibirPenseEmUmPrato();

        bool IsPratoPensadoCaracterizadoPor(string caracteristica);

        bool IsPratoPensadoIgual(string prato);

        string ReceberNovoPrato();

        string ReceberDiferencialEntrePratos(string pratoNovo, string pratoDeComparacao);

        void ExibirAcerto();
    }
}
