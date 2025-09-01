using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras
{
    public partial class MainPage : ContentPage
    {
        // Lista original de produtos
        private ObservableCollection<Produto> Produtos { get; set; }

        // Lista filtrada que será exibida na interface
        public ObservableCollection<Produto> ProdutosFiltrados { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Inicializa lista com alguns produtos
            Produtos = new ObservableCollection<Produto>
            {
                new Produto { Nome = "Arroz 5kg" },
                new Produto { Nome = "Feijão Carioca" },
                new Produto { Nome = "Macarrão Espaguete" },
                new Produto { Nome = "Azeite de Oliva" },
                new Produto { Nome = "Leite Integral" },
                new Produto { Nome = "Café Torrado" },
                new Produto { Nome = "Detergente Líquido" },
                new Produto { Nome = "Sabão em Pó" }
            };

            // Inicialmente mostra todos
            ProdutosFiltrados = new ObservableCollection<Produto>(Produtos);

            BindingContext = this;
        }

        // Evento disparado quando o texto do SearchBar muda
        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var textoBusca = e.NewTextValue?.ToLower() ?? string.Empty;

            ProdutosFiltrados.Clear();

            foreach (var produto in Produtos)
            {
                if (produto.Nome.ToLower().Contains(textoBusca))
                    ProdutosFiltrados.Add(produto);
            }
        }
    }

    // Classe simples para representar produto
    public class Produto
    {
        public string Nome { get; set; }
    }
}
