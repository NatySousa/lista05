using Dapper;
using Lista05.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lista05.Repositories
{
    public class AlunoRepository
    {

        public string ConnectionString { get; set; } //String de conexão do banco de dados

        public void Iserir(Aluno aluno)
        {
            var sql = @"
                    insert into Aluno(IdAluno, Nome, Matricula, Cpf, IdTurma)
                    values(NewId(), @Nome, @Matricula, @Cpf, @IdTurma)
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, aluno);
            }

        }
        public void Alterar(Aluno aluno)
        {
            var sql = @"
                    update Aluno set
                        Nome = @Nome,
                        Matricula = @Matricula,
                        Cpf = @Cpf,
                        IdTurma = @IdTurma
                    where
                        IdAluno = @IdAluno
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, aluno);
            }
        }

        public void Excluir(Aluno aluno)
        {
            var sql = @"
                    delete from Aluno
                    where IdAluno = @IdAluno
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, aluno);
            }
        }

        public List<Aluno> ObterTodos()
        {

            var sql = @"
                    select * from Aluno
                    order by Cpf
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Aluno>(sql)
                    .ToList();
            }
        }

        public Aluno ObterPorId(Guid idAluno)
        {

            var sql = @"
                    select * from Aluno
                    where IdAluno = @idAluno
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Aluno>(sql, new { idAluno })
                    .FirstOrDefault();
            }
        }

    }
}
    

