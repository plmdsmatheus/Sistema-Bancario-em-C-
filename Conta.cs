using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario
{
    class Conta : IComparable<Conta>
    {
        public int ID { get; set; }
        public string TipoConta { get; set; }
        public double SaldoConta { get; set; }
        public int IDCliente { get; set; }
        public int CompareTo(Conta obj)
        {
            return TipoConta.CompareTo(obj.TipoConta);
        }
        public override string ToString()
        {
            return $"{ID} - {TipoConta} - Saldo = R$ {SaldoConta:0.00} - Cliente: {IDCliente}";
        }
    }
}
