using System.Text.Json.Serialization;

class ListaDeCompra
{
    private string nome;
    private string status;
    private int totalDeProdutos;
    private double valorTotal;
    private DateTime dataCriacao;
    private List<Categoria> categorias;

    #region Construtores

    public ListaDeCompra(string nome)
    {
        this.nome = nome;
        this.status = "Aberta";
        this.totalDeProdutos = 0;
        this.valorTotal = 0.0;
        this.dataCriacao = DateTime.Now;
        this.categorias = new List<Categoria>();
    }
    public ListaDeCompra()
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
    public string getStatus()
    {
        return this.status;
    }
    public void setStatus(string status)
    {
        this.status = status;
    }
    public int getTotalDeProdutos()
    {
        return this.totalDeProdutos;
    }
    public void setTotalDeProdutos(int totalDeProdutos)
    {
        this.totalDeProdutos = totalDeProdutos;
    }
    public DateTime getDataCriacao()
    {
        return this.dataCriacao;
    }
    public void setDataCriacao(DateTime dataCriacao)
    {
        this.dataCriacao = dataCriacao;
    }
    public double getValorTotal()
    {
        return this.valorTotal;
    }
    public void setValorTotal(double valorTotal)
    {
        this.valorTotal = valorTotal;
    }
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

    [JsonPropertyName("nome")]
    public string Nome_JSON { get => getNome(); set => setNome(value); }
    [JsonPropertyName("status")]
    public string Status_JSON { get => getStatus(); set => setStatus(value); }
    [JsonPropertyName("totalDeProdutos")]
    public int TotalDeProdutos_JSON { get => getTotalDeProdutos(); set => setTotalDeProdutos(value); }

    [JsonPropertyName("valorTotal")]
    public double ValorTotal_JSON { get => getValorTotal(); set => setValorTotal(value); }

    [JsonPropertyName("dataCriacao")]
    public DateTime DataCriacao_JSON { get => getDataCriacao(); set => setDataCriacao(value); }

    [JsonPropertyName("categorias")]
    public List<Categoria> Categorias_JSON { get => getCategorias(); set => setCategorias(value); }

    #endregion

    #region Métodos

    public bool CadastrarItens(List<Categoria> categoriasParametro, Controller controller)
    {
        if (categoriasParametro.Count == 0)
        {
            Console.WriteLine("Nenhuma categoria foi adicionada à lista de compras.");
            return false;
        }
        else
        {
            bool verificaCategorias = controller.VisualizarCategorias();

            if (verificaCategorias == true)
            {
                int numeroCategoria = 0;

                try
                {
                    Console.Write("Digite o número da categoria para a qual deseja adicionar o produto: ");
                    numeroCategoria = int.Parse(Console.ReadLine() ?? "0");

                    if (numeroCategoria > 0 && numeroCategoria <= categoriasParametro.Count)
                    {
                        Categoria categoriaSelecionada = categoriasParametro[numeroCategoria - 1];

                        verificaCategorias = categoriaSelecionada.VisualizarProdutos();

                        if (verificaCategorias == true)
                        {
                            Console.Write($"Digite o número do produto para o qual deseja adicionar à lista de compras {nome}: ");
                            int numeroProduto = int.Parse(Console.ReadLine() ?? "0");

                            if (numeroProduto > 0 && numeroProduto <= categoriaSelecionada.getProdutos().Count)
                            {
                                Produto produtoSelecionado = categoriaSelecionada.getProdutos()[numeroProduto - 1];

                                Console.Write($"Digite a quantidade do produto '{produtoSelecionado.getNome()}' que deseja adicionar à lista de compras '{nome}': ");
                                double quantidade = double.Parse(Console.ReadLine() ?? "0");

                                produtoSelecionado.setQuantidade(quantidade);

                                Categoria categoriaParaAdicionar = new Categoria(categoriaSelecionada.getNome(), categoriaSelecionada.getCor());
                                categoriaParaAdicionar.getProdutos().Add(produtoSelecionado);

                                if (categorias.Count > 0)
                                {
                                    bool verificaCategoriaExistente = false;

                                    foreach (Categoria categoria in categorias)
                                    {
                                        if (categoria.getNome() == categoriaParaAdicionar.getNome())
                                        {
                                            categoria.getProdutos().Add(produtoSelecionado);
                                            totalDeProdutos++;
                                            valorTotal += produtoSelecionado.getPreco() * produtoSelecionado.getQuantidade();
                                            verificaCategoriaExistente = true;
                                            break;
                                        }
                                    }

                                    if (verificaCategoriaExistente == false)
                                    {
                                        categorias.Add(categoriaParaAdicionar);
                                        totalDeProdutos++;
                                        valorTotal += produtoSelecionado.getPreco() * produtoSelecionado.getQuantidade();
                                    }

                                }
                                else
                                {
                                    categorias.Add(categoriaParaAdicionar);
                                    totalDeProdutos++;
                                    valorTotal += produtoSelecionado.getPreco() * produtoSelecionado.getQuantidade();
                                }

                                Console.WriteLine($"Produto '{produtoSelecionado.getNome()}' adicionado à lista de compras '{nome}' com sucesso!");

                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Número do produto inválido. Tente novamente.");
                                return false;
                            }
                        }
                        else
                        {
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
                Console.WriteLine("Nenhuma categoria cadastrada. Cadastre uma categoria antes de visualizar os produtos.");
                return false;
            }
        }
    }
    public bool VisualizarItens()
    {
        if (categorias.Count == 0)
        {
            Console.WriteLine("Não há Itens nesta lista de compras.");
            return false;
        }
        else
        {
            Console.WriteLine($"Itens da Lista de Compras \"{nome}\": ");

            int posicaoCategorias = 1;

            foreach (Categoria categoria in categorias)
            {
                Console.WriteLine($"\n{posicaoCategorias} - Categoria: {categoria.GetNomeComCor()}");

                int posicaoProdutos = 1;

                foreach (Produto produto in categoria.getProdutos())
                {
                    Console.WriteLine($"{posicaoProdutos} - {produto.getNome()} ({produto.getUnidadeDeMedida()}): R$ {produto.getPreco():F2} - Quantidade: {produto.getQuantidade()} - Subtotal: R$ {(produto.getPreco() * produto.getQuantidade()):F2}");
                    posicaoProdutos++;
                }
                posicaoCategorias++;
            }

            return true;
        }
    }
    public bool ExcluirItens()
    {
        if (categorias.Count == 0)
        {
            Console.WriteLine("Não há Itens nesta lista de compras para excluir.");
            return false;
        }
        else
        {
            bool verificaItens = VisualizarItens();

            int numeroCategoria = 0;

            try
            {
                Console.Write("Digite o número da categoria do produto que deseja excluir: ");
                numeroCategoria = int.Parse(Console.ReadLine() ?? "0");

                if (numeroCategoria > 0 && numeroCategoria <= categorias.Count)
                {
                    bool verificaProdutos = categorias[numeroCategoria - 1].VisualizarProdutos();

                    if (verificaProdutos == true)
                    {
                        Console.Write($"Digite o número do produto que deseja excluir da lista de compras '{nome}': ");
                        int numeroProduto = int.Parse(Console.ReadLine() ?? "0");

                        if (numeroProduto > 0 && numeroProduto <= categorias[numeroCategoria - 1].getProdutos().Count)
                        {
                            Produto produtoSelecionado = categorias[numeroCategoria - 1].getProdutos()[numeroProduto - 1];

                            valorTotal -= produtoSelecionado.getPreco() * produtoSelecionado.getQuantidade();
                            totalDeProdutos--;

                            categorias[numeroCategoria - 1].getProdutos().RemoveAt(numeroProduto - 1);

                            if (categorias[numeroCategoria - 1].getProdutos().Count == 0)
                            {
                                categorias.RemoveAt(numeroCategoria - 1);
                            }

                            Console.WriteLine($"Produto '{produtoSelecionado.getNome()}' excluído da lista de compras '{nome}' com sucesso!");

                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Número do produto inválido. Tente novamente.");
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Número da categoria inválido. Tente novamente.");
                    return false;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Número inválido. Tente Novamente!");
                return false;
            }
        }
    }

    #endregion

}