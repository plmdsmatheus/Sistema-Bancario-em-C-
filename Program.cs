using System;
using System.Collections.Generic;

namespace Sistema_Bancario
{
    internal class Program
    {
        private static bool adminLogado = false;
        private static Cliente clienteLogado = null;
        public static void InserirAdmin()
        {
            Usuario u = new Usuario();
            u.Nome = "admin";
            u.Senha = "admin";
            u.Admin = true;
            NUsuario.Inserir(u);
        }

        static void Main(string[] args)
        {
            InserirAdmin();
            Console.WriteLine("--- Bem-vindo ao BankIF ---");
            int op = 0;
            do
            {
                try
                {
                    op = Menu();
                    switch (op)
                    {
                        case 01:
                            if (Login())
                            {
                                if (adminLogado) MainAdmin();
                                else MainCliente();
                            }
                            else
                                Console.WriteLine("Usuário ou senha inválidos");
                            break;
                        case 02: Cadastro(); break;
                    }
                }
                catch (Exception erro)
                {
                    Console.WriteLine(erro.Message);
                }
            } while (op != 99);
        }
        public static void MainAdmin()
        {
            int op = 0;
            do
            {
                try
                {
                    op = MenuAdmin();
                    switch (op)
                    {
                        case 01: Cadastro(); break;
                        case 02: ListarClientes(); break;
                        case 03: VerSaldoCliente(); break;
                        case 04: ExcluirCliente(); break;
                        case 05: ContaInserir(); break;
                        case 06: ListarContas(); break;
                        case 07: ExcluirContas(); break

                    }
                }
                catch (Exception erro)
                {
                    Console.WriteLine(erro.Message);
                }
            } while (op != 99);

        }
        public static void MainCliente()
        {
            int op = 0;
            do
            {
                try
                {
                    op = MenuCliente();
                    switch (op)
                    {
                        case 01: Depositar(); break;
                        case 02: Saldo(); break;
                        case 03: Sacar(); break;
                    }
                }
                catch (Exception erro)
                {
                    Console.WriteLine(erro.Message);
                }
            } while (op != 99);
        }
        public static int Menu()
        {
            Console.WriteLine();
            Console.WriteLine("----- Selecione ------");
            Console.WriteLine("  01 - Login");
            Console.WriteLine("  02 - Cadastrar-se");
            Console.WriteLine("----------------------");
            Console.WriteLine("  99 - Sair");
            Console.WriteLine("----------------------");
            Console.Write("Opção: ");
            return int.Parse(Console.ReadLine());
        }
        public static int MenuAdmin()
        {
            Console.WriteLine();
            Console.WriteLine("----- Clientes -----");
            Console.WriteLine("  01 - Inserir Cliente");
            Console.WriteLine("  02 - Listar Clientes");
            Console.WriteLine("  03 - Ver saldos dos clientes");
            Console.WriteLine("  04 - Remover cliente");
            Console.WriteLine("----- Contas -----");
            Console.WriteLine("  05 - Inserir Conta");
            Console.WriteLine("  06 - Listar Contas");
            Console.WriteLine("  07 - Remover Conta");
            Console.WriteLine("  08 - Movimentações da Conta");
            Console.WriteLine("----------------------");
            Console.WriteLine("  99 - Logout");
            Console.WriteLine("----------------------");
            Console.Write("Opção: ");
            return int.Parse(Console.ReadLine());
        }
        public static int MenuCliente()
        {
            Console.WriteLine();
            Console.WriteLine($"--- Bem-vindo: {clienteLogado.Nome} ---");
            Console.WriteLine("----------------------");
            Console.WriteLine("  01 - Depositar");
            Console.WriteLine("  02 - Ver Saldo");
            Console.WriteLine("  03 - Sacar");
            Console.WriteLine("----------------------");
            Console.WriteLine("  99 - Logout");
            Console.WriteLine("----------------------");
            Console.Write("Opção: ");
            return int.Parse(Console.ReadLine());
        }


        public static bool Login()
        {
            Console.WriteLine("Informe o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe a senha");
            string senha = Console.ReadLine();
            Usuario u = NUsuario.Autenticar(nome, senha);
            if (u != null)
            {
                adminLogado = u.Admin;
                clienteLogado = NCliente.ListarUsuario(u.Id);
                return true;
            }
            return false;
        }
        public static void Cadastro()
        {
            Console.WriteLine("Informe o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe a senha");
            string senha = Console.ReadLine();
            // Usuario
            Usuario u = new Usuario();
            u.Nome = nome;
            u.Senha = senha;
            u.Admin = false;
            int idUsuario = NUsuario.Inserir(u);
            // Cliente
            Cliente c = new Cliente();
            c.Nome = nome;
            c.IdUsuario = idUsuario;
            NCliente.Inserir(c);
            Console.WriteLine("Cliente cadastrado com sucesso");
        }
        public static void ListarClientes()
        {
            Console.WriteLine("----- Lista de Clientes Cadastrados -----");
            foreach (Cliente obj in NCliente.Listar())
                Console.WriteLine(obj);
        }
        public static void VerSaldoCliente()
        {
            Console.WriteLine("----- Lista de Saldos dos Clientes Cadastrados -----");
            foreach (Cliente obj in NCliente.Saldos())
            {
                Console.WriteLine(obj);
            }

        }
        public static void ExcluirCliente()
        {
            Console.WriteLine("Informe o id do Cliente a ser excluído");
            int id = int.Parse(Console.ReadLine());
            Cliente c = new Cliente();
            c.Id = id;

            NCliente.Excluir(c);

            Console.WriteLine("Cliente removido com sucesso");
        }
        public static void ContaInserir()
        {
            Console.WriteLine("-------- Nova Conta --------");
            Console.WriteLine("Informe o tipo da conta");
            string TipoConta = Console.ReadLine();
            ListarClientes();
            Console.WriteLine("Informe o ID do cliente ");
            int IDCliente = int.Parse(Console.ReadLine());

            Conta con = new Conta();
            con.TipoConta = TipoConta;
            con.SaldoConta = 0;
            con.IDCliente = IDCliente;

            NConta.Inserir(con);

            Console.WriteLine("Conta adicionada com sucesso");


        }
        public static void ListarContas()
        {
            Console.WriteLine("-------- Lista de Contas --------");
            foreach (Conta obj in NConta.Listar())
                Console.WriteLine(obj + " - Cliente: " + NCliente.Listar(obj.IDCliente).Nome);

        }
        public static void ExcluirContas()
        {
            Console.WriteLine("-------- Exclusão de conta--------");
            foreach (Conta obj in NConta.Listar())
                Console.WriteLine(obj);
            Console.WriteLine("Informe o id da conta a ser excluída");
            int IDConta = int.Parse(Console.ReadLine());

            Conta c = new Conta();
            c.ID = IDConta;

            NConta.Excluir(c);

            Console.WriteLine("Conta excluida com sucesso");

        }
        public static void ListarMovimentações()
        {
            Console.WriteLine("-------- Atividades da Conta --------");
            foreach (Movimentações obj in NMovimentações.Listar())
                Console.WriteLine($"Transação {obj.ID} em {obj.data} de {NConta.Listar(obj.IDConta).TipoConta}");

        }
        public static void Sacar()
        {
            Console.WriteLine("-------- Saque --------");
            foreach (Conta obj in NConta.Listar())
                Console.WriteLine(obj);
            Console.WriteLine("Digite o id da conta que deseja sacar");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser sacado");
            double valor = double.Parse(Console.ReadLine());
            Movimentações m = new Movimentações();
            m.IDConta = id;
            m.valor = valor;

            NMovimentações.Sacar(valor, id);

            Console.WriteLine("Saque realizado, espere as cedulas");
        }
        public static void Depositar()
        {
            Console.WriteLine("-------- Deposito --------");
            foreach (Conta obj in NConta.Listar())
                Console.WriteLine(obj);
            Console.WriteLine("Digite o id da conta que deseja depositar");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser depositado");
            double valor = double.Parse(Console.ReadLine());
            Movimentações m = new Movimentações();
            m.IDConta = id;
            m.valor = valor;

            NMovimentações.Depositar(valor, id);
            Console.WriteLine("Deposito realizado com sucesso");

        }
        public static void Saldo()
        {
            NMovimentações.VerSaldo();
        }
        public static void Historico()
        {

        }
    }
}