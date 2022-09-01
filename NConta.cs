using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario
{
    class NConta
    {
        private static List<Conta> contas = new List<Conta>();
        public static void Inserir(Conta con)
        {
            int id = 0;
            foreach (Conta obj in contas)
                if (obj.ID > id) id = obj.ID;
            id++;
            con.ID = id;
            contas.Add(con);
        }
        public static List<Conta> Listar()
        {
            contas.Sort();
            return contas;
        }
        public static Conta Listar(int id)
        {
            foreach (Conta obj in contas)
                if (obj.ID == id) return obj;
            return null;
        }
        public static void Excluir(Conta con)
        {
            Conta atual = Listar(con.ID);
            if (atual != null)
                contas.Remove(atual);
            
        }
        public static List<Conta> ListarSaldos()
        {
            contas.Sort();
            return contas;
        }
        public static List<Conta> ListarSaldo(int idcliente)
        {
            return contas.Where(x => x.IDCliente == idcliente).ToList();
        }
    }
}
