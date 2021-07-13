import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AlojamentoService } from '../service/alojamento.service';

@Component({
  selector: 'app-alojamentos',
  templateUrl: './alojamentos.component.html',
  styleUrls: ['./alojamentos.component.css']
})
export class AlojamentosComponent implements OnInit {

  // Propriedades
  private _filtroAlojamento: string = '';

  //
  alojamentos: any = [];
  alojamentosFiltrados: any = [];  

  constructor(private alojamentoService: AlojamentoService) { }

  ngOnInit() {
    this.getAlojamentos();
  }

  get filtroAlojamento(): string {
    return this._filtroAlojamento;
  }
  
  set filtroAlojamento(value: string){
    this._filtroAlojamento = value;
    this.alojamentosFiltrados = this.filtroAlojamento ? this.filtrarAlojamentos(this.filtroAlojamento) : this.alojamentos;
  }

  filtrarAlojamentos(filtro: string): any{
    filtro = filtro.toLocaleLowerCase();
    return this.alojamentos.filter(
      function (alojamento:any ) {
        return alojamento.estadoAlojamento.descricao.toLocaleLowerCase().indexOf(filtro) !== -1;
      }
    );
  }

  getAlojamentos(){
    this.alojamentoService.getAlojamentos().subscribe(
      response => {
        this.alojamentosFiltrados = this.alojamentos = response
      }, error =>{
        console.log(error);
      }
    );
  }

}
