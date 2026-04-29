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
    

    #endregion

}