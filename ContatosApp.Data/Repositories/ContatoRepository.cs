using ContatosApp.Data.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Data.Repositories
{
    public class ContatoRepository
    {
        //atributo
        private string _connectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDContatosApp;Integrated Security=True";

        public void Insert(Contato contato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"
                    INSERT INTO CONTATO(ID, NOME, EMAIL, TELEFONE, DATAHORACADASTRO)
                    VALUES(@ID, @NOME, @EMAIL, @TELEFONE, @DATAHORACADASTRO)
                ", new
                {
                    @ID = contato.Id,
                    @NOME = contato.Nome,
                    @EMAIL = contato.Email,
                    @TELEFONE = contato.Telefone,
                    @DATAHORACADASTRO = contato.DataHoraCadastro
                });
            }
        }

        public void Update(Contato contato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"
                    UPDATE CONTATO SET NOME=@NOME, EMAIL=@EMAIL, TELEFONE=@TELEFONE
                    WHERE ID=@ID
                ", new
                {
                    @NOME = contato.Nome,
                    @EMAIL = contato.Email,
                    @TELEFONE = contato.Telefone,
                    @ID = contato.Id
                });
            }
        }

        public void Delete(Contato contato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"
                    UPDATE CONTATO SET ATIVO=0 WHERE ID=@ID
                ", new
                {
                    @ID = contato.Id,
                });
            }
        }

        public List<Contato> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Contato>(@"
                    SELECT ID, NOME, EMAIL, TELEFONE, DATAHORACADASTRO, ATIVO FROM CONTATO
                    WHERE ATIVO=1
                ").ToList();
            }
        }

        public Contato? GetById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Contato>(@"
                    SELECT ID, NOME, EMAIL, TELEFONE, DATAHORACADASTRO, ATIVO FROM CONTATO
                    WHERE ATIVO=1 AND ID=@ID
                ", new
                {
                    @ID = id
                }).FirstOrDefault();
            }
        }
    }
}



