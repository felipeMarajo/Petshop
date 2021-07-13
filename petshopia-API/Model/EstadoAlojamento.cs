namespace petshopia_API.Model
{
    public class EstadoAlojamento
    {
        protected EstadoAlojamento(){}
        public EstadoAlojamento(int id, string desc)
        {
            this.EstadoAlojamentoId = id;
            this.Descricao = desc;
        }
        public int EstadoAlojamentoId { get; set; }
        public string Descricao { get; set; }
    }
}