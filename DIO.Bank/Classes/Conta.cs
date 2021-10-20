using System;

namespace DIO.Bank
{
    public class Conta
    {
        //Propriedades
        private TipoConta TipoConta { get; set;}  
        private double Saldo { get; set;}  
        private double Credito { get; set;}  
        private string Nome { get; set;}  

        //Metodo Construtor
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        //Metodo para verificar se há saldo e sacar
        public bool Sacar(double valorSaque)
        {
            //Validacao de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)) {
                Console.WriteLine("Saldo Insulficiente!");  
                return false;
            } 

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        //Metodo para depositar algum valor na conta
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        //Metodo para efetuar transferencia entre contas
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        //ToString para representar no Console a instancia 
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }

    }
}   