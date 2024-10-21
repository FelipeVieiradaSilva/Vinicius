using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class Window1 : Window
    {
        GerenciadorDeClientes gerenciadorClientes = new GerenciadorDeClientes();
        GerenciadorDeContas gerenciadorDeContas = new GerenciadorDeContas();

        public Window1()
        {
            InitializeComponent();
        }

        private void CriarCliente_Click(object sender, RoutedEventArgs e)
        {
            string nomeCliente = txtNomeCliente.Text;
            if (string.IsNullOrEmpty(nomeCliente))
            {
                MessageBox.Show("Por favor, insira o nome do cliente.");
                return;
            }

            Cliente novoCliente = new Cliente
            {
                Id = gerenciadorClientes.ObterTodosClientes().Count + 1, // Simples auto-incremento para ID
                Nome = nomeCliente
            };

            gerenciadorClientes.AdicionarCliente(novoCliente);
            AtualizarListaClientes();
            txtNomeCliente.Clear();
        }

        private void AtualizarListaClientes()
        {
            lstClientes.Items.Clear();
            foreach (var cliente in gerenciadorClientes.ObterTodosClientes())
            {
                lstClientes.Items.Add($"ID: {cliente.Id} - Nome: {cliente.Nome}");
            }
        }

        private void AdicionarConta_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um cliente.");
                return;
            }

            string tipoConta = (cbTipoConta.SelectedItem as ComboBoxItem).Content.ToString();
            int idClienteSelecionado = int.Parse(lstClientes.SelectedItem.ToString().Split('-')[0].Replace("ID: ", "").Trim());
            Cliente clienteSelecionado = gerenciadorClientes.ObterCliente(idClienteSelecionado);

            Conta novaConta;
            if (tipoConta == "Conta Corrente")
            {
                novaConta = new ContaCorrente { Numero = gerenciadorDeContas.ObterTodasContas().Count + 1 };
            }
            else
            {
                novaConta = new Poupanca { Numero = gerenciadorDeContas.ObterTodasContas().Count + 1 };
            }

            clienteSelecionado.AdicionarConta(novaConta);
            gerenciadorDeContas.AdicionarConta(novaConta);

            AtualizarListaContas(clienteSelecionado);
        }

        private void AtualizarListaContas(Cliente cliente)
        {
            lstContasCliente.Items.Clear();
            foreach (var conta in cliente.Contas)
            {
                lstContasCliente.Items.Add($"Conta Número: {conta.Numero} - Saldo: {conta.Saldo}");
            }
        }
    }
}

