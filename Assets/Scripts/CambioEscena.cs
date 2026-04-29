using UnityEngine;
using UnityEngine.SceneManagement; // Importante para manejar escenas

public class CambioEscena : MonoBehaviour
{
    public void CargarJuego()
    {
        // "SampleScene" es el nombre de tu escena actual según la imagen
        SceneManager.LoadScene("SampleScene");
    }

    public void SalirDelJuego()
{
    Debug.Log("Saliendo del juego..."); // Esto es para ver que funciona en Unity
    Application.Quit(); // Esto cierra el juego cuando ya es un archivo .exe
}


public void IrAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}