using System;
using System.Collections.Generic;

namespace Dio.Bank
{
    class Program
    {
        static List<Conta> listConta = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirNovaConta();
                        break;
                    case "3":
                        Tranferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços! ");
            Console.WriteLine();
        }

        private static void Tranferir()
        {
            Console.WriteLine("Digite o a conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listConta[indiceContaOrigem].Transferir(valorTransferencia, listConta[indiceContaDestino]);
            
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite a conta para depósito: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listConta[indiceConta].Depositar(valorDeposito);

        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque =  double.Parse(Console.ReadLine());

            listConta[indiceConta].Sacar(valorSaque);

        }

        private static void ListarContas()
        {
            Console.WriteLine("listar contas");
            Console.WriteLine();

            if (listConta.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for(int i = 0; i < listConta.Count; i++ )
            {
                Conta conta = listConta[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirNovaConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine();
            Console.WriteLine("Digite 1 - Para conta fisica");
            Console.WriteLine("Digite 2 - Pra conta juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listConta.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao banco da Família Silva!!!");
            Console.WriteLine();
            Console.WriteLine("Escolha a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
