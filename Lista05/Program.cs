using Lista05.Controllers;
using System;

namespace Lista05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE TURMAS E ALUNOS\n");

            Console.WriteLine("\nPor favor, escolha a opção desejada: 1 para TURMA , 2 para ALUNO ou 0 para encerrar o programa: ");

            var escolha = Console.ReadLine();

            if (escolha == "1")
            {
                var turmaController = new TurmaController();

                Console.WriteLine("(1) Cadastrar turma");
                Console.WriteLine("(2) Atualizar turma");
                Console.WriteLine("(3) Excluir   turma");
                Console.WriteLine("(4) Consultar turma");
                Console.WriteLine("(0) Encerrar programa");

                try
                {
                    Console.Write("\nEscolha a opção desejada: ");
                    var opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            turmaController.CadastrarTurma();
                            Main(args); //recursividade
                            break;

                        case 2:
                            turmaController.AtualizarTurma();
                            Main(args); //recursividade(looping)
                            break;

                        case 3:
                            turmaController.ExcluirTurma();
                            Main(args);
                            break;

                        case 4:
                            turmaController.ConsultarTurmas();
                            Main(args);
                            break;

                        case 0:
                            Console.WriteLine("\nFIM DO PROGRAMA!");
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nErro: " + e.Message);
                }
            }
            else if (escolha =="2")
            {


                var alunoController = new AlunoController();

                Console.WriteLine("(1) Cadastrar aluno");
                Console.WriteLine("(2) Atualizar aluno");
                Console.WriteLine("(3) Excluir   aluno");
                Console.WriteLine("(4) Consultar aluno");
                Console.WriteLine("(0) Encerrar programa");

                try
                {
                    Console.Write("\nEscolha a opção desejada: ");
                    var opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            alunoController.CadastrarAluno();
                            Main(args); //recursividade
                            break;

                        case 2:
                            alunoController.AtualizarAluno();
                            Main(args); //recursividade(looping)
                            break;

                        case 3:
                            alunoController.ExcluirAluno();
                            Main(args);
                            break;

                        case 4:
                            alunoController.ConsultarAlunos();
                            Main(args);
                            break;

                        case 0:
                            Console.WriteLine("\nFIM DO PROGRAMA!");
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nErro: " + e.Message);
                }

            }
            else if(escolha == "0")
            {
                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
            else
            {
                Console.WriteLine("\nOpção Inválida");
                Console.WriteLine("\nPor favor digite uma opção válida");
                Main(args);
            }



            Console.ReadKey();
        }
    }
}