using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Andar
    {
        private readonly List<Container> _containers;

        public Andar(int numeroDeContainers, int capacidadeContainer)
        {
            _containers = new List<Container>();
            for (int i = 0; i < numeroDeContainers; i++)
            {
                _containers.Add(new Container(capacidadeContainer));
            }
        }

        public Container ObterContainer(int indice)
        {
            if (indice < 0 || indice >= _containers.Count)
            {
                throw new IndexOutOfRangeException("Container inválido.");
            }
            return _containers[indice];
        }

        public void MostrarItens()
        {
            for (int i = 0; i < _containers.Count; i++)
            {
                Console.WriteLine($"Container {i}: {_containers[i]}");
            }
        }
    }
}