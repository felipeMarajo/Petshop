namespace petshopia_API.Model
{
    public class Alojamento
    {
        public Alojamento(){}
        public Alojamento(int alojamentoId, int? animalId, int estadoAlojamentoId)
        {
            this.AlojamentoId = alojamentoId;
            this.AnimalId = animalId;
            this.EstadoAlojamentoId = estadoAlojamentoId;
        }
        public int AlojamentoId { get; set; }
        public int? AnimalId{ get; set; }
        public int EstadoAlojamentoId{ get; set;}
        public EstadoAlojamento EstadoAlojamento { get; set;}
    }
}