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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        GerenciadorDeContas gerenciador = new GerenciadorDeContas();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sacar_Click(object sender, RoutedEventArgs e)
        {
            int numeroConta = int.Parse(txtNumeroConta.Text);
            decimal valor = decimal.Parse(txtValor.Text);
            Conta conta = gerenciador.ObterConta(numeroConta);

            if (conta != null)
            {
                conta.Sacar(valor);
                MessageBox.Show($"Saque realizado. Saldo atual: {conta.Saldo}");
            }
            else
            {
                MessageBox.Show("Conta não encontrada.");
            }
        }

        private void Depositar_Click(object sender, RoutedEventArgs e)
        {
            int numeroConta = int.Parse(txtNumeroConta.Text);
            decimal valor = decimal.Parse(txtValor.Text);
            Conta conta = gerenciador.ObterConta(numeroConta);

            if (conta != null)
            {
                conta.Depositar(valor);
                MessageBox.Show($"Depósito realizado. Saldo atual: {conta.Saldo}");
            }
            else
            {
                MessageBox.Show("Conta não encontrada.");
            }
        }
        private void GerenciarClientes_Click(object sender, RoutedEventArgs e)
        {
            Window1 gerenciarClientesWindow = new Window1();
            gerenciarClientesWindow.Show();
        }

    }
}

