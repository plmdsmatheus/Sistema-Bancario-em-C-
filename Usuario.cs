using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario
{
    class Usuario : IComparable<Usuario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }
        public int CompareTo(Usuario obj)
        {
            return Nome.CompareTo(obj.Nome);
        }
        public override string ToString()
        {
            return $"{Id} - {Nome}";
        }
    }
}
