using Lista05.Entities;
using Lista05.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Lista05.Controllers
{
    public class TurmaController
    {
        //atributo privado..
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDLista05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //método para executar a gravação de uma turma no banco
        public void CadastrarTurma()
        {
            try
            {
                Console.WriteLine("\n*** CADASTRO DE TURMA ***\n");

                var turma = new Turma();

                Console.Write("Informe o nome da turma....: ");
                turma.Nome = Console.ReadLine();

                Console.Write("Informe a data de início da turma....: ");
                turma.DataInicio = DateTime.Parse(Console.ReadLine());
                Console.Write("Informe a data do fim da turma....: ");
                turma.DataFim = DateTime.Parse(Console.ReadLine());

                var turmaRepository = new TurmaRepository();

                turmaRepository.ConnectionString = connectionString;
                turmaRepository.Iserir(turma);

                Console.WriteLine("\nTurma cadastrada com sucesso!");
            }
            catch (SqlException e) //somente para erros de SQL (banco)
            {
                Console.WriteLine("\nNão foi possível realizar o cadastro da turma.");
                Console.WriteLine("Código do erro: " + e.Number);

                if (e.Number == 8152)
                {
                    Console.WriteLine("O limite de caracteres permitido para um campo foi excedido.");
                }
            }
            catch (Exception e) //qualquer outro tipo de erro
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }


        //método para executar a atualização de uma turma no banco
        public void AtualizarTurma()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DE TURMA\n");

                Console.Write("Informe o ID da turma: ");
                var idTurma = Guid.Parse(Console.ReadLine());

                //instanciando a classe TurmaRepository
                var turmaRepository = new TurmaRepository();
                turmaRepository.ConnectionString = connectionString;

                //buscar a turma no banco de dados atraves do ID..
                var turma = turmaRepository.ObterPorId(idTurma);

                //verificar se a turma foi encontrada..
                if (turma != null)
                {
                    Console.Write("Informe o nome da turma....: ");
                    turma.Nome = Console.ReadLine();

                    Console.Write("Informe a data de início da turma....: ");
                    turma.DataInicio = DateTime.Parse(Console.ReadLine());

                    Console.Write("Informe a data do fim da turma....: ");
                    turma.DataFim = DateTime.Parse(Console.ReadLine());

                    //atualizando os dados da turma
                    turmaRepository.Alterar(turma);
                    Console.WriteLine("\nTurma atualizada com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nTurma não encontrada.Tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para executar a exclusão de uma turma no banco
        public void ExcluirTurma()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE TURMA\n");

                Console.Write("Informe o ID da turma: ");
                var idTurma = Guid.Parse(Console.ReadLine());

                //instanciando a classe TurmaRepository
                var turmaRepository = new TurmaRepository();
                turmaRepository.ConnectionString = connectionString;

                //buscar a turma no banco de dados atraves do ID..
                var turma = turmaRepository.ObterPorId(idTurma);

                //verificar se a turma foi encontrada..
                if (turma != null)
                {
                    //excluindo a turma
                    turmaRepository.Excluir(turma);

                    Console.WriteLine("\nTurma excluída com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nTurma não encontrada.Tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para executar a consulta da turma
        public void ConsultarTurmas()
        {
            try
            {
                //executando a consulta de turmas
                var turmaRepository = new TurmaRepository();
                turmaRepository.ConnectionString = connectionString;

                var turma = turmaRepository.ObterTodos();

                foreach (var item in turma)
                {
                    Console.Write("\nId da Turma.......................: " + item.IdTurma);
                    Console.Write("\nNome da turma.....................: " + item.Nome);
                    Console.Write("\nData de início da turma...........: " + item.DataInicio);
                    Console.WriteLine("\nData do fim da turma............" + item.DataFim);
                    Console.WriteLine("---");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }
    }
}
