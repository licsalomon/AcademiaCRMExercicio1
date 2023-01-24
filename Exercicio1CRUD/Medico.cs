using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercicio1CRUD.Enums;
using static Exercicio1CRUD.Paciente;

namespace Exercicio1CRUD
{
    internal class Medico
    {
        public string[] ListarMedicosOpcoes(string[] dadosAListar)
        {
            Console.WriteLine(
                "0)ID\n" +
                "1)Nome\n" +
                "2)CRM\n");
            string rta = Console.ReadLine();
            int campoSelecionado = Int32.Parse(rta);
            switch ((Enums.CamposMedico)campoSelecionado)
            {
                case Enums.CamposMedico.NomeMedico:
                    Console.WriteLine("Digite o nome");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "NomeMedico";
                    break;
                case Enums.CamposMedico.Crm:
                    Console.WriteLine("Digite o CRM");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "Crm";
                    break;
                case Enums.CamposMedico.IdMedico:
                    Console.WriteLine("Digite o ID");
                    dadosAListar[(int)Enums.DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)Enums.DadosAListar.Coluna] = "IdMedico";
                    break;
                default:
                    throw new FormatException();
            }
            return dadosAListar;
        }
    }
}
