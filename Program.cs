using System;
using Aula03Colecoes.models;
using Aula03Colecoes.models.Enuns;

namespace Aula03Colecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            CriarLista();
            ExibirLista();
            ExemplosListasColecoes();
        }

        private const int V = 5;

        //CRIANDO A LISTA
        static List<Funcionario> lista = new List<Funcionario>();

        //MENU
        public static void ExemplosListasColecoes()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("****** Exemplos - Aula 03 Listas e Coleções ******");
            Console.WriteLine("==================================================");
            CriarLista();
            int opcaoEscolhida = 0;
            do
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("---Digite o número referente a opção desejada: ---");
                Console.WriteLine("1 - Obter por ID 1");
                Console.WriteLine("2 - Adicionar funcionario");
                Console.WriteLine("3 - Obter por ID pesquisa");
                Console.WriteLine("4 - Obter por salário digitado");
                Console.WriteLine("5 - Obter por nome aproximado");
                Console.WriteLine("6 - Obter por Funcionários recentes");
                Console.WriteLine("7 - Obter por Estatisticas");
                Console.WriteLine("8 - Validar Salário");
                Console.WriteLine("9 - Validar Nome ");
                Console.WriteLine("10 - Obter por Tipo");
                Console.WriteLine("==================================================");
                Console.WriteLine("-----Ou tecle qualquer outro número para sair-----");
                Console.WriteLine("==================================================");

                opcaoEscolhida = int.Parse(Console.ReadLine());
                string mensagem = string.Empty;
                switch (opcaoEscolhida)
                {
                    case 1:
                        ObterPorId();
                        break;
                    case 2:
                        AdicionarFuncionario();
                        break;
                    case 3:
                        Console.WriteLine("Digite o ID do funcionário que você deseja buscar: ");
                        int id = int.Parse(Console.ReadLine());
                        ObterPorId(id);
                        break;
                    case 4:
                        Console.WriteLine("Digite o salário para obter todos acima do valor indicado: ");
                        decimal salario = decimal.Parse(Console.ReadLine());
                        ObterPorSalario(salario);
                        break;
                    case 5:
                        BuscarPorNomeAproximado();
                        break;
                    case 6:
                        ObterFuncionariosRecentes();
                        break;
                    case 7:
                        ObterEstatisticas();
                        break;
                    case 8:

                        break;
                    case 9:

                        break;
                    case 10:
                        ObterPortipo();
                        break;
                    default:
                        Console.WriteLine("Saindo do sistema....");
                        break;
                }
            } while (opcaoEscolhida >= 1 && opcaoEscolhida <= 10);
            Console.WriteLine("==================================================");
            Console.WriteLine("* Obrigado por utilizar o sistema e volte sempre *");
            Console.WriteLine("==================================================");
        }

        //BUSCA ID 1
        public static void ObterPorId()
        {
            lista = lista.FindAll(x => x.Id == 1);
            ExibirLista();
        }

        //NOVO FUNCIONARIO
        public static void AdicionarFuncionario()
        {
            Funcionario f = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            string nomeDigitado = Console.ReadLine();
            if (ValidarNome(nomeDigitado) == true)
            {
                f.Nome = nomeDigitado;
            }
            else
            {
                return;
            }

            //f.Nome = Console.ReadLine();

            //Console.WriteLine("Digite o ID: ");
            //f.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o salário: ");
            decimal salarioDigitado = decimal.Parse(Console.ReadLine());
            //f.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de admissão: ");
            DateTime admissaoDigitado = DateTime.Parse(Console.ReadLine());
            //f.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if (ValidarSalarioAdmissao(salarioDigitado, admissaoDigitado))
            {
                f.Salario = salarioDigitado;
                f.DataAdmissao = admissaoDigitado;
            }

            lista.Add(f);
            ExibirLista();
        }

        //BUSCA ID POR PESQUISA
        public static void ObterPorId(int id)
        {
            Funcionario fBusca = lista.Find(x => x.Id == id);
            Console.WriteLine($"Personagem encontrado: {fBusca.Nome}");
        }

        //FILTRA POR SALARIO
        public static void ObterPorSalario(decimal valor)
        {
            lista = lista.FindAll(x => x.Salario >= valor);
            ExibirLista();
        }

        //ORDENANDO POR CRITERIO 
        public static void Odernar()
        {
            lista = lista.OrderBy(x => x.Nome).ToList();
            ExibirLista();
        }

        //CONTAR ITENS DA LISTA
        public static void ContarFuncionarios()
        {
            int qtd = lista.Count();
            Console.WriteLine($"Existem {qtd} funcionarios.");
        }

        //SOMAR VALORES DA PROPRIEDADE COMUM ENTRE OBJETOS DE UMA LISTA
        public static void SomarSalarios()
        {
            decimal somatorio = lista.Sum(x => x.Salario);
            Console.WriteLine(string.Format("A soma dos salários é {0:c2}.", somatorio));
        }

        //EXIBIR APRENDIZES
        public static void ExibirAprendizes()
        {

            int qtd = lista.Count();

            lista = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.Aprendiz);
            Console.WriteLine($"Existem {qtd} funcionarios.");

        }

        // BUSCAR POR NOME APROXIMADO
        public static void BuscarPorNomeAproximado()
        {
            Console.WriteLine("Digite o nome do funcionário:");
            string nomeBusca = Console.ReadLine().ToLower(); List<Funcionario> funcionariosEncontrados = lista.FindAll(x => x.Nome.ToLower().Contains(nomeBusca));

            if (funcionariosEncontrados.Count > 0)
            {
                Console.WriteLine("Funcionários encontrados:");
                foreach (var funcionario in funcionariosEncontrados)
                {
                    Console.WriteLine($"Nome: {funcionario.Nome}, ID: {funcionario.Id}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum funcionário encontrado com o nome informado.");
            }
        }

        //REMOVER POR CPF
        public static void BuscarPorCpfRemover()
        {
            Funcionario fBusca = lista.Find(x => x.Cpf == " ");
            lista.Remove(fBusca);
            Console.WriteLine($"Personagem removido: {fBusca.Nome} \nLista Atualizada: \n ");

            ExibirLista();
        }

        //REMOVER POR ID
        public static void RemoverIdMenor4()
        {

            lista.RemoveAll(x => x.Id < 4);

            ExibirLista();
        }

        //EXIBIR LISTA
        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "===============================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += "===============================\n";
                Console.WriteLine(dados);
            }

        }


        // OBTER FUNCIONÁRIOS RECENTES E EXIBIR EM ORDEM DECRESCENTE DE SALÁRIO
        public static void ObterFuncionariosRecentes()
        {
            // Remover funcionários com ID menor que 4
            lista.RemoveAll(x => x.Id < 4);

            // Filtrar a lista em ordem decrescente de salário
            List<Funcionario> funcionariosOrdenadosPorSalario = lista.OrderByDescending(x => x.Salario).ToList();

            Console.WriteLine("Funcionários com ID maior ou igual a 4, ordenados por salário decrescente:");
            ExibirLista(); //funcionariosOrdenadosPorSalario
        }

        // OBTER ESTATÍSTICAS
        public static void ObterEstatisticas()
        {
            int quantidadeFuncionarios = lista.Count;
            decimal somatorioSalarios = lista.Sum(x => x.Salario);

            Console.WriteLine($"Quantidade de funcionários: {quantidadeFuncionarios}");
            Console.WriteLine($"Somatório de salários: {somatorioSalarios:c2}");
        }


        // VALIDAR SALÁRIO E DATA DE ADMISSÃO
        public static bool ValidarSalarioAdmissao(decimal salarioDigitado, DateTime admissaoDigitado)
        {
            if (salarioDigitado <= 0 || admissaoDigitado > DateTime.Now)
            {
                Console.WriteLine("O salário ou a data de admissão estão com parametros errados.");
                return false;
            }

            return true;
        }

        // VALIDAR NOME
        public static bool ValidarNome(string nomeDigitado)
        {
            if (nomeDigitado.Length < 2)
            {
                Console.WriteLine("O nome deve conter pelo menos 2 caracteres.");
                return false;
            }
            else
            {
                return true;
            }
        }

        //FUNCIONARIOS PRÉ CRIADOS

        // OBTER POR TIPO
        public static void ObterPorTipo()
        {
            Console.WriteLine("Digite o número referente ao tipo de funcionário:");
            Console.WriteLine("1 - CLT");
            Console.WriteLine("2 - Estagiário");
            Console.WriteLine("3 - Aprendiz");

            if (Enum.TryParse<TipoFuncionarioEnum>(Console.ReadLine(), out TipoFuncionarioEnum tipo))
            {
                List<Funcionario> funcionariosDoTipo = lista.FindAll(x => x.TipoFuncionario == tipo);
                ExibirLista();
            }
            else
            {
                Console.WriteLine("Tipo de funcionário inválido.");
            }
        }

        public static void ObterPortipo()
        {


            Console.WriteLine("1 - CLT\n 2 - Aprendiz ");
            int opcaoEscolhida = int.Parse(Console.ReadLine());

            if (opcaoEscolhida == 1)
            {

                var listaFiltrada = lista.Where(x => x.TipoFuncionario == TipoFuncionarioEnum.CLT);
                foreach (var x in listaFiltrada) ;


            }


        }

        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Baguete";
            f2.Cpf = "12345678910";
            f2.DataAdmissao = DateTime.Parse("01/01/2000");
            f2.Salario = 100.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Neymar 2";
            f3.Cpf = "12345678910";
            f3.DataAdmissao = DateTime.Parse("01/01/2000");
            f3.Salario = 100.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Neymar ama a Bruna";
            f4.Cpf = "12345678910";
            f4.DataAdmissao = DateTime.Parse("01/01/2000");
            f4.Salario = 100.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Neymar aposentado";
            f5.Cpf = "12345678910";
            f5.DataAdmissao = DateTime.Parse("01/01/2000");
            f5.Salario = 100.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Obrigado Aninha <3";
            f6.Cpf = "12345678910";
            f6.DataAdmissao = DateTime.Parse("01/01/2000");
            f6.Salario = 100.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);

        }
    }
}