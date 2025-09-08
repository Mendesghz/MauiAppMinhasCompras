namespace MauiAppMinhasCompras
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        // Agora é Button, não mais object
        private Button CounterBtn;

        public MainPage()
        {
            // Inicializa os componentes do XAML
            InitializeComponent();

            // Caso não esteja usando XAML, crie o botão aqui:
            CounterBtn = new Button
            {
                Text = "Click me"
            };

            CounterBtn.Clicked += OnCounterClicked;

            // Adiciona o botão na tela
            Content = new StackLayout
            {
                Children = { CounterBtn }
            };
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
