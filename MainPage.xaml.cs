using System.Diagnostics;
using System.ComponentModel;
using System.Security.AccessControl;

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

	public string CurrentImage
	{
		get => currentimage;
		set
		{
			currentimage = value;
			OnPropertyChanged();
		}
	}
	
	//enlace para visualizar los guiones de las letras de la palabra
	public string SpotLight
	{
		get => spotlight;
		set
		{
			spotlight = value;
			OnPropertyChanged();
		}
	}

	#endregion
	
	//Region para configurar los campos de la app
	#region Fields
	
	List<string> words = new List<string>()
	{
		"python",
		"javascript",
		"maui",
		"csharp",
		"mongodb",
		"sql",
		"xaml",
		"word",
		"excel",
		"powerpoint",
		"code",
		"hotreload",
		"snippets"
	};
	
		private List<char> letras = new List<char>();  //Inicializa los valores del teclado
		
		
		private string currentimage = "Horca.png"; //Imagen inicial

		string respuesta = ""; //Palabra aleatoria

		private string spotlight; //Letras de la palabra
		
		List<char> guessed = new List<char>(); //palabra a adivinar
		
		
		
	#endregion

	//Constructor para invocar todos los elementos
	public MainPage()
	{
		InitializeComponent();
		Letters.AddRange("abcdefghijklmnopqrstuvwxyz"); //Valores del teclado
		BindingContext = this; //Invocar todos los enlaces necesarios
		PickWord(); //Invocar palabra aleatoria
		CalculateWord(respuesta, guessed); //Invoca el calculo de las letras
	}
	
//manejador del boton de reiniciar juego
	private void Reset_cliked(object sender, EventArgs e){
		
	}
	
	//manejador del boton del teclado
	private void Button_cliked(object sender, EventArgs e){
		
	}

	#region Game Engine
	//Metodo de seleccion aleatoria

	public void PickWord()
	{
		respuesta = words[new Random().Next(0, words.Count)];
		Debug.WriteLine(respuesta);
	}

	//Calcular la longitud de la palabra
	public void CalculateWord(string respuesta, List<char> guessed)
	{
		var temp =
			respuesta.Select(x => (guessed.IndexOf(x) >= 0, '_')).ToArray();
		spotlight = string.Join(' ', temp);

	}
	
	#endregion
}

