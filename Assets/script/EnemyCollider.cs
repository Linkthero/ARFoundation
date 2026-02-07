using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    Animator animator;
    [SerializeField] private GameObject explosionPrefab;
    private CapsuleCollider col;
    [SerializeField] GameObject panelMuerte;

    [SerializeField] private AudioClip sonidoVida;
    [SerializeField] private AudioClip sonidoMoneda;
    [SerializeField] private AudioClip sonidoSalto;
    [SerializeField] private AudioClip sonidoExplosion;
    [SerializeField] private AudioClip sonidoMuerte;
     private AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
        Datos.instance.actualizar();

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //si es enemigo
        if (other.CompareTag("Enemy"))
        {
            Datos.instance.PerderVida();
            if(Datos.instance.GetVidas() <= 0)
            {
                col.enabled = false; //desactivar el collider para que no siga colisionando
                other.GetComponent<BoxCollider>().enabled = false;
                //Debug.Log("Game Over");
                animator.SetTrigger("Death");
                //transform.parent.GetComponent<BoxCollider>().enabled = false;
                audioSource.PlayOneShot(sonidoMuerte);
                Invoke(nameof(mostrarPanelMuerte), 3f); //esperar 3 segundo antes de mostrar el panel de muerte
            } else
            {
                animator.SetTrigger("Hurt");
                audioSource.PlayOneShot(sonidoExplosion);
            }
            GameObject ex = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            StartCoroutine(eliminarExplosion(ex));
            return;
        }

        //si es moneda
        if(other.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(sonidoMoneda);
            Datos.instance.AumentaPuntos();
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Vida"))
        {
            audioSource.PlayOneShot(sonidoVida);
            Datos.instance.AumentaVida();
            Destroy(other.gameObject);
        }
    }

    IEnumerator eliminarExplosion(GameObject explosion)
    {
        yield return new WaitForSeconds(1f);        //lo que dura la animacion de la explosion
        Destroy(explosion);
    }

    private void mostrarPanelMuerte()
    {
        //mostrar panel de muerte
        panelMuerte.SetActive(true);
        //pausar el juego
        //Time.timeScale = 0f;
        panelMuerte.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Puntuación: " + Datos.instance.GetPuntos().ToString();
    }
}
