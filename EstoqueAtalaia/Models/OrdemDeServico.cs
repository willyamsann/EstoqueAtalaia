using System;

namespace EstoqueAtalaia.Models
{
    public class OrdemDeServico
    {
        public new int Id { get; set; }

        public string NameCliente { get; set; }

        public string EmailCliente { get; set; }

        public string TelefoneCliente { get; set; }

        public string Aparelho { get; set; }

        public string Detalhes { get; set; }

        public string Reclamacao { get; set; }

        public string Diagnostico { get; set; }

        public string Garantia { get; set; }

        public float ValorServico { get; set; }

        public float ValorPeca { get; set; }

        public float ValorTotal { get; set; }

        public DateTime DataAbertura { get; set; }

    }
}
