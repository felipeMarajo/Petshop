import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Animal } from '../Model/Animal';

@Injectable({
  providedIn: 'root'
})
export class AnimalService {

  baseUrl = 'http://localhost:5000/api/animal';

  constructor(private http: HttpClient ) { }

  getAnimal(){
    return this.http.get<Animal[]>(this.baseUrl);
  }

  getById(id: number){
    return this.http.get<Animal>(`${this.baseUrl}/${id}`);
  }

  postAnimal(animal: Animal){
    return this.http.post(`${this.baseUrl}`, animal);
  }

  putAnimal(animal: Animal){
    return this.http.put(`${this.baseUrl}/${animal.animalId}`, animal);
  }

  // atualizaalojamentocomids int idAlojamento, int idAnimal, int idEstado ultimoanimal
  putAtualizarAlojamento(){
    return this.http.put(`${this.baseUrl}/ultimoanimal`, {});
  }

  deleteAnimal(animalId: number){
    return this.http.delete(`${this.baseUrl}/${animalId}`);
  }

}
