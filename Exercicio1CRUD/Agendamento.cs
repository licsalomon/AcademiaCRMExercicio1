using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercicio1CRUD.Paciente;

namespace Exercicio1CRUD
{
    internal class Agendamento
    {
        public string[] ListarAgendamentosOpcoes(string[] dadosAListar)
        {
            Console.WriteLine("0)ID\n" +
                "1)Data\n" +
                "2)Horario\n" +
                "3)Id Medico\n" +
                "4)Id Paciente\n" +
                "5)Id Especialidade\n" +
                "6)Cancelada\n"
                );
            string rta = Console.ReadLine();
            int campoSelecionado = Int32.Parse(rta);
            switch ((Enums.CamposAgendamento)campoSelecionado)
            {
                case Enums.CamposAgendamento.IdAgendamento:
                    Console.WriteLine("Digite o id do agendamento");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "IdAgendamento";
                    break;
                case Enums.CamposAgendamento.Data:
                    Console.WriteLine("Digite a data(YYYY-mm-dd)");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "Data";
                    break;
                case Enums.CamposAgendamento.Horario:
                    Console.WriteLine("Digite o horario");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "Horario";
                    break;
                case Enums.CamposAgendamento.IdMedico:
                    Console.WriteLine("Digite o Id do médico");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "IdMedico";
                    break;
                case Enums.CamposAgendamento.IdPaciente:
                    Console.WriteLine("Digite o Id do paciente");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "IdPaciente";
                    break;
                case Enums.CamposAgendamento.IdEspecialidade:
                    Console.WriteLine("Digite o Id da especialidade");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "IdEspecialidade";
                    break;
                case Enums.CamposAgendamento.Cancelada:
                    Console.WriteLine("Digite s para cancelada");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "Cancelada";
                    break;
                default:
                    throw new FormatException();
            }
            return dadosAListar;
            


        }
    }
}
