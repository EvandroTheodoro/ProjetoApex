import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Projeto from 'src/app/models/projeto.model';
import { AlertService } from 'src/app/services/alert.service';
import { ProjetoService } from 'src/app/services/projeto.service';

@Component({
  selector: 'app-projeto-cadastro',
  templateUrl: './projeto-cadastro.component.html',
  styleUrls: ['./projeto-cadastro.component.css']
})
export class ProjetoCadastroComponent implements OnInit {

  public formulario: FormGroup;
  public formSubmetido: boolean = false;
  public id: number = null;

  constructor(
    public formBuilder: FormBuilder,
    public router: Router,
    public activatedRoute: ActivatedRoute,
    public projetoService: ProjetoService,
    public alertService: AlertService
  ) {}

  public ngOnInit(): void {
    this.id = this.activatedRoute.snapshot.params['id'];

    if (this.id == null) {
      document.title = 'Cadastro de projeto';
    } else {
      document.title = 'Edição de projeto';
      this.chamarApiParaObterProjetoPorId(this.id);
    }

    this.inicializarConfigForm();
  }

  public submeterForm(): void {
    this.formSubmetido = true;

    if (this.formulario.invalid) {
      return;
    }

    let projeto: Projeto = new Projeto(this.formulario.getRawValue());

    if (this.id == null) {
      this.chamarApiParaAdicionar(projeto);
    } else {
      this.chamarApiParaAtualizar(projeto);
    }
  }

  private inicializarConfigForm(): void {
    this.formulario = this.formBuilder.group({
      id: [0],
      nomeCliente: [null, [Validators.required, Validators.maxLength(100)]],
      tensao: [null, [Validators.required]],
      potencia: [null, [Validators.required]],
      qntBobinas: [null, [Validators.required]],
      valorProjeto: [null],
    });
  }

  public chamarApiParaAdicionar(projeto: Projeto): void {
    this.projetoService.adicionar(projeto).subscribe((resposta) => {
      if (resposta != null) {
        this.alertService.showToastrSuccess('Projeto cadastrado com sucesso!');
        this.router.navigate(['/projeto/listagem']);
      } else {
        this.alertService.showToastrError('Erro ao cadastrar projeto');

      }
    });
  }

  public chamarApiParaAtualizar(projeto: Projeto): void {
    this.projetoService.atualizar(projeto).subscribe((resposta) => {
      if (resposta != null) {
        this.alertService.showToastrSuccess('Projeto atualizado com sucesso!');
        this.router.navigate(['/projeto/listagem']);
      } else {
        alert('Erro ao atualizar projeto');
      }
    });
  }

  public chamarApiParaObterProjetoPorId(id: number): void {
    this.projetoService.obterPorId(id).subscribe((resposta) => {
      if (resposta != null) {
        this.formulario.patchValue(resposta);
      }
    });
  }

}
