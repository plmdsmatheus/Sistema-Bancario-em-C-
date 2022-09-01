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
                if (id == c1.ID && valor > 0 && valor <= c1.SaldoConta)
                    c1.SaldoConta -= valor;
        }
        public static void Depositar(double valor, int id)
        {
            foreach (Conta c1 in NConta.Listar())
                if (id == c1.ID && valor >0)
                    c1.SaldoConta += valor;
        }
        public static void VerSaldo(int idcliente)
        {
            foreach (Conta conta in NConta.ListarSaldo(idcliente))

                Console.WriteLine(conta);
        }
        public static void Transferencia(double valor, int idd, int idc, int idcliente)
        {
            foreach (Conta c1 in NConta.ListarSaldo(idcliente))
                if (idd == c1.ID && valor > 0 && valor <= c1.SaldoConta)
                    c1.SaldoConta -= valor;
                    foreach (Conta c2 in NConta.Listar())
                        if (idc == c2.ID && valor > 0)
                            c2.SaldoConta += valor;
        }
        public static void VerSaldoAdmin()
        {
            foreach (Conta conta in NConta.Listar())

                Console.WriteLine(conta);
        }
    }
}
