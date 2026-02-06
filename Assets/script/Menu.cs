using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jugar()
    {
        SceneManager.LoadScene("FaceTrack");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Reintentar()
    {
        Datos.instance.ReiniciarDatos();
        SceneManager.LoadScene("FaceTrack");
    }
}
