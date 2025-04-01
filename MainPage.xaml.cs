namespace Ahoracado_74599;

public partial class MainPage : ContentPage
{
	//Regio para configurar las propiedades de IU Elementos de enlace
	#region IU
	
	//Enlace para crear el teclado de la app
	public List<char> Letters
	{
		get => letras;
		set
		{
			letras = value;
			OnPropertyChanged();
		}
	} 

	#endregion
	
	//Region para configurar los campos de la app
	#region Fields
	
		private List<char> letras = new List<char>();  //Inicializa los valores del teclado
	
	#endregion

	//Constructor para invocar todos los elementos
	public MainPage()
	{
		InitializeComponent();
		Letters.AddRange("abcdefghijklmnopqrstuvwxyz"); //Valores del teclado
		BindingContext = this; //Invocar todos los enlaces necesarios
	}
	
//manejador del boton de reiniciar juego
	private void Reset_cliked(object sender, EventArgs e){
		
	}
	
	//manejador del boton del teclado
	private void Button_cliked(object sender, EventArgs e){
		
	}
}

