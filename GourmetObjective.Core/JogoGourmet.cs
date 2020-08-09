using GourmetObjective.Core.Modelos;

namespace GourmetObjective.Core
{
    public class JogoGourmet
    {
        private readonly IInterfaceUsuario _interfaceUsuario;

        public JogoGourmet(IInterfaceUsuario interfaceUsuario)
        {
            _interfaceUsuario = interfaceUsuario;
        }

        public void Iniciar()
        {
            var raiz = new Caracteristica(string.Empty, new Prato(Messages.BoloDeChocolate));
            raiz.NovaSubCaracteristica(Messages.Massa, new Prato(Messages.Lasanha));

            while (true)
            {
                _interfaceUsuario.ExibirPenseEmUmPrato();
                ChecarCaracteristica(raiz);
            }
        }

        private void ChecarCaracteristica(Caracteristica caracteristica)
        {
            if (IsPratoDeUmaDasSubCaracteristicas(caracteristica))
                return;

            if (IsPratoAssociado(caracteristica))
            {
                _interfaceUsuario.ExibirAcerto();
                return;
            }

            AddNovoPratoComSubCaracteristicaDe(caracteristica);
        }

        /// <summary>
        /// Verifica se o prato pensado pelo usuário foi encontrado em alguma das subcaracterísticas daquela característica
        /// </summary>
        private bool IsPratoDeUmaDasSubCaracteristicas(Caracteristica caracteristica)
        {
            foreach (var sub in caracteristica.SubCaracteristicas)
            {
                if (_interfaceUsuario.IsPratoPensadoCaracterizadoPor(sub.Descricao))
                {
                    ChecarCaracteristica(sub);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica se o prato pensado pelo usuário é o prato que está associado àquela característica.
        /// </summary>
        private bool IsPratoAssociado(Caracteristica caracteristica)
        {
            return _interfaceUsuario.IsPratoPensadoIgual(caracteristica.PratoAssociado.Nome);
        }

        /// <summary>
        /// Recebe um novo prato associado a uma subcaracterística
        /// </summary>
        private void AddNovoPratoComSubCaracteristicaDe(Caracteristica caracteristicaPai)
        {
            var novoPrato = new Prato(_interfaceUsuario.ReceberNovoPrato());

            string descricaoSub =
                _interfaceUsuario.ReceberDiferencialEntrePratos(novoPrato.Nome, caracteristicaPai.PratoAssociado.Nome);

            caracteristicaPai.NovaSubCaracteristica(descricaoSub, novoPrato);
        }
    }
}
