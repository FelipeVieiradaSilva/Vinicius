using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class GerenciadorDeContas
    {
        private List<Conta> contas = new List<Conta>();

        public void AdicionarConta(Conta conta)
        {
            contas.Add(conta);
        }

        // Método para obter todas as contas
        public List<Conta> ObterTodasContas()
        {
            return contas;
        }

        public Conta ObterConta(int numero)
        {
            return contas.FirstOrDefault(c => c.Numero == numero);
        }
    }
}

