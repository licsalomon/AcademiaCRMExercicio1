using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercicio1CRUD.MetodoAtualizar;

namespace Exercicio1CRUD
{
    internal class MetodoInsertar
    {
        string insertQuery;
        string[] dadosNovos = new string[5];
        public void InsertarRegistro(SqlConnection sqlConnection, string tabela)
        {
            if (tabela == Enums.Tabelas.Pacientes.ToString())
            {
                InsertarPaciente();
                insertQuery = "insert into " + tabela + "(NomePaciente, Cpf, EstadoEnderecoPaciente) values" +
                    " ('" + dadosNovos[(int)Enums.CamposPaciente.NomePaciente] +
                    "', '" + dadosNovos[(int)Enums.CamposPaciente.Cpf] +
                    "', '" + dadosNovos[(int)Enums.CamposPaciente.EstadoEnderecoPaciente] +
                    "')";
            }
            else if (tabela == Enums.Tabelas.Medicos.ToString())
            {
                InsertarMedico();
                insertQuery = "insert into " + tabela + "(NomeMedico, Crm, EstadoEnderecoMedico, Especialidade) values" +
                    " ('" + dadosNovos[(int)Enums.CamposMedico.NomeMedico] +
                    "', '" + dadosNovos[(int)Enums.CamposMedico.Crm] +
                    "', '" + dadosNovos[(int)Enums.CamposMedico.EstadoEnderecoMedico] +
                    "', '" + dadosNovos[(int)Enums.CamposMedico.Especialidade] +
                    "')";
            }
            else if (tabela == Enums.Tabelas.Especialidades.ToString())
            {
                InsertarEspecialidade();                
                insertQuery = "insert into " + tabela + "(Nome) values" +
                    " ('" + dadosNovos[(int)Enums.CamposMedico.NomeMedico] +
                    "')";
            }
            else if (tabela == Enums.Tabelas.Agendamentos.ToString())
            {
                InsertarAgendamento();
                insertQuery = "insert into " + tabela + "(IdMedico, IdPaciente, Data, Horario) values" +
                   " ('" + dadosNovos[(int)Enums.CamposAgendamento.IdMedico] +
                   "', '" + dadosNovos[(int)Enums.CamposAgendamento.IdPaciente] +
                   "', '" + dadosNovos[(int)Enums.CamposAgendamento.Data] +
                   "', '" + dadosNovos[(int)Enums.CamposAgendamento.Horario] +
                   "')";

            }
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Registro insertado com sucesso");
        }
        private string[] InsertarMedico()
        {
            Console.WriteLine("Nome médico:");
            dadosNovos[(int)Enums.CamposMedico.NomeMedico] = Console.ReadLine();
            Console.WriteLine("CRM:");
            dadosNovos[(int)Enums.CamposMedico.Crm] = Console.ReadLine();
            Console.WriteLine("Estado endereço médico:");
            dadosNovos[(int)Enums.CamposMedico.EstadoEnderecoMedico] = Console.ReadLine();
            Console.WriteLine("Especialidade:");
            dadosNovos[(int)Enums.CamposMedico.Especialidade] = Console.ReadLine();
            return dadosNovos;
        }
        private string[] InsertarPaciente()
        {
            Console.WriteLine("Nome paciente:");
            dadosNovos[(int)Enums.CamposPaciente.NomePaciente] = Console.ReadLine();
            Console.WriteLine("CPF paciente:");
            dadosNovos[(int)Enums.CamposPaciente.Cpf] = Console.ReadLine();
            Console.WriteLine("Estado endereço paciente:");
            dadosNovos[(int)Enums.CamposPaciente.EstadoEnderecoPaciente] = Console.ReadLine();
            return dadosNovos;
        }
        private string[] InsertarEspecialidade()
        {
            Console.WriteLine("Nome especialidade:");
            dadosNovos[(int)Enums.CamposEspecialidade.Nome] = Console.ReadLine();
            return dadosNovos;
        }
        private string[] InsertarAgendamento()
        {
            Console.WriteLine("Id médico:");
            dadosNovos[(int)Enums.CamposAgendamento.IdMedico] = Console.ReadLine();
            Console.WriteLine("Id paciente");
            dadosNovos[(int)Enums.CamposAgendamento.IdPaciente] = Console.ReadLine();
            //Console.WriteLine("Id especialidade");
            //dadosNovos[(int)Agendamento.CamposAgendamento.IdEspecialidade] = Console.ReadLine();
            Console.WriteLine("Data(YYYY-mm-dd)");
            dadosNovos[(int)Enums.CamposAgendamento.Data] = Console.ReadLine();
            Console.WriteLine("Horario");
            dadosNovos[(int)Enums.CamposAgendamento.Horario] = Console.ReadLine();
            return dadosNovos;
        }
    }
}
