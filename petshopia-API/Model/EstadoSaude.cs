namespace petshopia_API.Model
{
    public class EstadoSaude
    {
        protected EstadoSaude(){}
        public EstadoSaude(int estadoSaudeId, string descricao)
        {
            this.EstadoSaudeId = estadoSaudeId;
            this.Descricao = descricao;
        }

        public int EstadoSaudeId { get; set; }
        public string Descricao { get; set; }
        
    }
}