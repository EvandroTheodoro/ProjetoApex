
export default class Projeto {
  public id: number;
  public nomeCliente: string;
  public tensao: number;
  public potencia: number;
  public qntBobinas: number;
  public valorProjeto: number;

  constructor(obj?: any) {
    if (obj != null) {
        Object.assign(this, obj);
    }
  }

}
