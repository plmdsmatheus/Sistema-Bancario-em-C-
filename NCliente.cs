using System;
using System.Collections.Generic;

namespace Sistema_Bancario
{
    static class NCliente
    {
        private static List<Cliente> clientes = new List<Cliente>();
        public static void Inserir(Cliente c)
        {
            int id = 0;
            foreach (Cliente obj in clientes)
                if (obj.Id > id) id = obj.Id;
            id++;
            c.Id = id;
            clientes.Add(c);
        }
        public static List<Cliente> Listar()
        {
            clientes.Sort();
            return clientes;
        }
            public static Cliente Listar(int id)
        {
            foreach (Cliente obj in clientes)
                if (obj.Id == id) return obj;
            return null;
        }
        public static Cliente ListarUsuario(int idUsuario)
        {
            foreach (Cliente obj in clientes)
                if (obj.IdUsuario == idUsuario) return obj;
            return null;
        }
        public static void Excluir(Cliente c)
        {
            Cliente atual = Listar(c.Id);
            if (atual != null)
                clientes.Remove(atual);
        }
        public static List<Cliente> Saldos()
        {
            clientes.Sort();
            return clientes;
        }
        public static Cliente Saldos(int saldo)
        {
            foreach (Cliente obj in clientes)
                if (obj.Saldo == saldo) return obj;
            return null;
        }
    }
}