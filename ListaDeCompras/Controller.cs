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

    #region Métodos



    #endregion

}