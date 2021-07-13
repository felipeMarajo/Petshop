import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Animal } from '../Model/Animal';
import { AlojamentoService } from '../service/alojamento.service';
import { AnimalService } from '../service/animal.service';

@Component({
  selector: 'app-animais',
  templateUrl: './animais.component.html',
  styleUrls: ['./animais.component.css']
})
export class AnimaisComponent implements OnInit {

  private _filtroAnimal: string = '';
  clickButton: boolean = false;
  animalForm = {} as FormGroup; // Linnk Form com validação por exemplo.

  animal: any; // Usado para cópiar o animal que vem do form
  animais: any =[];
  animaisFiltrados: any =[];
  animalVerificado: any;

  alojamentosPorStatus: any;

  modoDeSalvamento: string = '';
  estadoSaudeMarcado: number = 0;
  estadoSaudeOriginal: number = 0;
  idAnimalSelecionado: number = -1;

  constructor(
    private animalService: AnimalService,
    private alojamentoService: AlojamentoService,
    private modalService: BsModalService,
    private fb: FormBuilder
    ) { }
  
  ngOnInit() {
    this.validation();
    this.getAnimais();
  }

  get filtroAnimal(): string {
    return this._filtroAnimal;
  }
  
  set filtroAnimal(value: string){
    this._filtroAnimal = value;
    this.animaisFiltrados = this.filtroAnimal ? this.filtrarAlojamentos(this.filtroAnimal) : this.animais;
  }

  filtrarAlojamentos(filtro: string): any{
    filtro = filtro.toLocaleLowerCase();
    return this.animais.filter(
      function (animais:any ) {
        return animais.nome.toLocaleLowerCase().indexOf(filtro) !== -1  || animais.dono.nome.toLocaleLowerCase().indexOf(filtro) !== -1;
      }
    );
  }

  openModal(template: any){
    this.clickButton = true;
    this.animalForm.reset();
    template.show(template);
  }

  validation(){
    this.animalForm = this.fb.group({
      animalId: [''],
      nome: ['',  Validators.required],
      motivacaoInternacao: ['', Validators.required],
      estadoSaudeId: [''],
      donoId: [''],
      dono: this.fb.group({
        donoId: [''],
        nome: ['', Validators.required],
        endereco: ['', Validators.required],
        telefone: ['', Validators.required]
      }),

      idAlojamento: [''],
      foto: ['']
    });
  }

  // Funções de CRUD

  salvarAnimais(template: any, alojamentoSelecionado: any){
    if(this.animalForm.valid){
      if(this.modoDeSalvamento === 'post'){
        this.animal = Object.assign({}, this.animalForm.value);
        this.animal.estadoSaudeId = this.estadoSaudeMarcado;
        this.animal.idAlojamento = parseInt(alojamentoSelecionado);

        delete this.animal.animalId;
        delete this.animal.donoId;
        delete this.animal.dono.donoId;
        
        this.animalService.postAnimal(this.animal).subscribe(
          (novoAnimal) => {
            console.log(novoAnimal);
            this.animalService.putAtualizarAlojamento().subscribe(
              () => {

              }, error => {
                console.log(error);
              }
            );
            template.hide();
            this.getAnimais();
          }, error => {
            console.log(error);
          }
        );
      }else{
        this.animal = Object.assign({}, this.animalForm.value);
        this.animal.estadoSaudeId = this.estadoSaudeMarcado;
        this.animal.idAlojamento = parseInt(alojamentoSelecionado);

        if(this.estadoSaudeOriginal != this.estadoSaudeMarcado && this.estadoSaudeMarcado != 0){
          this.animal.estadoSaudeId = this.estadoSaudeMarcado;
        }else{
          this.animal.estadoSaudeId = this.estadoSaudeOriginal;
        }
        
        this.animalService.putAnimal(this.animal).subscribe(
          (novoAnimal) => {
            console.log(novoAnimal);
            template.hide();
            this.getAnimais();
          }, error => {
            console.log(error);
          }
        );
      }
      
    }
  }

  novoAnimal(template: any){
    this.modoDeSalvamento = 'post';
    this.openModal(template);
    this.getAlojamentosLivresEDoAnimal(-1); // Busca por animal de id -1 ou alojamento livre
  }

  editarAnimal(animal: any, template: any){
    this.clickButton = true;

    this.modoDeSalvamento = 'put';
    this.openModal(template);
    this.animal = animal;
    this.idAnimalSelecionado = this.animal.animalId;
    this.estadoSaudeOriginal = this.animal.estadoSaudeId;
    this.getAlojamentosLivresEDoAnimal(this.animal.animalId);
    this.animalForm.patchValue(animal);

  }

  excluirAnimal(animal: any, template: any) {
    this.openModal(template);
    this.animal = animal;
  }
  
  confirmeDelete(template: any) {
    this.animalService.deleteAnimal(this.animal.animalId).subscribe(
      (response) => {
        console.log(response);
          template.hide();
          this.getAnimais();
        }, error => {
          console.log(error);
        }
    );
  }


  limparForm(template: any){
    // this.animalForm.reset();
    // template.show();
  }


  getAnimais(){
    this.animalService.getAnimal().subscribe(
      (response) => {
        this.animaisFiltrados = this.animais = response
      }, error =>{
        console.log(error);
      }
    );
  }

  getAlojamentosLivresEDoAnimal(idAnimal: number){
    this.alojamentoService.getAlojamentosPorStatusEAnimal(idAnimal).subscribe(
      (response) => {
        this.alojamentosPorStatus = response;
      }, error =>{
        console.log(error);
      }
    );
  }



}
