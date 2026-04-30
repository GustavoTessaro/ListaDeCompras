using System.Text.Json.Serialization;

class Controller
{
    private List<Categoria> categorias;
    private List<ListaDeCompra> listaDeCompras;

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

        if (verificaCategorias == true)
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

    #region Métodos Lista de Compra

    public bool CadastrarListaDeCompras()
    {
        Console.Write("Digite o nome da lista de compras: ");
        string nomeLista = Console.ReadLine() ?? "";

        if (nomeLista != "")
        {
            ListaDeCompra novaLista = new ListaDeCompra(nomeLista);
            listaDeCompras.Add(novaLista);
            Console.WriteLine($"Lista de compras '{novaLista.getNome()}' cadastrada com sucesso!");
            return true;
        }
        else
        {
            Console.WriteLine("Nome inválido. Tente Novamente!");
            return false;
        }
    }
    public bool ExcluirListaDeCompras()
    {
        bool verificaListas = VisualizarListaDeCompras();

        if (verificaListas == true)
        {
            int numeroLista = 0;

            try
            {
                Console.Write("Digite o número da lista que deseja excluir: ");
                numeroLista = int.Parse(Console.ReadLine() ?? "0");

                if (numeroLista > 0 && numeroLista <= listaDeCompras.Count)
                {
                    ListaDeCompra listaSelecionada = listaDeCompras[numeroLista - 1];

                    if (listaSelecionada.getCategorias().Count == 0)
                    {
                        Console.WriteLine($"Tem certeza que deseja excluir a lista '{listaSelecionada.getNome()}'? (s/n)");
                        char resposta = Console.ReadKey(true).KeyChar;

                        if (resposta == 's' || resposta == 'S')
                        {
                            listaDeCompras.RemoveAt(numeroLista - 1);
                            Console.WriteLine($"Lista '{listaSelecionada.getNome()}' excluída com sucesso!");
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
                        Console.WriteLine("Não é possível excluir uma lista que possui produtos cadastrados.");
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
            Console.WriteLine("Nenhuma lista de compras cadastrada.");
            return false;
        }
    }
    public bool VisualizarListaDeCompras()
    {
        if (listaDeCompras.Count > 0)
        {
            int posicao = 1;
            Console.WriteLine("Listas de Compras Cadastradas:");
            foreach (var lista in listaDeCompras)
            {
                Console.WriteLine($"{posicao} - {lista.getNome()}, total de itens: {lista.getTotalDeProdutos()}, valor total: R${lista.getValorTotal():F2}");
                posicao++;
            }
            return true;
        }
        else
        {
            Console.WriteLine("Nenhuma lista de compras cadastrada.");
            return false;
        }
    }
    public bool EditarListaDeCompras()
    {
        bool verificaListas = VisualizarListaDeCompras();

        if (verificaListas == true)
        {
            int numeroLista = 0;

            try
            {
                Console.Write("Digite o número da lista que deseja editar: ");
                numeroLista = int.Parse(Console.ReadLine() ?? "0");

                if (numeroLista > 0 && numeroLista <= listaDeCompras.Count)
                {
                    bool verificaEditado = false;

                    Console.Write($"Digite o novo nome para a lista '{listaDeCompras[numeroLista - 1].getNome()}' (ou pressione Enter para manter o nome atual): ");
                    string novoNome = Console.ReadLine() ?? "";

                    if (novoNome != "")
                    {
                        listaDeCompras[numeroLista - 1].setNome(novoNome);
                        Console.WriteLine($"Lista de compras '{listaDeCompras[numeroLista - 1].getNome()}' editada com sucesso!");
                        verificaEditado = true;
                    }

                    Console.Write("Digite o novo status para a lista (1 - Aberta / 2 - Concluída) (ou pressione Enter para manter o status atual): ");
                    string novoStatus = Console.ReadLine() ?? "";

                    if (novoStatus != "")
                    {
                        if (novoStatus == "1")
                        {
                            listaDeCompras[numeroLista - 1].setStatus("Aberta");
                            Console.WriteLine($"Status da lista de compras '{listaDeCompras[numeroLista - 1].getNome()}' editado com sucesso!");
                            verificaEditado = true;
                        }
                        else if (novoStatus == "2")
                        {
                            listaDeCompras[numeroLista - 1].setStatus("Concluída");
                            Console.WriteLine($"Status da lista de compras '{listaDeCompras[numeroLista - 1].getNome()}' editado com sucesso!");
                            verificaEditado = true;
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida. Tente Novamente!");
                        }
                    }

                    if (verificaEditado == false)
                    {
                        Console.WriteLine("Nenhuma alteração feita na lista de compras.");
                        return false;
                    }
                    else
                    {
                        return true;
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
            Console.WriteLine("Nenhuma lista de compras cadastrada. Cadastre uma lista antes de editar.");
            return false;
        }
    }

    #endregion

    #region Métodos Itens da Lista de Compras

    public bool VisualizarItensListaDeCompras()
    {
        bool verificaListaDeCompras = VisualizarListaDeCompras();

        if (verificaListaDeCompras == true)
        {
            int numeroLista = 0;

            try
            {
                Console.Write("Digite o número da lista de compras para a qual deseja visualizar os itens: ");
                numeroLista = int.Parse(Console.ReadLine() ?? "0");

                if (numeroLista > 0 && numeroLista <= listaDeCompras.Count)
                {
                    return listaDeCompras[numeroLista - 1].VisualizarItens();
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