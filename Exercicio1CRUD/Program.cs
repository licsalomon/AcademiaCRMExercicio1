using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1CRUD
{
    internal class Program

    {
       
        static void Main(string[] args)
        {
            try
            {
                SqlConnection sqlConnection;
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\maria.laura.salomon\Documents\Academia CRM 2023\Exercicio3Backend\Exercicio3Backend\DatabaseExercicio1.mdf"";Integrated Security=True;Connect Timeout=30";

                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                                
                Paciente paciente = new Paciente();
                Medico medico = new Medico();
                Especialidade especialidade = new Especialidade();
                Agendamento agendamento = new Agendamento();
                MenuGeral menuGeral= new MenuGeral();

                Console.WriteLine("Olá!");
                string inicio = "s";
                string tabela;

                while (inicio == "s" || inicio == "S")
                {
                    

                    Console.WriteLine("------------------------");
                    Console.WriteLine("Menu principal\nCom qual entidade vai trabalhar agora? Selecione uma opção:\n" +
                    "1)Pacientes\n" +
                    "2)Medicos\n" +
                    "3)Especialidades\n" +
                    "4)Agendamentos\n" +
                    "5)Sair do sistema" + "");
                    try
                    {
                        string rta = Console.ReadLine();
                        int resposta =  Int32.Parse(rta);
                       // int resposta = Convert.ToInt32(Console.ReadLine());

                        switch ((Enums.RespostasInicio) resposta)
                        {
                            case Enums.RespostasInicio.Pacientes:
                                tabela = "Pacientes";
                                menuGeral.menuTabelas(sqlConnection, tabela);
                                break;
                            case Enums.RespostasInicio.Medicos:
                                tabela = "Medicos";
                                menuGeral.menuTabelas(sqlConnection, tabela); 
                                break;
                            case Enums.RespostasInicio.Especialidades:
                                tabela = "Especialidades";
                                menuGeral.menuTabelas(sqlConnection, tabela);
                                break;
                            case Enums.RespostasInicio.Agendamentos:
                                tabela = "Agendamentos";
                                menuGeral.menuTabelas(sqlConnection, tabela);
                                break;                           
                            case Enums.RespostasInicio.Sair:
                                break;
                            default:
                                //Console.WriteLine("Escolha errada, por favor selecione uma opção");
                                //break;
                                throw new FormatException();
                        }
                        Console.WriteLine("------------------------");

                        Console.WriteLine("Menu principal\nDeseja escolher outra opção? S ou qualquer tecla para terminar");
                        inicio = Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Escolha errada, lembre que só pode ser um número, tente de novo por favor");
                    }
                }

                sqlConnection.Close();
                Console.WriteLine("Obrigado, volte sempre");

                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Aconteceu um erro, por favor contacte o administrador do sistema");
                Console.WriteLine(ex.Message);
            }
        }


    }
}
