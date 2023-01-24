using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercicio1CRUD.Enums;

namespace Exercicio1CRUD
{
    internal class MetodoAtualizar
    {
        string campoAtualizado, colunaAtualizada;
        MetodosListar metodosListar= new MetodosListar();   
        public void AtualizarRegistro(SqlConnection sqlConnection, string refer, string coluna, string tabela)
        {
            metodosListar.ListarComReferencia(sqlConnection, tabela, coluna, refer);
            Console.WriteLine("Tem certeza que quer atualizar este registro? S/N");
            string rtaDelete = Console.ReadLine();

            if (rtaDelete == "S" || rtaDelete == "s")
            {
                Console.WriteLine("Que dados gostaria de atualizar?\n ");
                if (tabela == Tabelas.Pacientes.ToString())
                {
                    Console.WriteLine("1)Nome \n 2)Cpf \n 3)Estado");
                    int opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case (int)Enums.CamposPaciente.NomePaciente:
                            Console.WriteLine("Escreva o novo nome");
                            campoAtualizado = Console.ReadLine();
                            colunaAtualizada = Enums.CamposPaciente.NomePaciente.ToString();
                            break;
                        case (int)Enums.CamposPaciente.Cpf:
                            Console.WriteLine("Escreva o novo CPF");
                            campoAtualizado = Console.ReadLine();
                            colunaAtualizada = Enums.CamposPaciente.Cpf.ToString();
                            break;
                        case (int)Enums.CamposPaciente.EstadoEnderecoPaciente:
                            Console.WriteLine("Escreva o novo Estado");
                            campoAtualizado = Console.ReadLine();
                            colunaAtualizada = Enums.CamposPaciente.EstadoEnderecoPaciente.ToString();
                            break;
                        default:
                            Console.WriteLine("Opção errada, tente de novo por favor");
                            break;
                    }
                }
                else if (tabela == Tabelas.Medicos.ToString())
                {
                    Console.WriteLine("1)Nome \n2)Crm \n3)Estado \n4)Especialidade");
                    int opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case (int)Enums.CamposMedico.NomeMedico:
                            Console.WriteLine("Escreva o novo nome");
                            campoAtualizado = Console.ReadLine();
                            colunaAtualizada = Enums.CamposMedico.NomeMedico.ToString();
                            break;
                        case (int)Enums.CamposMedico.Crm:
                            Console.WriteLine("Escreva o novo Crm");
                            campoAtualizado = Console.ReadLine();
                            colunaAtualizada = Enums.CamposMedico.Crm.ToString();
                            break;
                        case (int)Enums.CamposMedico.EstadoEnderecoMedico:
                            Console.WriteLine("Escreva o novo Estado");
                            campoAtualizado = Console.ReadLine();
                            colunaAtualizada = Enums.CamposMedico.EstadoEnderecoMedico.ToString();
                            break;
                        case (int)Enums.CamposMedico.Especialidade:
                            Console.WriteLine("Escreva a nova especialidade");
                            campoAtualizado = Console.ReadLine();
                            colunaAtualizada = Enums.CamposMedico.Especialidade.ToString();
                            break;
                        default:
                            Console.WriteLine("Opção errada, tente de novo por favor");
                            break;

                    }
                }
                else if (tabela == Tabelas.Especialidades.ToString())
                {
                    Console.WriteLine("1)Nome");
                    Console.WriteLine("Escreva o novo nome");
                    campoAtualizado = Console.ReadLine();
                  //  colunaAtualizada = Especialidade.CamposEspecialidade.Nome.ToString();
                }
                else if (tabela == Tabelas.Agendamentos.ToString())
                {
                    Console.WriteLine("1)Data \n2)Horario \n6)Cancelar");
                    int opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case (int)Enums.CamposAgendamento.Data:
                            Console.WriteLine("Escreva a nova data(YYYY-mm-dd)");
                            campoAtualizado = Console.ReadLine();
                            colunaAtualizada = Enums.CamposAgendamento.Data.ToString();
                            break;
                        case (int)Enums.CamposAgendamento.Horario:
                            Console.WriteLine("Escreva o novo Horario");
                            campoAtualizado = Console.ReadLine();
                            colunaAtualizada = Enums.CamposAgendamento.Horario.ToString();
                            break;
                        case (int)Enums.CamposAgendamento.Cancelada:
                            Console.WriteLine("Certeza que quer cancelar o agendamento?");
                           string rtaCancelar = Console.ReadLine().ToLower();
                            if(rtaCancelar == "s")
                            {
                                campoAtualizado = "s";
                                colunaAtualizada = Enums.CamposAgendamento.Cancelada.ToString();
                                break;
                            }else { break; }
                                                    
                        default:
                            Console.WriteLine("Opção errada, tente de novo por favor");
                            break;
                    }
                }

                string atualizar = "update " + tabela + " set " + colunaAtualizada + "='" + campoAtualizado + "' where " + coluna + "='" + refer + "'";
                SqlCommand updateQuery = new SqlCommand(atualizar, sqlConnection);
                updateQuery.ExecuteNonQuery();

                Console.WriteLine("Operação realizada com succeso");
            }
        }
      
  
    }

}
