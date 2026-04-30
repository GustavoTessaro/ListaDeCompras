using System.Text.Json.Serialization;

class Produto
{
    private string nome;
    private string unidadeDeMedida;
    private double preco;

    #region Construtores

    public Produto(string nome, string unidadeDeMedida, double preco)
    {
        this.nome = nome;
        this.unidadeDeMedida = unidadeDeMedida;
        this.preco = preco;
    }
    public Produto()
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
    public string getUnidadeDeMedida()
    {
        return this.unidadeDeMedida;
    }
    public void setUnidadeDeMedida(string unidadeDeMedida)
    {
        this.unidadeDeMedida = unidadeDeMedida;
    }
    public double getPreco()
    {
        return this.preco;
    }
    public void setPreco(double preco)
    {
        this.preco = preco;
    }

    #endregion

    #region Serializable

    [JsonPropertyName("nome")]
    public string Nome_JSON { get => getNome(); set => setNome(value); }

    [JsonPropertyName("unidadeDeMedida")]
    public string UnidadeDeMedida_JSON { get => getUnidadeDeMedida(); set => setUnidadeDeMedida(value); }

    [JsonPropertyName("preco")]
    public double Preco_JSON { get => getPreco(); set => setPreco(value); }

    #endregion

}