namespace petshopia_API.Model
{
    public class Animal
    {
        protected Animal(){}
        public Animal(int animalId, string nome, Dono dono, string motivacaoInternacao, 
                        int estadoSaudeId, string foto, int idAlojamento)
        {
            this.AnimalId = animalId;
            this.Nome = nome;
            this.Dono = dono;
            // this.DonoId = donoId;
            this.MotivacaoInternacao = motivacaoInternacao;
            this.EstadoSaudeId = estadoSaudeId;
            // this.EstadoSaude = estadoSaude;
            this.Foto = foto;
            this.IdAlojamento = idAlojamento;
        }

        public int AnimalId { get; set; }
        public string Nome { get; set; }
        public int  DonoId { get; set; }
        public Dono Dono { get; set; }
        public string MotivacaoInternacao { get; set; }
        public int EstadoSaudeId { get; set; }
        public EstadoSaude EstadoSaude { get; set; }
        public string Foto { get; set; }
        public int IdAlojamento { get; set; }
    }
}