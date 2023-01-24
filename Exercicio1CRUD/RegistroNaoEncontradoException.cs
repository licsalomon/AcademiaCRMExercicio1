using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1CRUD
{
    internal class RegistroNaoEncontradoException : Exception
    {
        public RegistroNaoEncontradoException(string messagem) : base(messagem)
        {
        }
    }
}
