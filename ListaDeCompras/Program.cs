using System.Text.Json;

class Program
{
    static string nomeArquivo = "Serializable.json";
    static void salvar(Controller controller)
    {
        string jsonString = JsonSerializer.Serialize(controller, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("Serializable.json", jsonString);
    }
    static Controller lerController()
    {
        if (File.Exists("Serializable.json"))
        {
            string jsonString = File.ReadAllText("Serializable.json");
            return JsonSerializer.Deserialize<Controller>(jsonString) ?? new Controller();
        }
        return new Controller();
    }
    static int ObterEscolhaMenuPrincipal()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Lista de Compras");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Gerenciar Categorias");
            Console.WriteLine("2 - Gerenciar Produtos");
            Console.WriteLine("3 - Gerenciar Lista de Compras");
            Console.WriteLine("4 - Gerenciar Itens da Lista de Compras");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    static int ObterEscolhaMenuCategorias()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Categorias");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar Categoria");
            Console.WriteLine("2 - Editar Categoria");
            Console.WriteLine("3 - Excluir Categoria");
            Console.WriteLine("4 - Visualizar Categorias");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    static int ObterEscolhaMenuProdutos()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Produtos");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar Produto");
            Console.WriteLine("2 - Editar Produto");
            Console.WriteLine("3 - Excluir Produto");
            Console.WriteLine("4 - Visualizar Produtos");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    static int ObterEscolhaMenuListaDeCompras()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Lista de Compras");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar Lista de Compras");
            Console.WriteLine("2 - Editar Lista de Compras");
            Console.WriteLine("3 - Excluir Lista de Compras");
            Console.WriteLine("4 - Visualizar Listas de Compras");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5);

        return opcao;
    }
    static int ObterEscolhaMenuItensListaDeCompras()
    {
        int opcao = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Itens da Lista de Compras");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar Item na Lista de Compras");
            Console.WriteLine("2 - Excluir Item da Lista de Compras");
            Console.WriteLine("3 - Visualizar Itens da Lista de Compras");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4);

        return opcao;
    }
    static void Main(string[] args)
    {
        Controller controller = lerController();

        int opcao = 0;

        do
        {
            opcao = ObterEscolhaMenuPrincipal();

            switch (opcao)
            {
                case 1:
                    #region Gerenciar Categorias

                    int opcaoCategorias = 0;
                    bool verificaCategorias = false;

                    do
                    {
                        opcaoCategorias = ObterEscolhaMenuCategorias();

                        switch (opcaoCategorias)
                        {
                            case 1:
                                Console.Clear();
                                verificaCategorias = controller.CadastrarCategoria();
                                if (verificaCategorias == true)
                                {
                                    salvar(controller);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                verificaCategorias = controller.EditarCategoria();
                                if (verificaCategorias == true)
                                {
                                    salvar(controller);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                verificaCategorias = controller.ExcluirCategoria();
                                if (verificaCategorias == true)
                                {
                                    salvar(controller);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                controller.VisualizarCategorias();
                                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 5:
                                Console.WriteLine("Saindo...");
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                        }

                    } while (opcaoCategorias != 5);

                    #endregion
                    break;
                case 2:
                    #region Gerenciar Produtos

                    int opcaoProdutos = 0;
                    bool verificaProdutos = false;

                    do
                    {
                        opcaoProdutos = ObterEscolhaMenuProdutos();

                        switch (opcaoProdutos)
                        {
                            case 1:
                                Console.Clear();
                                verificaProdutos = controller.CadastrarProduto();
                                if (verificaProdutos == true)
                                {
                                    salvar(controller);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                verificaProdutos = controller.EditarProduto();
                                if (verificaProdutos == true)
                                {
                                    salvar(controller);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                verificaProdutos = controller.ExcluirProduto();
                                if (verificaProdutos == true)
                                {
                                    salvar(controller);
                                }
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                controller.VisualizarProdutos();
                                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            case 5:
                                Console.WriteLine("Saindo...");
                                Thread.Sleep(3000);
                                while (Console.KeyAvailable) Console.ReadKey(true);
                                Console.Clear();
                                break;
                        }

                    } while (opcaoProdutos != 5);

                    #endregion
                    break;
                case 3:
                    #region Gerenciar Lista de Compras

                    #endregion
                    break;
                case 4:
                    #region Gerenciar Itens da Lista de Compras

                    #endregion
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    Thread.Sleep(3000);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    Console.Clear();
                    break;
            }

        } while (opcao != 5);

    }
}