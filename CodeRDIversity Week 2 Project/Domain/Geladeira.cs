using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Geladeira
    {
        private readonly List<Andar> _andares;

        public Geladeira(int numeroDeAndares, int numeroDeContainersPorAndar, int capacidadeContainer)
        {
            _andares = new List<Andar>();
            for (int i = 0; i < numeroDeAndares; i++)
            {
                _andares.Add(new Andar(numeroDeContainersPorAndar, capacidadeContainer));
            }
        }

        public Andar ObterAndar(int indice)
        {
            if (indice < 0 || indice >= _andares.Count)
            {
                throw new IndexOutOfRangeException("Andar inválido.");
            }
            return _andares[indice];
        }

        public void MostrarItens()
        {
            for (int i = 0; i < _andares.Count; i++)
            {
                Console.WriteLine($"Andar {i}:");
                _andares[i].MostrarItens();
            }
        }
    }
}

