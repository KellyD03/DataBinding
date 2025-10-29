using DataBindind.DataObject2.Models;

namespace DataBindind.DataObject2
{
    public partial class MainPage : ContentPage
    {

        private Contador contador;
        public MainPage()
        {
            InitializeComponent();
            contador = new Contador();
            BindingContext = contador;
            //ConteoLabel.Text = contador.Conteo.ToString();
        }

        private void OnReiniciarButton_Clicked(object sender, EventArgs e)
        {
            contador.Reiniciar();
            //ConteoLabel.Text = contador.Conteo.ToString();
        }

        private void OnContarButton_Clicked(object sender, EventArgs e)
        {
            contador.Contar();
            //ConteoLabel.Text = contador.Conteo.ToString();
        }


    }
}
