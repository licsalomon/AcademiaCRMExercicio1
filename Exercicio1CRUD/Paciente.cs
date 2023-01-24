using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Exercicio1CRUD.Enums;

namespace Exercicio1CRUD
{
    internal class Paciente
    {
        string refer, coluna;

        public string[] ListarPacientesOpcoes(string[] dadosAListar)
        {
            Console.WriteLine(
                "0)ID\n" +
                "1)Nome\n" +
                "2)CPF\n");
            string rta = Console.ReadLine();
            int campoSelecionado = Int32.Parse(rta);
            switch ((Enums.CamposPaciente)campoSelecionado)
            {
                case CamposPaciente.NomePaciente:
                    Console.WriteLine("Digite o nome");
                    dadosAListar[(int)DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)DadosAListar.Coluna] = "NomePaciente";
                    break;
                case CamposPaciente.Cpf:
                    Console.WriteLine("Digite o CPF");
                    dadosAListar[(int)DadosAListar.Registro] = Console.ReadLine();
                    dadosAListar[(int)DadosAListar.Coluna] = "Cpf";
                    break;
                case CamposPaciente.Id:
                    Console.WriteLine("Digite o ID");
                    dadosAListar[(int)DadosAListar.Registro] = Console.ReadLine()
                        ;
                    dadosAListar[(int)DadosAListar.Coluna] = "IdPaciente";
                    break;
                default:
                    throw new FormatException();

            }
            return dadosAListar;


        }

    }

}
