using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Container
    {
        private readonly List<Item> _itens;
        public int Capacidade { get; }

        public Container(int capacidade)
        {
            Capacidade = capacidade;
            _itens = new List<Item>(capacidade);
        }

        public bool EstaVazio => _itens.Count == 0;
        public bool EstaCheio => _itens.Count >= Capacidade;

        public void AdicionarItem(Item item, int posicao)
        {
            if (EstaCheio)
            {
                throw new InvalidOperationException("O container está cheio.");
            }
            if (posicao < 0 || posicao >= Capacidade)
            {
                throw new ArgumentOutOfRangeException("Posição inválida.");
            }
            if (_itens.Count > posicao && _itens[posicao] != null)
            {
                throw new InvalidOperationException("A posição já está ocupada.");
            }
            if (_itens.Count <= posicao)
            {
                for (int i = _itens.Count; i <= posicao; i++)
                {
                    _itens.Add(null);
                }
            }
            _itens[posicao] = item;
        }

        public Item RemoverItem(int posicao)
        {
            if (EstaVazio)
            {
                throw new InvalidOperationException("O container está vazio.");
            }
            if (posicao < 0 || posicao >= _itens.Count || _itens[posicao] == null)
            {
                throw new InvalidOperationException("Posição inválida ou já vazia.");
            }
            var item = _itens[posicao];
            _itens[posicao] = null;
            return item;
        }

        public IEnumerable<Item> ObterItens()
        {
            return _itens.ToArray();
        }

        public override string ToString()
        {
            return string.Join(", ", _itens);
        }
    }
}
