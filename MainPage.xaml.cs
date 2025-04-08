using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Markup;

namespace Ahoracado_74599;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	// Region PARA CONFIGURAR LAS PROIEDADES DE IU ELEMENTOS DE 
	#region IU
		public List<char> Letters{
			get => letras;
			set {
				letras = value;
				OnPropertyChanged();
			}
		}

		public string Currentimage {
			get => currentimage;
			set{
				currentimage = value;
				OnPropertyChanged();
			}
		}

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

	// Region para onfigurar los campos de la app
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
	private List <char> letras = new List <char> ();
	private string currentimage = "Horca.png";

	string respuesta ="";

	List<char> guessed = new List<char>();

	private string mensaje;

	int mistakes = 0;

	int maxWrong = 6;

	private string spotlight;

	#endregion

	// Constructor para incovar todos los elementos

	public MainPage()
	{
		InitializeComponent();
		Letters.AddRange("abcdefghijklmnñopqrstuvwxyz"); // valores del teclado
		BindingContext = this;
		PickWord();
		CalculateWords(respuesta, guessed);
	}

    private void CalculateWords()
    {
        throw new NotImplementedException();
    }


    // Manejo del boton de reiniciar Juego
    private void Reset_Clicked(object sender, EventArgs e){

	}

// Manejador del boton del teclado
	private void Button_Clicked(object sender, EventArgs e){
		
	}

	#region Game Engine
	public void PickWord(){
		respuesta = words[new Random().Next(0,words.Count)];
		Debug.WriteLine(respuesta);
	}
	public void CalculateWords(string respuesta ,List<char> guessed){
		var tem = 
			respuesta.Select(x => (guessed.IndexOf(x)>= 0, '_'))
			.ToArray();
			spotlight=string.Join(' ',tem);
	}


    private void CalculateWord(string respuesta, List<char> guessed)
    {
        throw new NotImplementedException();
    }

	
	private void HandleGuess(char letter){
		if (guessed.IndexOf(letter) == -1)
		{
			guessed.Add(letter);
		}
		if (respuesta.IndexOf(letter) >=0 )
		{
			CalculateWord(respuesta, guessed);
			ChekIfGameWon();

		}
		else if (respuesta.IndexOf(letter) == -1)
		{
			mistakes++;
			UpdateStatus();
			CheckIfGameLost();
			Currentimage = $"Cabeza{mistakes}.png";// agregar imagen
		}
	}
// metodo que evalua si ganas las partida 
	private void ChekIfGameWon(){
		if (SpotLight.Replace(" "," ") == respuesta)
		{
			mensaje = "Win";
			DisableLetters();
		}
	}
// metodo que evalua si pierde la partida 
	private void  CheckIfGameLost(){
		if (mistakes == maxWrong)
		{
			mensaje = "fucking Hamaa"; // mensaje 
			DisableLetters();// bloque llas letras 
		}
	}
	
// metodo para desabilitar las letras
	private void DisableLetters()
	{
		foreach (var children in LettersContainer.Children)
		{
			var btn = children as Button;
			if (btn != null)
			{
				btn.IsEnabled = false;
			}
		}
	}
	
	#endregion
}