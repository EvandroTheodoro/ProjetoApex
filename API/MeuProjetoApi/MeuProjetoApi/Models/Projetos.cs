namespace ProjetoFinalApi.Models
{
    public class Projetos
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public int Tensao { get; set; }
        public double Potencia { get; set; }
        public int QntBobinas { get; set; }
        public double? ValorProjeto { get; set; }
    }
}

