import { Component, OnInit } from '@angular/core';
import { SeguroService } from '../../services/seguro.service';
import { Seguro, DeletaSeguro } from '../../models/seguro.model';

@Component({
  selector: 'app-seguro',
  templateUrl: './seguro.component.html',
  styleUrls: ['./seguro.component.css'],
  providers:[SeguroService]
})
export class SeguroComponent implements OnInit {

  public seguros:Seguro[]
  public seguro:Seguro = new Seguro();

  constructor(private seguroService:SeguroService) { }

  ngOnInit() {
    this.listarSeguros();
  }

  public deletarSeguro(id:string){
    var seguro = new DeletaSeguro();
    seguro.id = id
    this.seguroService.deletarSeguro(seguro)
    .then((respota)=>{
      alert('excluido')
      this.listarSeguros()
    })
  }

  public salvarSeguro(seguro:Seguro){
     if (seguro.id === undefined) {
       this.seguroService.cadastrarSeguro(seguro).then((resposta)=> {
         alert("Salvo com Sucesso");
         this.listarSeguros()
       })      
     }else{
       this.seguroService.editarSeguro(seguro).then((resposta)=>{
         alert("Atualizado com Sucesso");
         this.listarSeguros();
       })
     }
     this.resetProps();
  }

  obterSeguroPorId(id:string){
    this.seguroService.obterPorId(id).then((resposta)=>{
      this.seguro = resposta;
    })
  }

  listarSeguros(){
    this.seguroService.getSeguros().then((resposta)=>{
      this.seguros=resposta;   
    })
  }

  resetProps(){
    this.seguro = new Seguro();
  }

}
