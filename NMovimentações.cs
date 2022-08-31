using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario
{
    class NMovimentações
    {
        private static List<Movimentações> mov = new List<Movimentações>();
        public static int Inserir(Movimentações m)
        {
            int id = 0;
            foreach (Movimentações obj in mov)
                if (obj.ID > id) id = obj.ID;
            id++;
            m.ID = id;
            mov.Add(m);

            return id;
        }
        public static List<Movimentações> Listar()
        {
            mov.Sort();
            return mov;

        }
        public static List<Movimentações> listar(Conta con)
        {
            List<Movimentações> m1 = new List<Movimentações>();
            foreach (Movimentações obj in mov)
                if (obj.IDConta == con.ID) m1.Add(obj);
            m1.Sort();
            return m1;
        }
        public static void Sacar(double valor, int id)
        {
            foreach (Conta c1 in NConta.Listar())
                if (id == c1.ID)
                    foreach (Conta con in NConta.ListarSaldos())
                        if (valor < con.SaldoConta)
                            con.SaldoConta -= valor;
        }
        public static void Depositar(double valor, int id)
        {
            foreach (Conta c1 in NConta.Listar())
                if (id == c1.ID)
                    foreach (Conta con in NConta.ListarSaldos())
                        if (valor > 0)
                            con.SaldoConta += valor;
        }
        public static void VerSaldo()
        {
            foreach (Conta conta in NConta.ListarSaldos())
                Console.WriteLine(conta);
        }
    }
}
