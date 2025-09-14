using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Pages;

public partial class RelatorioCategoria : ContentPage
{
    private SQLiteConnection _conexao;
    private List<Produto> _todosProdutos;

    public RelatorioCategoria()
    {
        InitializeComponent();
        _conexao = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "minhascompras.db3"));
        _conexao.CreateTable<Produto>();

        CarregarCategorias();
        CarregarProdutos();
    }

    private void CarregarCategorias()
    {
        // Pegando categorias únicas do banco
        var categorias = _conexao.Table<Produto>()
                                  .Select(p => p.Categoria)
                                  .Distinct()
                                  .ToList();

        pickerCategorias.ItemsSource = categorias;
    }

    private void CarregarProdutos()
    {
        _todosProdutos = _conexao.Table<Produto>().ToList();
        listaProdutos.ItemsSource = _todosProdutos;
        lblTotal.Text = $"Total gasto: R$ {_todosProdutos.Sum(p => p.Total):F2}";
    }

    private void PickerCategorias_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (pickerCategorias.SelectedItem == null)
            return;

        string categoriaSelecionada = pickerCategorias.SelectedItem.ToString();
        var produtosFiltrados = _todosProdutos.Where(p => p.Categoria == categoriaSelecionada).ToList();

        listaProdutos.ItemsSource = produtosFiltrados;
        lblTotal.Text = $"Total gasto: R$ {produtosFiltrados.Sum(p => p.Total):F2}";
    }
}
