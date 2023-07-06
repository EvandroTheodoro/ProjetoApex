import { Component, OnInit } from '@angular/core';
import Projeto from 'src/app/models/projeto.model';
import { AlertService } from 'src/app/services/alert.service';
import { ProjetoService } from 'src/app/services/projeto.service';

@Component({
  selector: 'app-projeto-listagem',
  templateUrl: './projeto-listagem.component.html',
  styleUrls: ['./projeto-listagem.component.css']
})
export class ProjetoListagemComponent implements OnInit {

  public listaProjeto: Projeto[] = [];

  constructor(
    public projetoService: ProjetoService,
    public alertService: AlertService
  ) { }

  public ngOnInit(): void {
    document.title = 'Listagem de projetos';

    this.obterProjetosDaApi();
  }

  public obterProjetosDaApi(): void {
    // subscribe: oque o service tem que fazer quando tiver o retorno da api
    this.projetoService.obterTodos().subscribe(resposta => {

      if(resposta != null) {
        this.listaProjeto = resposta;
      } else {
        this.alertService.showToastrError('Erro na requisição com o servidor');
      }

    });
  }

  public confirmarEExcluir(id: number):void{
    this.alertService.alertConfirm({
    title: 'Atenção',
    text: 'Você deseja realmente excluir o registro?',
    confirmButtonText: 'Sim',
    confirmButtonColor: "green",
    showCancelButton: true,
    cancelButtonText: 'Não',
    cancelButtonColor: "red",
    fn: () =>{
      this.chamarApiParaexcluir(id);
    },
    fnCancel: () => {

    }
  });


}

  public chamarApiParaexcluir(id: number): void {
    this.projetoService.excluir(id).subscribe(resposta => {
      this.alertService.showToastrSuccess('O projeto foi excluído com sucesso!');
      this.obterProjetosDaApi();
    });
  }

}
