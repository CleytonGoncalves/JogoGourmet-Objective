using System.Collections.Generic;
using System.Linq;

namespace GourmetObjective.Core.Modelos
{
    /// <summary>
    /// Cada característica possui um prato associado, e pode possuir sub-características.
    /// Por exemplo, 'Lasanha' possui a característica 'Massa', que poderia ter uma sub-característica 'Macarrão' cujo prato
    /// seja 'Espaguete', e assim por diante.
    /// </summary>
    public class Caracteristica
    {
        public string Descricao { get; }
        public Prato PratoAssociado { get; }

        private readonly ICollection<Caracteristica> _subCaracteristicas;
        public IReadOnlyCollection<Caracteristica> SubCaracteristicas => _subCaracteristicas.ToList();

        public Caracteristica(string descricao, Prato pratoAssociado)
        {
            Descricao = descricao;
            PratoAssociado = pratoAssociado;

            _subCaracteristicas = new List<Caracteristica>();
        }

        public void NovaSubCaracteristica(string descricao, Prato pratoAssociado)
        {
            _subCaracteristicas.Add(new Caracteristica(descricao, pratoAssociado));
        }

        public override string ToString() => Descricao;
    }
}
