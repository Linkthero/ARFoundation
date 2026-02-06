using UnityEngine;

public class playerJump : MonoBehaviour
{
    public bool isGrounded;
    public int vidas = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Tocó el suelo");
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("OnTrigger");
    //    if(other.gameObject.CompareTag("Enemy"))
    //    {
    //        vidas--;
    //        if(vidas == 0)
    //        {
    //            Time.timeScale = 0f; // Pausa el juego
    //            Debug.Log("Choco con enemigo");
    //        }
    //    }
    //}
}
