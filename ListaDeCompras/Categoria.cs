using System.Text.Json.Serialization;

class Categoria
{
    private string nome;
    private string cor;
    private List<Produto> produtos;

    #region Construtores

    public Categoria(string nome, string cor)
    {
        this.nome = nome;
        this.cor = cor;
        this.produtos = new List<Produto>();
    }
    public Categoria()
    {

    }

    #endregion

    #region Getters e Setters

    public string getNome()
    {
        return this.nome;
    }
    public void setNome(string nome)
    {
        this.nome = nome;
    }
    public string getCor()
    {
        return this.cor;
    }
    public void setCor(string cor)
    {
        this.cor = cor;
    }
    public List<Produto> getProdutos()
    {
        return this.produtos;
    }
    public void setProdutos(List<Produto> produtos)
    {
        this.produtos = produtos;
    }

    #endregion

    #region Serializable

    [JsonPropertyName("nome")]
    public string Nome_JSON { get => getNome(); set => setNome(value); }

    [JsonPropertyName("cor")]
    public string Cor_JSON { get => getCor(); set => setCor(value); }

    [JsonPropertyName("produtos")]
    public List<Produto> Produtos_JSON { get => getProdutos(); set => setProdutos(value); }

    #endregion

    #region Métodos

    public string GetNomeComCor()
    {
        string codigo = this.cor.ToLower() switch
        {
            "white" => "\u001b[37m",
            "gray" => "\u001b[90m",
            "red" => "\u001b[31m",
            "blue" => "\u001b[34m",
            "green" => "\u001b[32m",
            "yellow" => "\u001b[33m",
            "cyan" => "\u001b[36m",
            "magenta" => "\u001b[35m",
            _ => "\u001b[0m" // Padrão
        };

        return $"{codigo}{this.nome}\u001b[0m";
    }
    public bool CadastrarProduto()
    {
        Console.Write($"Digite o nome do produto para a categoria '{GetNomeComCor()}': ");
        string nomeProduto = Console.ReadLine() ?? "";

        if (nomeProduto != "")
        {
            Console.Write("Digite a unidade de medida do produto(ex: kg, unidade, litro, caixa): ");
            string unidadeDeMedida = Console.ReadLine() ?? "Não Informada";

            Console.Write("Digite o preço do produto: ");
            double preco;

            while (!double.TryParse(Console.ReadLine(), out preco))
            {
                Console.Write("Valor inválido. Digite um número para o preço: ");
            }

            Produto novoProduto = new Produto(nomeProduto, unidadeDeMedida, preco);
            this.produtos.Add(novoProduto);
            return true;
        }
        else
        {
            Console.WriteLine("Nome inválido. Tente Novamente!");
            return false;
        }
    }
    public bool VisualizarProdutos()
    {
        if (this.produtos.Count > 0)
        {
            int posicao = 1;
            Console.WriteLine("Produtos Cadastrados:");
            foreach (var produto in this.produtos)
            {
                Console.WriteLine($"{posicao} - {produto.getNome()}");
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
    public bool ExcluirProduto()
    {
        if (this.produtos.Count > 0)
        {
            VisualizarProdutos();

            int numeroProduto = 0;

            try
            {
                Console.Write("Digite o número do produto que deseja excluir: ");
                numeroProduto = int.Parse(Console.ReadLine() ?? "0");

                if (numeroProduto > 0 && numeroProduto <= produtos.Count)
                {
                    Console.WriteLine($"Tem certeza que deseja excluir o produto '{produtos[numeroProduto - 1].getNome()}'? (s/n)");
                    char resposta = Console.ReadKey(true).KeyChar;

                    if (resposta == 's' || resposta == 'S')
                    {
                        string nomeProdutoExcluido = produtos[numeroProduto - 1].getNome();
                        produtos.RemoveAt(numeroProduto - 1);
                        Console.WriteLine($"Produto '{nomeProdutoExcluido}' excluído com sucesso!");
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
                    Console.WriteLine("Número do produto inválido. Tente novamente.");
                    return false;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
                return false;
            }

        }
        else
        {
            Console.WriteLine("Nenhum produto cadastrado para esta categoria.");
            return false;
        }
    }
    public bool EditarProduto()
    {
        if (this.produtos.Count > 0)
        {
            VisualizarProdutos();

            int numeroProduto = 0;

            try
            {
                Console.Write("Digite o número do produto que deseja editar: ");
                numeroProduto = int.Parse(Console.ReadLine() ?? "0");

                if (numeroProduto > 0 && numeroProduto <= produtos.Count)
                {
                    bool verificaEditado = false;

                    Console.Write($"Digite o novo nome para o produto '{produtos[numeroProduto - 1].getNome()}' (ou pressione Enter para manter o nome atual): ");
                    string novoNome = Console.ReadLine() ?? "";

                    if (novoNome != "")
                    {
                        produtos[numeroProduto - 1].setNome(novoNome);
                        verificaEditado = true;
                    }

                    Console.Write($"Digite a nova unidade de medida para o produto '{produtos[numeroProduto - 1].getNome()}' (ou pressione Enter para manter a unidade de medida atual): ");
                    string novaUnidadeDeMedida = Console.ReadLine() ?? "";

                    if (novaUnidadeDeMedida != "")
                    {
                        produtos[numeroProduto - 1].setUnidadeDeMedida(novaUnidadeDeMedida);
                        verificaEditado = true;
                    }

                    Console.Write($"Digite o novo preço para o produto '{produtos[numeroProduto - 1].getNome()}' (ou pressione Enter para manter o preço atual): ");
                    string novoPrecoInput = Console.ReadLine() ?? "";

                    if (novoPrecoInput != "")
                    {
                        try
                        {
                            double novoPreco = double.Parse(novoPrecoInput);
                            produtos[numeroProduto - 1].setPreco(novoPreco);
                            verificaEditado = true;
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("Valor inválido para o preço. O preço não foi alterado.");
                        }
                    }

                    if(verificaEditado == true)
                    {
                        Console.WriteLine($"Produto '{produtos[numeroProduto - 1].getNome()}' editado com sucesso!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma alteração foi feita no produto.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Número do produto inválido. Tente novamente.");
                    return false;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
                return false;
            }

        }
        else
        {
            Console.WriteLine("Nenhum produto cadastrado para esta categoria.");
            return false;
        }
    }

    #endregion

}