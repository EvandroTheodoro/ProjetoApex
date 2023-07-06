import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Projeto from '../models/projeto.model';

@Injectable({
  providedIn: 'root'
})
export class ProjetoService {

  private urlBase = 'http://localhost:5000/';

  constructor(
    public httpClient: HttpClient
  ) { }

  public adicionar(projeto: Projeto) {
    return this.httpClient.post<Projeto>(this.urlBase + 'projeto/adicionar', projeto);
  }

  public atualizar(projeto: Projeto) {
    return this.httpClient.put<Projeto>(this.urlBase + 'projeto/atualizar', projeto);
  }

  public excluir(id: number) {
    return this.httpClient.delete<any>(this.urlBase + 'projeto/excluir/' + id);
  }

  public obterPorId(id: number) {
    return this.httpClient.get<Projeto>(this.urlBase + 'projeto/obterPorId/' + id);
  }

  public obterTodos() {
    return this.httpClient.get<Projeto[]>(this.urlBase + 'projeto/obterTodos');
  }

}
