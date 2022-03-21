using DigiBank.Contratos;

namespace DigiBank.Classes
{
    public abstract class Conta : Banco, IConta
    {
        public Conta()
        {
            this.NumeroAgencia = "0001";
            Conta.NumeroDaContaSequncial++;
            this.Movimentacoes = new List<Extrato>();
        }
        public double Saldo { get; protected set; }
        public string NumeroAgencia { get; private set; }
        public string NumeroConta { get; protected set; }
        public static int NumeroDaContaSequncial { get; private set; }
        private List<Extrato> Movimentacoes;
        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Deposito", valor));
            this.Saldo += valor;
        }
         public bool Saca(double valor)
        {
            if (valor > this.ConsultaSaldo())
                return false;

            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));

                this.Saldo -= valor;
                return true;
        }
        public string GetCodigoDoBanco()
        {
            return this.CodigoDoBanco;
        }

        public string GetNumeroDaConta()
        {
            return this.NumeroConta;
        }

        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        public List<Extrato> Extrato()
        {
            return this.Movimentacoes;
        }
    }
}