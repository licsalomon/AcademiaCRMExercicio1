using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercicio1CRUD.Enums;

namespace Exercicio1CRUD
{
    internal class MetodosListar
    {
        string[] dadosAListar = { "refer", "coluna" };
        Medico medico= new Medico();
        Paciente paciente= new Paciente();
        Agendamento agendamento= new Agendamento();
        Especialidade especialidade= new Especialidade();
        
        public void ListarTodos(SqlConnection sqlConnection, string tabela)
        {
            string selectQuery = "select * from " + tabela;
            SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
            SqlDataReader dataReader = selectCommand.ExecuteReader();

            ExibirLista(dataReader);

            dataReader.Close();
        }
        public void ListarComReferencia(SqlConnection sqlConnection, string tabela, string coluna, string refer)
        {
            try
            {
                string selectQuery = "select * from " + tabela + " where " + coluna + "='" + refer + "'";
                SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);

                SqlDataReader dataReader = selectCommand.ExecuteReader();

                ExibirLista(dataReader);

                if (!dataReader.HasRows)
                {
                    dataReader.Close();
                    throw new RegistroNaoEncontradoException("Registro não encontrado, tente de novo por favor");
                }
                dataReader.Close();
            }
            finally { }
        }
        private void ExibirLista(SqlDataReader dataReader)
        {
            Console.Clear();
            Console.WriteLine("Lista de registros");
            while (dataReader.Read())
            {
                int fieldCount = dataReader.FieldCount;
                Console.Write("Registro - ");
                for (int i = 0; i < fieldCount; i++)
                {
                    Console.Write(dataReader.GetName(i).ToString() + ": " + dataReader.GetValue(i).ToString() + " | ");
                };
                Console.WriteLine("");
            }
            Console.WriteLine("");

        }
        public string[] ListarComReferenciaOpcoes(string tabela)
        {

            Console.Clear();
            Console.WriteLine("Por favor, escolha o campo para selecionar o registro: \n");

            switch (tabela)
            {
                case "Pacientes":
                    return dadosAListar = paciente.ListarPacientesOpcoes(dadosAListar);
                  
                case "Medicos":
                    return dadosAListar = medico.ListarMedicosOpcoes(dadosAListar);
                    
                case "Especialidades":
                    return dadosAListar = especialidade.ListarEspecialidadesOpcoes(dadosAListar);
                case "Agendamentos":
                    return dadosAListar = agendamento.ListarAgendamentosOpcoes(dadosAListar);
                default:
                    throw new FormatException();
            }


        }
    }
}
