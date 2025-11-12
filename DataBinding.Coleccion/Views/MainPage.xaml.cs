using DataBinding.Coleccion.Models;

namespace DataBinding.Coleccion.Views;

public partial class MainPage : ContentPage
{
	private List<OrigenDePaquete> _origenes;
    public MainPage()
	{
        
		InitializeComponent();
        OrigenDePaquete? origenSeleccionado = null;
        _origenes = new List<OrigenDePaquete>();
		CargarDatos();
		OrigenesListView.ItemsSource = _origenes;
        if (_origenes.Count > 0)
        {
          origenSeleccionado = _origenes[0];
        }
        OrigenesListView.ItemsSource = _origenes;
        OrigenesListView.SelectedItem = origenSeleccionado;
    }

	private void CargarDatos()
	{
		_origenes.Add(new OrigenDePaquete
		{
			Nombre = "nuget.org",
			Origen = "https://api.nuget.org/v3/index.json",
			EstaHabilitado = true,
		});

        _origenes.Add(new OrigenDePaquete
        {
            Nombre = "Microsft Visual Studio Offline Packages",
            Origen = "C:\\Program Files(x86)\\Microsoft SDKs\\NugetPackages",
            EstaHabilitado = false,
        });
    }

    private void OnAgregarButton_Clicked(object sender, EventArgs e)
    {
        var origen = new OrigenDePaquete
        {
            Nombre = "Origen del paquete",
            Origen = "URL o ruta del origen del paquete",
            EstaHabilitado = false,
        };
        _origenes.Add(origen);
        OrigenesListView.ItemsSource = null;
        OrigenesListView.ItemsSource=_origenes;
        OrigenesListView.SelectedItem = origen;
    }

    private void OnDeleteButton_Clicked(object sender, EventArgs e)
    {
        OrigenDePaquete seleccionado = 
            (OrigenDePaquete)OrigenesListView.SelectedItem;
        if (seleccionado != null)
        {
            var indice = _origenes.IndexOf(seleccionado);
            OrigenDePaquete? nuevoSeleccionado;
            if (_origenes.Count > 1)
            {
                //Hay mas de un elemento
                if(indice < _origenes.Count - 1)
                {
                    //El elemento seleccionado no es el ultimo
                    nuevoSeleccionado = _origenes[indice + 1];
                }
                else
                {
                    //El elemento seleccionado no es el ultimo
                    nuevoSeleccionado = _origenes[indice - 1];
                }         
            }
            else
            {
                //solo hay un elemento
                nuevoSeleccionado = null;
            }
                _origenes.Remove(seleccionado);
            OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource = _origenes;
            OrigenesListView.SelectedItem = nuevoSeleccionado;
        }
    }

    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        OrigenDePaquete origenSeleccionado =
        (OrigenDePaquete) OrigenesListView.SelectedItem;
        if (origenSeleccionado != null)
        {
            NombreEntry.Text = origenSeleccionado.Nombre;
            OrigenEntry.Text = origenSeleccionado.Origen;
        }
        else
        {
            NombreEntry.Text = string.Empty;
            OrigenEntry.Text = string.Empty;
        }

    }

    private void OnActualizarButton_Clicked(object sender, EventArgs e)
    {
        OrigenDePaquete? origenSeleccionado =
            OrigenesListView.SelectedItem as OrigenDePaquete;
        if ( origenSeleccionado != null)
        {
            origenSeleccionado.Nombre = NombreEntry.Text;
            origenSeleccionado.Origen = OrigenEntry.Text;
            OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource = _origenes;
            OrigenesListView.SelectedItem = origenSeleccionado;
        }
    }
}

