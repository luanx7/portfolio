using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            
            string opcaoDoUsuario = ObterOpcaoDoUsuario();
            while (opcaoDoUsuario != "7"){
                VerificaEntrada(opcaoDoUsuario);
                opcaoDoUsuario = ObterOpcaoDoUsuario();
            }
            
        }

        private static string ObterOpcaoDoUsuario(){
                Console.WriteLine();
                Console.WriteLine("DIO Bank a seu dispor!!!");
                Console.WriteLine("Informe a opção desejada: ");
                Console.WriteLine();
                Console.WriteLine("1 - Listar Contas");
                Console.WriteLine("2 - Inserir Conta");
                Console.WriteLine("3 - Transferir");
                Console.WriteLine("4 - Sacar");
                Console.WriteLine("5 - Depositar");
                Console.WriteLine("6 - Limpar");
                Console.WriteLine("7 - Sair");
                Console.WriteLine();

                string entradaDoUsuario = Console.ReadLine();
                Console.WriteLine();
                return entradaDoUsuario;
            }

        public static void VerificaEntrada(string val){
                switch(val)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        //Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

        private static void Transferir()
        {
            Console.WriteLine("Informe o número da conta de origem: ");
            string numContaOrigem = Console.ReadLine();
            
            Console.WriteLine("Informe o número da conta de destino: ");
            string numContaDestino = Console.ReadLine();
            
            Console.WriteLine("Digite o Valor a ser depositado: ");
            double valorTranferencia = double.Parse(Console.ReadLine());
            
            listaContas[int.Parse(numContaOrigem)].Transferir(valorTranferencia, listaContas[int.Parse(numContaDestino)]);
            
        }

        private static void Depositar()
        {
            Console.WriteLine("Informe o número da conta em que será realizado o depósito: ");
            string numConta = Console.ReadLine();
            Console.WriteLine("Digite o Valor a ser depositado: ");
            double entradaDeposito = double.Parse(Console.ReadLine());
            listaContas[int.Parse(numConta.TrimStart('0'))].Depositar(entradaDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Informe o número da conta em que será realizado o saque: ");
            string numConta = Console.ReadLine();
            Console.WriteLine("Digite o valor a ser sacado");
            double entradaSaque = double.Parse(Console.ReadLine());
            listaContas[int.Parse(numConta.TrimStart('0'))].Sacar(entradaSaque);
        }

        private static void ListarContas()
        {
            foreach(Conta conta in listaContas){
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Para inserir uma conta é necessário escolher o tipo de conta: ");
            Console.WriteLine("     1 - Pessoa Física");
            Console.WriteLine("     2 - Pessoa Jurídica");
            Console.Write("Digite o número do tipo de conta a ser inserida: ");
            int entradaTipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Tipo de conta {0} criada com sucesso! Então, vamos prosseguir!", entradaTipo);
            Console.WriteLine("Digite o nome do proprietário da conta: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("Digite o Saldo: ");
            double entradaSaldo = double.Parse(Console.ReadLine());            
            Console.WriteLine("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            int indiceConta = listaContas.Count;
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipo, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome, numConta: indiceConta);             
            listaContas.Add(novaConta);
        }

    }
}



