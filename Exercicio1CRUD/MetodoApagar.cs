using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1CRUD
{
    internal class MetodoApagar
    {
        MetodosListar metodosListar = new MetodosListar();
        public void ApagarRegistro(SqlConnection sqlConnection, string refer, string coluna, string tabela)
        {
            metodosListar.ListarComReferencia(sqlConnection, tabela, coluna, refer);
            Console.WriteLine("Tem certeza que quer apagar este registro? S/N");
            string rtaDelete = Console.ReadLine();
            if (rtaDelete == "S" || rtaDelete == "s")
            {
                string apagar = "delete from " + tabela + " where " + coluna + "='" + refer + "'";
                SqlCommand deleteQuery = new SqlCommand(apagar, sqlConnection);

                deleteQuery.ExecuteNonQuery();
                Console.WriteLine("Operação realizada com succeso");
            }
        }
    }
}
