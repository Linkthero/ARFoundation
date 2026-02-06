using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemigo : MonoBehaviour
{
    //Animator animator;
    //public float speed;
    //public Rigidbody target;
    //private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //animacion rompe cubo
            //animacion hurt player
        }
    }

}
