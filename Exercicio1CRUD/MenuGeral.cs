using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercicio1CRUD.Paciente;

namespace Exercicio1CRUD
{
    internal class MenuGeral
    {
        public void menuTabelas(SqlConnection sqlConnection, string tabela)
        {
            string inicio = "s";

            MetodoAtualizar metodoAtualizar = new MetodoAtualizar();
            MetodosListar metodosListar= new MetodosListar();
            MetodoInsertar metodoInsertar = new MetodoInsertar();
            MetodoApagar metodoApagar= new MetodoApagar();
            while (inicio == "s" || inicio == "S")
            {
                Console.Clear();
                Console.WriteLine("------------------------");
                Console.WriteLine("Menu {0} |Selecione uma opção:\n" +
                "1)Insertar um/a {0} \n" +
                "2)Listar todos/as as/os {0} \n" +
                "3)Listar {0} com referencia\n" +
                "4)Apagar um/a {0} pelo nome \n" +
                "5)Atualizar um cadastro dum/a {0}\n" +
                "6)Voltar ao menu principal" + "", tabela);
                string[] dadosParaListar;

                try
                {
                    string rta = Console.ReadLine();
                    int resposta = Int32.Parse(rta);

                    switch ((Enums.Respostas)resposta)
                    {
                        case Enums.Respostas.InsertarRegistro:
                            metodoInsertar.InsertarRegistro(sqlConnection, tabela);
                            break;
                        case Enums.Respostas.ListarTodos:
                            metodosListar.ListarTodos(sqlConnection, tabela); break;
                        case Enums.Respostas.ListarComReferencia:
                             dadosParaListar = metodosListar.ListarComReferenciaOpcoes(tabela);
                            metodosListar.ListarComReferencia(sqlConnection, tabela, dadosParaListar[((int)Enums.DadosAListar.Coluna)], dadosParaListar[((int)Enums.DadosAListar.Registro)]);
                            break;
                        case Enums.Respostas.ApagarRegistro:
                            dadosParaListar = metodosListar.ListarComReferenciaOpcoes(tabela);
                            metodoApagar.ApagarRegistro(sqlConnection, dadosParaListar[((int)Enums.DadosAListar.Registro)], dadosParaListar[((int)Enums.DadosAListar.Coluna)], tabela);
                            break;
                        case Enums.Respostas.AtualizarRegistro:
                            dadosParaListar = metodosListar.ListarComReferenciaOpcoes(tabela);
                            metodoAtualizar.AtualizarRegistro(sqlConnection, dadosParaListar[((int)Enums.DadosAListar.Registro)], dadosParaListar[((int)Enums.DadosAListar.Coluna)], tabela);
                            break;
                        case Enums.Respostas.Salir:
                            break;
                        default:
                            throw new FormatException();
                    }
                }
                catch (RegistroNaoEncontradoException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Escolha errada, lembre que só pode ser um número, tente de novo por favor");
                }
                Console.WriteLine("Deseja escolher outra opção? S ou qualquer tecla para termminar");
                inicio = Console.ReadLine();
                //}


            }
        }
    }
}
