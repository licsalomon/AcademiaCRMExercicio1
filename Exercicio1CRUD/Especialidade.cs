using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercicio1CRUD.Medico;
using static Exercicio1CRUD.Paciente;

namespace Exercicio1CRUD
{
    internal class Especialidade
    {
        public string[] ListarEspecialidadesOpcoes(string[] dadosAListar)
        {
            Console.WriteLine(
                "0)ID\n" +
               "1)Nome\n");

            string rta = Console.ReadLine();
            int campoSelecionado = Int32.Parse(rta);
            switch ((Enums.CamposEspecialidade)campoSelecionado)
            {
                case Enums.CamposEspecialidade.Nome:
                    Console.WriteLine("Digite o nome");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "Nome";
                    break;
                case Enums.CamposEspecialidade.IdEspecialidade:
                    Console.WriteLine("Digite o ID");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "IdEspecialidade";
                    break;
                default:
                    throw new FormatException();

            }
            return dadosAListar;

        }
    }
}
