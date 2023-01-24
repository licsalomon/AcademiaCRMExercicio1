using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1CRUD
{
    internal class Enums
    {
        public enum Tabelas { Pacientes = 1, Medicos, Especialidades, Agendamentos }
        public enum RespostasInicio { Pacientes = 1, Medicos, Especialidades, Agendamentos, Sair }
        public enum Respostas { InsertarRegistro = 1, ListarTodos, ListarComReferencia, ApagarRegistro, AtualizarRegistro, Salir }
        public enum CamposEspecialidade { IdEspecialidade, Nome }
        public enum CamposPaciente { Id, NomePaciente, Cpf, EstadoEnderecoPaciente }
        public enum CamposMedico { IdMedico, NomeMedico, Crm, EstadoEnderecoMedico, Especialidade }
        public enum CamposAgendamento { IdAgendamento, Data, Horario, IdMedico, IdPaciente, IdEspecialidade, Cancelada }
        public enum DadosAListar { Coluna, Registro }

    }
}
