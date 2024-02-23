using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Data.Entities
{
    public class Contato
    {
        private Guid _id;
        private string _nome;
        private string _email;
        private string _telefone;
        private DateTime _dataHoraCadastro;
        private int _ativos;

        public Guid Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefone { get => _telefone; set => _telefone = value; }
        public DateTime DataHoraCadastro { get => _dataHoraCadastro; set => _dataHoraCadastro = value; }
        public int Ativo { get => _ativos; set => _ativos = value; }
    }
}
