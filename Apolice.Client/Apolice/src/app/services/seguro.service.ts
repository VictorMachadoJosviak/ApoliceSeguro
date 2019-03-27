import { Injectable } from '@angular/core';
import { Http, RequestOptions } from "@angular/http";
import { Seguro, DeletaSeguro } from '../models/seguro.model';
import { URL_API } from '../app.api';

@Injectable()
export class SeguroService {

  constructor(private http:Http) { }

  public obterPorId(id:string) : Promise<Seguro> {
    return this.http.get(URL_API+"/api/seguro/obterPorId?id="+id).toPromise()
    .then((resposta)=> resposta.json());
  }

  public getSeguros() : Promise<Seguro[]> {
    return this.http.get(URL_API+"/api/seguro/listar").toPromise()
    .then((resposta)=>resposta.json());
  }

  public deletarSeguro(seguro:DeletaSeguro) : Promise<boolean>{
     return this.http.delete(URL_API+"/api/seguro/deletar",new RequestOptions({
       body:seguro
     })).toPromise().then((resposta)=>  resposta.json());
  }

  public cadastrarSeguro(seguro:Seguro) : Promise<Seguro>{
    return this.http.post(URL_API+"/api/seguro/cadastrar",seguro).toPromise()
       .then((resposta)=> resposta.json());
  }

  public editarSeguro(seguro:Seguro) : Promise<Seguro>{
    return this.http.put(URL_API+"/api/seguro/editar",seguro).toPromise()
       .then((resposta)=> resposta.json());
  }
}
