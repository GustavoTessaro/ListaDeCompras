using System.Text.Json.Serialization;

class Controller
{
    private List<Categoria> categorias;

    #region Construtores
    public Controller()

    {
        this.categorias = new List<Categoria>();
    }

    #endregion

    #region Getters e Setters

    public List<Categoria> getCategorias()
    {
        return this.categorias;
    }
    public void setCategorias(List<Categoria> categorias)
    {
        this.categorias = categorias;
    }

    #endregion

    #region Serializable

    [JsonPropertyName("categorias")]
    public List<Categoria> Categorias_JSON { get => getCategorias(); set => setCategorias(value); }

    #endregion

    #region Métodos Categorias

    public string EscolherCor(string nome)
    {

        int opcao = 0;

        do
        {
            Console.Clear();
            Console.WriteLine($"Escolha uma opção de cor para a categoria {nome}: ");
            Console.WriteLine("1 - Branco   2 - Cinza");
            Console.WriteLine("3 - Vermelho 4 - Azul");
            Console.WriteLine("5 - Verde    6 - Amarelo");
            Console.WriteLine("7 - Ciano    8 - Magenta/Roxo-claro");
            opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);

        } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5 && opcao != 6 && opcao != 7 && opcao != 8);

        if (opcao == 1)
        {
            return "white";
        }
        else if (opcao == 2)
        {
            return "gray";
        }
        else if (opcao == 3)
        {
            return "red";
        }
        else if (opcao == 4)
        {
            return "blue";
        }
        else if (opcao == 5)
        {
            return "green";
        }
        else if (opcao == 6)
        {
            return "yellow";
        }
        else if (opcao == 7)
        {
            return "cyan";
        }
        else if (opcao == 8)
        {
            return "magenta";
        }

        return "white";

    }
    public bool CadastrarCategoria()
    {
        Console.Write("Digite o nome da categoria: ");
        string nome = Console.ReadLine() ?? "";

        if (nome != "")
        {
            string cor = EscolherCor(nome);

            Categoria novaCategoria = new Categoria(nome, cor);
            categorias.Add(novaCategoria);
            Console.WriteLine($"Categoria '{novaCategoria.GetNomeComCor()}' cadastrada com sucesso!");
            return true;
        }
        else
        {
            Console.WriteLine("Nome inválido. Tente Novamente!");
            return false;
        }

    }
    public bool VisualizarCategorias()
    {
        if (categorias.Count > 0)
        {
            int posicao = 1;
            Console.WriteLine("Categorias Cadastradas:");
            foreach (var categoria in categorias)
            {
                Console.WriteLine($"{posicao} - {categoria.GetNomeComCor()}");
                posicao++;
            }
            return true;
        }
        else
        {
            Console.WriteLine("Nenhuma categoria cadastrada.");
            return false;
        }
    }
    public bool EditarCategoria()
    {
        if (categorias.Count > 0)
        {
            VisualizarCategorias();

            int numeroCategoria = 0;

            try
            {
                Console.Write("Digite o número da categoria que deseja editar: ");
                numeroCategoria = int.Parse(Console.ReadLine() ?? "0");

                if (numeroCategoria > 0 && numeroCategoria <= categorias.Count)
                {
                    bool verificaEditado = false;

                    Console.Write($"Digite o novo nome para a categoria '{categorias[numeroCategoria - 1].GetNomeComCor()}' (ou pressione Enter para manter o nome atual): ");
                    string novoNome = Console.ReadLine() ?? "";

                    if (novoNome != "")
                    {
                        categorias[numeroCategoria - 1].setNome(novoNome);
                        verificaEditado = true;
                    }

                    Console.WriteLine($"A cor atual da categoria é '{categorias[numeroCategoria - 1].getCor()}'. Deseja alterar a cor? (s/n)");
                    char resposta = Console.ReadKey(true).KeyChar;

                    if (resposta == 's' || resposta == 'S')
                    {
                        string novaCor = EscolherCor(categorias[numeroCategoria - 1].getNome());
                        categorias[numeroCategoria - 1].setCor(novaCor);
                        verificaEditado = true;
                    }

                    if (verificaEditado == true)
                    {
                        Console.WriteLine($"Categoria '{categorias[numeroCategoria - 1].GetNomeComCor()}' editada com sucesso!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma alteração feita na categoria.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Número inválido. Tente Novamente!");
                    return false;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Número inválido. Tente Novamente!");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Nenhuma categoria cadastrada.");
            return false;
        }
    }
    public bool ExcluirCategoria()
    {
        if (categorias.Count > 0)
        {
            VisualizarCategorias();

            int numeroCategoria = 0;

            try
            {
                Console.Write("Digite o número da categoria que deseja excluir: ");
                numeroCategoria = int.Parse(Console.ReadLine() ?? "0");

                if (numeroCategoria > 0 && numeroCategoria <= categorias.Count)
                {
                    Categoria categoriaSelecionada = categorias[numeroCategoria - 1];

                    if (categoriaSelecionada.getProdutos().Count == 0)
                    {
                        Console.WriteLine($"Tem certeza que deseja excluir a categoria '{categoriaSelecionada.GetNomeComCor()}'? (s/n)");
                        char resposta = Console.ReadKey(true).KeyChar;

                        if (resposta == 's' || resposta == 'S')
                        {
                            categorias.RemoveAt(numeroCategoria - 1);
                            Console.WriteLine($"Categoria '{categoriaSelecionada.GetNomeComCor()}' excluída com sucesso!");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Exclusão cancelada.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não é possível excluir uma categoria que possui produtos cadastrados.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Número inválido. Tente Novamente!");
                    return false;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Número inválido. Tente Novamente!");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Nenhuma categoria cadastrada.");
            return false;
        }
    }

    #endregion

    #region Métodos Produtos

    public bool CadastrarProduto()
    {
        bool verificaCategorias = VisualizarCategorias();

        if (verificaCategorias == true)
        {
            int numeroCategoria = 0;

            try
            {
                Console.Write("Digite o número da categoria para a qual deseja cadastrar um produto: ");
                numeroCategoria = int.Parse(Console.ReadLine() ?? "0");

                if (numeroCategoria > 0 && numeroCategoria <= categorias.Count)
                {
                    return categorias[numeroCategoria - 1].CadastrarProduto();
                }
                else
                {
                    Console.WriteLine("Número inválido. Tente Novamente!");
                    return false;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Número inválido. Tente Novamente!");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Nenhuma categoria cadastrada. Cadastre uma categoria antes de cadastrar um produto.");
            return false;
        }
    }
    public bool EditarProduto()
    {
        bool verificaCategorias = VisualizarCategorias();

        if (verificaCategorias == true)
        {
            int numeroCategoria = 0;

            try
            {
                Console.Write("Digite o número da categoria para a qual deseja Editar um produto: ");
                numeroCategoria = int.Parse(Console.ReadLine() ?? "0");

                if (numeroCategoria > 0 && numeroCategoria <= categorias.Count)
                {
                    return categorias[numeroCategoria - 1].EditarProduto();
                }
                else
                {
                    Console.WriteLine("Número inválido. Tente Novamente!");
                    return false;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Número inválido. Tente Novamente!");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Nenhuma categoria cadastrada. Cadastre uma categoria antes de cadastrar/editar um produto.");
            return false;
        }
    }
    public bool ExcluirProduto()
    {
        bool verificaCategorias = VisualizarCategorias();

        if (verificaCategorias == true)
        {
            int numeroCategoria = 0;

            try
            {
                Console.Write("Digite o número da categoria para a qual deseja excluir um produto: ");
                numeroCategoria = int.Parse(Console.ReadLine() ?? "0");

                if (numeroCategoria > 0 && numeroCategoria <= categorias.Count)
                {
                    return categorias[numeroCategoria - 1].ExcluirProduto();
                }
                else
                {
                    Console.WriteLine("Número inválido. Tente Novamente!");
                    return false;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Número inválido. Tente Novamente!");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Nenhuma categoria cadastrada. Cadastre uma categoria antes de cadastrar/editar/excluir um produto.");
            return false;
        }
    }
    public bool VisualizarProdutos()
    {
        bool verificaCategorias = VisualizarCategorias();

        if(verificaCategorias == true)
        {
            int numeroCategoria = 0;

            try
            {
                Console.Write("Digite o número da categoria para a qual deseja visualizar os produtos: ");
                numeroCategoria = int.Parse(Console.ReadLine() ?? "0");

                if (numeroCategoria > 0 && numeroCategoria <= categorias.Count)
                {
                    return categorias[numeroCategoria - 1].VisualizarProdutos();
                }
                else
                {
                    Console.WriteLine("Número inválido. Tente Novamente!");
                    return false;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Número inválido. Tente Novamente!");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Nenhuma categoria cadastrada. Cadastre uma categoria antes de visualizar os produtos.");
            return false;
        }
    }

    #endregion

}