using TMPro;
using UnityEngine;

public class Datos : MonoBehaviour
{
    public static Datos instance;

    [SerializeField] private TextMeshProUGUI txtVidas;
    [SerializeField] private TextMeshProUGUI txtPuntos;


    public int MaxVidas = 3;
    private int vidasActuales;

    private int puntos;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidasActuales = MaxVidas;
        puntos = 0;

        txtPuntos.text = puntos.ToString();
        txtVidas.text = vidasActuales.ToString();
    }

    public int GetVidas()
    {
        return vidasActuales;
    }

    public void PerderVida()
    {
        vidasActuales--;
        txtVidas.text = vidasActuales.ToString();
    }

    public int GetPuntos()
    {
        return puntos;
    }

    public void AumentaPuntos()
    {
        puntos++;
        txtPuntos.text = puntos.ToString();
    }

    public void ReiniciarDatos()
    {
        vidasActuales = MaxVidas;
        puntos = 0;
        txtPuntos.text = puntos.ToString();
        txtVidas.text = vidasActuales.ToString();
    }

    public void actualizar()
    {
        txtPuntos.text = puntos.ToString();
        txtVidas.text = vidasActuales.ToString();
    }
}
