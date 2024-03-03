using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor_de_estoque
{
    internal interface IEstoque
    {
        void Exibir(); //as info do produto
        void AdicionarEntrada(); 
        void AdicionarSaida(); //Registrar vendas
    }
}
