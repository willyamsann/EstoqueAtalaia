using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAtalaia.Models
{
    public class User
    {
        public new int Id { get; set; }

        public string Email { get; set;}

        public string Senha { get; set; }

        public bool ativo { get; set; }

        public string Perfil { get; set; }

        public string Nome { get; set; }

    }
}
