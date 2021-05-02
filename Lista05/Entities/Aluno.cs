using System;
using System.Collections.Generic;
using System.Text;

namespace Lista05.Entities
{
    public class Aluno
    {
        public Guid IdAluno { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public Guid IdTurma{ get; set; }

        //Relacionamento de Associação -> Aluno TEM uma turma 
        public Turma Turma { get; set; }




    }
}
