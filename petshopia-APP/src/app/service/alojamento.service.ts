import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AlojamentoService {

  baseUrl = 'http://localhost:5000/api/alojamento';

  constructor(private http: HttpClient) { }

  getAlojamentos(){
    return this.http.get(this.baseUrl);
  }

  getAlojamentosPorStatusEAnimal(idAnimal: number){
    return this.http.get(`${this.baseUrl}/getPorStatus/${idAnimal}`);
  }

}
