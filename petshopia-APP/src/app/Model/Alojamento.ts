import { EstadoAlojamento } from "./EstadoAlojamento";

export interface Alojamento {

    alojamentoId: number; 
    animalId?: number;
    
    estadoAlojamentoId: number; 
    
    statusAlojamento: EstadoAlojamento;

}
