using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Poupanca : Conta
    {
        public override void Sacar(decimal valor)
        {
            if (Saldo >= valor)
                Saldo -= valor;
            else
                throw new Exception("Saldo insuficiente.");
        }

        public override void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public override void Transferir(Conta contaDestino, decimal valor)
        {
            Sacar(valor);
            contaDestino.Depositar(valor);
        }
    }

}
