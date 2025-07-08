using PinedaLEvaluacion3P.ViewModels;

namespace PinedaLEvaluacion3P.Views;

public partial class ListarProyectosView : ContentPage
{
	public ListarProyectosView()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ListarProyectoViewModel vm)
        {
            vm.CargarProyectosCommand.Execute(null);
        }
    }


}