using TMPro;
using UnityEngine;

public class Datos : MonoBehaviour
{
    public static Datos instance;

    [SerializeField] public TextMeshProUGUI txtVidas;
    [SerializeField] public TextMeshProUGUI txtPuntos;

    [SerializeField] public GameObject panelTutorial;

    public float cronometro;


    public int MaxVidas = 3;
    private int vidasActuales;

    private int puntos;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("miau awake");
        }
        else
        {
            Destroy(gameObject);
            Datos.instance.cronometro = 0;
            Datos.instance.txtVidas = GameObject.Find("txtVidas").GetComponent<TextMeshProUGUI>();
            Datos.instance.txtPuntos = GameObject.Find("txtPuntos").GetComponent<TextMeshProUGUI>();
            Datos.instance.panelTutorial = GameObject.Find("PanelTutorial");
            
            //Debug.Log("miau awake destroy");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        vidasActuales = MaxVidas;
        puntos = 0;

        //Debug.Log("miau start");
        txtPuntos.text = puntos.ToString();
        txtVidas.text = vidasActuales.ToString();
    }

    private void Update()
    {
        if(cronometro < 6)
        {
            cronometro += 1 * Time.deltaTime;
        } else
        {
            panelTutorial.SetActive(false);
        }
        
    }

    public void empiezaJuego()
    {
        panelTutorial.SetActive(false);
        Time.timeScale = 1f;
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

    public void AumentaVida()
    {
        vidasActuales++;
        txtVidas.text = vidasActuales.ToString();
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
