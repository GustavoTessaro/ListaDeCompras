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

    

    #endregion

}