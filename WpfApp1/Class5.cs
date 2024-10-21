using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public abstract class Conta
    {
        public int Numero { get; set; }
        public decimal Saldo { get; protected set; }

        public abstract void Sacar(decimal valor);
        public abstract void Depositar(decimal valor);
        public abstract void Transferir(Conta contaDestino, decimal valor);
    }

}
