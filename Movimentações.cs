using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario
{
    class Movimentações : IComparable<Movimentações>
    {
        public int ID { get; set; }
        public DateTime data { get; set; }
        public double valor { get; set; }
        public int IDConta { get; set; }
        public int CompareTo(Movimentações obj)
        {
            return data.CompareTo(obj.data);
        }
        public override string ToString()
        {
            return $"{ID} - {data:dd/MM/yyyy} - Valor: R$ {valor}";
        }
    }
}
