using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class GerenciadorDeTransacoes
    {
        public void RealizarDeposito(Conta conta, decimal valor)
        {
            conta.Depositar(valor);
            // Aqui pode ser adicionado um registro da transação, se necessário.
        }

        public void RealizarSaque(Conta conta, decimal valor)
        {
            conta.Sacar(valor);
            // Aqui pode ser adicionado um registro da transação, se necessário.
        }

        public void RealizarTransferencia(Conta origem, Conta destino, decimal valor)
        {
            origem.Transferir(destino, valor);
            // Aqui pode ser adicionado um registro da transação, se necessário.
        }
    }
}

