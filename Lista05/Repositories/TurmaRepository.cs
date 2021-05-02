using Dapper;
using Lista05.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lista05.Repositories
{
    public class TurmaRepository
    {   
        public string ConnectionString { get; set; } //String de conexão do banco de dados

        public void Iserir(Turma turma)
        {
            var sql = @"
                    insert into Turma(IdTurma, Nome, DataInicio, DataFim)
                    values(NewId(), @Nome, @DataInicio, @DataFim)
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, turma);
            }

        }
        public void Alterar(Turma turma)
        {
            var sql = @"
                    update Turma set
                        Nome = @Nome,
                        DataInicio = @DataInicio,
                        DataFim = @DataFim
                    where
                        IdTurma = @IdTurma
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, turma);
            }
        }

        public void Excluir(Turma turma)
        {
            var sql = @"
                    delete from Turma
                    where IdTurma = @IdTurma
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, turma);
            }
        }

        public List<Turma> ObterTodos()
        {

            var sql = @"
                    select * from Turma
                    order by Nome
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Turma>(sql)
                    .ToList();
            }
        }

        public Turma ObterPorId(Guid idTurma)
        {

            var sql = @"
                    select * from Turma
                    where IdTurma = @idTurma
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Turma>(sql, new { idTurma })
                    .FirstOrDefault();
            }
        }

    }
}
