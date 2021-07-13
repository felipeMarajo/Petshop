import { Dono } from "./Dono";
import { EstadoSaude } from "./EstadoSaude";

export interface Animal {

    animalId?: number; 
    nome: string; 
    donoId: number;  
    dono: Dono;
    motivacaoInternacao: string; 
    estadoSaudeId: number;
    estadoSaude?: EstadoSaude;
    foto: string ;
    iaAlojamento: number;

}
