namespace petshopia_API.Model
{
    public class Dono
    {
        protected Dono(){}
        public Dono(int donoId, string nome, string endereco, string Telefone)
        {
            this.DonoId = donoId;
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefone = Telefone;
        }

        public int DonoId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}