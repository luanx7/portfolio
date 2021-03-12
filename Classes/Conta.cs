using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta{get; set;}
        private double Saldo{get; set;}
        private double Credito{get; set;}
        private string Nome{get; set;}
        private string numConta{get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome, int numConta)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            this.numConta = numConta.ToString("0000");
        }

        public bool Sacar( double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito*.1)){
                Console.WriteLine("Saldo insuficiente para saque!");
                return false;
            }
            this.Saldo -= valorSaque;
            return true;
        }

        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Saldo >= valorTransferencia)
            {
                this.Sacar(valorTransferencia);
                contaDestino.Depositar(valorTransferencia);   
            }else{
                Console.WriteLine("Saldo insuficiente para realizar a tranferência!");
            } 
        }

        public override string ToString()
        {
            string retorno;
            retorno = "Número da Conta: " + this.numConta + " / ";
            retorno += "Nome: " + this.Nome + " / ";
            if(this.TipoConta == (TipoConta)1){
                retorno += "Tipo de conta: Pessoa Física / ";
            } else{
                retorno += "Tipo de conta: Pessoa Jurídica / ";}         
            retorno += "Saldo " + this.Saldo + " / ";
            retorno += "Crédito: " + this.Credito;

            return retorno;
        }

    }
}       